using UnityEngine;
#if !NO_GPGS
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class CloudSaves
{
    private const int MaxConflictsInARowNumberToForceOpenSave = 2;

    private System.Action<bool> onSavedGameOpened;
    private System.Action<string, bool, byte[]> onGameDataLoaded;
    private System.Action<bool> onSaveGame;
    private System.Func<CloudSaves, byte[], byte[], bool> conflictResolver;
    private System.Action<bool> onAuthentication;

    public byte[]  dataSelectedInLastConflict;
    public bool selectedCustomData;

    private int conflictsCount;
    private bool conflictsResolutionForceBreak;

    private string saveFileName;
    public string SaveTag => saveFileName;

    private ISavedGameMetadata  m_SavedGameMetaData;
    public bool CurrentlySaving
    {
        get; private set;
    }


    public CloudSaves(string saveFileName, System.Func<CloudSaves, byte[], byte[], bool> saveFileConflictResolver)
    {
        this.saveFileName = saveFileName;
        conflictResolver = saveFileConflictResolver;
        //	Native.PlayServices.onAunthentication += OnPlayServicesAuthentication;
        //if( PlayGamesPlatform.Instance.IsAuthenticated() )
        //{
        //	authenticationListener.InvokeSafely( true );
        //}
    }

    private void OnPlayServicesAuthentication(bool result)
    {
        Debug.Log("GoogleClousSaves OnPlayServicesAuthentication: " + result);
        onAuthentication.InvokeSafely(result);
    }

    private void OpenSavedGame(System.Action<bool> callback)
    {
        Debug.Log("OpenSavedGame");
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            callback(false);
            return;
        }
        onSavedGameOpened = callback;
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        conflictsCount = 0;
        conflictsResolutionForceBreak = false;
        savedGameClient.OpenWithManualConflictResolution(saveFileName, DataSource.ReadCacheOrNetwork, false, ConflictCallback, OnSavedGameOpened);
    }

    private void ConflictCallback(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData, ISavedGameMetadata unmerged, byte[] unmergedData)
    {
        if (conflictsResolutionForceBreak)
        {
            Debug.Log("Saved Game conflict resolution stopped by force. Max number of attempts exceeded");
            return;
        }
        conflictsCount++;
        if (conflictsCount >= MaxConflictsInARowNumberToForceOpenSave)
        {
            conflictsResolutionForceBreak = true;
        }
        ISavedGameMetadata selectedMetadata = null;
        byte[] selectedData = null;
        string selectedMetadataName = null;
        if (conflictResolver(this, originalData, unmergedData))
        {
            selectedMetadataName = "Original";
            selectedMetadata = original;
            selectedData = originalData;
        }
        else
        {
            selectedMetadataName = "Unmerged";
            selectedMetadata = unmerged;
            selectedData = unmergedData;
        }

        Debug.LogFormat("SAVED GAME CONFLICT ({0})! SELECTED: <b>{1}</b>. MetaData is Open: {2}.\nOriginal File: [{3}] UnmergedFile: [{4}]", 
            saveFileName, selectedMetadataName, original.IsOpen, original.Filename, unmerged.Filename);

        if (conflictsResolutionForceBreak)
        {
            Debug.Log("GoogleCloudSaves ConflictCallback stopped by force.");
            OnSavedGameOpened(SavedGameRequestStatus.Success, selectedMetadata);
            return;
        }

        if (selectedMetadata.IsOpen)
        {
            resolver.ChooseMetadata(selectedMetadata);
        }
        else
        {
            var builder = new SavedGameMetadataUpdate.Builder();
            resolver.ResolveConflict(selectedMetadata, builder.Build(), selectedData);
        }
    }

    private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata gameMetaData)
    {
        conflictsCount = 0;
        if (status == SavedGameRequestStatus.Success)
        {
            m_SavedGameMetaData = gameMetaData;
            Debug.LogFormat("Saved games successfully opened [{0}] ", saveFileName);
            // handle reading or writing of saved game.
            onSavedGameOpened(true);
        }
        else
        {
            Debug.LogFormat("Failed to open saved games file [{0}] {1}", saveFileName, status);
            onSavedGameOpened(false);
            // handle error
        }
    }

    public void LoadGameData(System.Action<string, bool, byte[]> callback)
    {
        onGameDataLoaded = callback;
        OpenSavedGame((bool successfully) =>
        {
            if (successfully)
            {
                var savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                savedGameClient.ReadBinaryData(m_SavedGameMetaData, ReadSavedGameData);
            }
            else
            {
                onGameDataLoaded(saveFileName, false, null);
            }
        });
    }

    private void ReadSavedGameData(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            onGameDataLoaded(saveFileName, true, data);
            // handle processing the byte array data
            Logger.Log("GoggleCloud game save successfully loaded");
        }
        else
        {
            onGameDataLoaded(saveFileName, false, null);
            // handle error
            Logger.Log("Failed to load save file from Google Cloud. Status: " + status);
        }
    }

    public void SaveGame(byte[] savedData, System.Action<bool> callback = null)
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            callback.InvokeSafely(false);
            return;
        }

        CurrentlySaving = true;
        onSaveGame = callback;

        OpenSavedGame((bool successfully) =>
        {
            if (successfully)
            {
                ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
                SavedGameMetadataUpdate updatedMetadata = builder.Build();
                savedGameClient.CommitUpdate(m_SavedGameMetaData, updatedMetadata, savedData, OnSavedGameWritten);
            }
            else
            {
                CurrentlySaving = false;
                callback(false);
            }
        });
    }

    private void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        CurrentlySaving = false;
        if (status == SavedGameRequestStatus.Success)
        {
            onSaveGame.InvokeSafely(true);
            Logger.Log("Game save successfully saved to GoogleCloud");
        }
        else
        {
            onSaveGame.InvokeSafely(false);
            Logger.Log("Failed to save games file to GoogleCloud .Status: " + status);
        }
    }

    public void Reset(System.Action<bool> onSaveDeleted)
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            onSaveDeleted(false);
            return;
        }
        System.Action<SavedGameRequestStatus, ISavedGameMetadata> onOpened =
        ( SavedGameRequestStatus status, ISavedGameMetadata gameMetaData ) =>
        {
            Debug.Log( "Opened " + status );
            if( status == SavedGameRequestStatus.Success )
            {
                PlayGamesPlatform.Instance.SavedGame.Delete( gameMetaData );
            }
            onSaveDeleted( status == SavedGameRequestStatus.Success );
        };
        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(saveFileName, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseOriginal, onOpened);
    }
}
#else
//Dummy class that will be used if there no google cloud saves on the platform
public class CloudSaves
{
	public bool currentlySaving
	{
		get; private set;
	}

	public byte[]  dataSelectedInLastConflict;
	public bool selectedCustomData;

	private string saveFileName;
	public string getSaveTag
	{
		get {
			return getSaveTag;
		}
	}

	public bool SaveFileIsOpened
    {
        get { return false; }
    }

	public CloudSaves( string saveFileName, System.Func<CloudSaves, byte[ ], byte[ ], bool> saveFileConflictResolver )
	{
    }

    public void OpenSavedGame( System.Action<bool> callback )
    {
        callback( false );
    }

    public void LoadGameData( System.Action< string, bool, byte[] > callback )
    {
        callback( "",false, null );
    }

	public void SaveGame( byte[ ] savedData, System.Action<bool> callback = null )
    {
		callback.InvokeSafely( false );
    }
    public void Reset( System.Action<bool> onSaveDeleted )
    {
        onSaveDeleted(false);
    }
}
#endif
