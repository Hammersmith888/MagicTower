using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private static LivesManager _instance;

    public static LivesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LivesManager>();
            }
            return _instance;
        }
    }

    #region CONSTANTS

    // Ids to be used for persistent storage
    const string ID_CURRENT_LIVES = "lm_current_lives";
    const string ID_REGENERATION_TIMESTAMP = "lm_reset_timestamp";
    const string ID_UNLIMITED_TIMESTAMP = "lm_unlimited_timestamp";
    const string ID_EXTRA_LIVE_SLOTS = "lm_extra_slots";
    const string ID_FIRST_TIME = "lm_first_time";

    #endregion

    #region VARIABLES

    // The current lives the player has
    int currentLives;

    // Any extra live slots the user has purchased 
    int extraLives;

    // The timestamp a life should refill (in seconds)
    string regenerationTimestamp;

    // The timestamp unlimited lives should end (in seconds)
    string unlimitedTimestamp;

    #endregion

    #region EXTERNAL_API
    // Return true if you have more than 0 lives or unlimited lives.
    public bool canLooseLife()
    {
        return currentLives > 0 && !IsUnlimitedLives();
    }

    // Remove 1 life from current lives
    public void looseOneLife()
    {
        // If you already have 0 lives, do nothing
        if (currentLives == 0)
            return;

        // Update current lives variable
        currentLives--;

        // Sync current lives variable with persistent storage
        SPlayerPrefs.SetInt(ID_CURRENT_LIVES, currentLives);
        SPlayerPrefs.Save();



        // If you had full lives, start the refill timer
        if (currentLives == GetMaxNumberOfLives() - 1)
        {
            SetLifeRegenerationTimer();
            InvokeRepeating("CheckRegenerationTime", 0.0f, 1.0f);
        }
        //Notifications.LocalNotificationsController.instance.ReScheduledFullEnergyNotification();
        //Notifications.LocalNotificationsController.instance.ScheduleFullEnergyNotification ( (int)getFullRefillSecondsLeft () );
    }

    /*
	 * Returns true if you dont have unlimited lives 
	 * and you can refill atleast one life
	 */
    public bool canRefillLives()
    {
        return currentLives < GetMaxNumberOfLives() && !IsUnlimitedLives();
    }

    // Add 1 life
    public void refillOneLife()
    {

        // If you already have full lives, do nothing
        if (currentLives == GetMaxNumberOfLives())
            return;

        currentLives++;
        SPlayerPrefs.SetInt(ID_CURRENT_LIVES, currentLives);
        SPlayerPrefs.Save();

        // Reset the refill timer
        //Notifications.LocalNotificationsController.instance.ReScheduledFullEnergyNotification();
        if (currentLives < GetMaxNumberOfLives())
        {
            //Notifications.LocalNotificationsController.instance.ScheduleFullEnergyNotification( ( int ) getFullRefillSecondsLeft() );
            SetLifeRegenerationTimer();
        }
        else
        {
            //OneSignalController.instanse.removeFullEnergyNotification ();
        }
    }

    // Refill all lives
    public void refillAllLives()
    {
        while (currentLives < GetMaxNumberOfLives())
        {
            refillOneLife();
        }
        //Notifications.LocalNotificationsController.instance.ReScheduledFullEnergyNotification();
    }

    // Returns true if you can buy unlimited lives in-app (you don't already have unlimited lives)
    public bool canGetUnlimitedLives()
    {
        return !IsUnlimitedLives();
    }

    // Refill specified number lives
    public void refillXLives(int livesToAdd)
    {
        for (int i = 0; i < livesToAdd; i++)
        {
            refillOneLife();
        }
    }

    public int getCurrentLives()
    {
        return currentLives;
    }

    // Get Unlimited lives
    public void getUnlimitedLives()
    {

        // If you already have unlimited lives, do nothing
        if (IsUnlimitedLives())
            return;

        refillAllLives();
        SetUnlimitedTimer();
        InvokeRepeating("CheckUnlimitedTime", 0.0f, 1.0f);
    }

    /* 
	 * Check if you can purchase an extra life slot. 
	 * Ideal in case you want to enable/disable the "purchase extra life slot" button.
	 */
    public bool canGetExtraLifeSlot()
    {
        if (extraLives < LMConfig.MAX_EXTRA_LIFE_SLOTS)
            return true;

        return false;
    }

    // Purchase an extra life slot
    public void getExtraLifeSlot()
    {
        extraLives++;
        SPlayerPrefs.SetInt(ID_EXTRA_LIVE_SLOTS, extraLives);
        SPlayerPrefs.Save();
        refillAllLives();
    }

    /* 
	 * Check if there are lives left to play
	 * Ideal to use in order to decide if you will take the user to gamescene,
	 * or show him the "out of lives popup"
	 */
    public bool canPlay()
    {
        return IsUnlimitedLives() || currentLives > 0;
    }

    // Get seconds left to refill a life. Can be used for notifications. Call only if canRefillLives() returns true.
    public double getRefillSecondsLeft()
    {
        return double.Parse(regenerationTimestamp) - GetCurrentTimeInSeconds();
    }

    // Get seconds left to refill all lives. Can be used for notifications. Call only if canRefillLives() returns true.
    public double getFullRefillSecondsLeft()
    {

        double secondsToBeRefilled = 0;
        double livesToBeRefilled = GetMaxNumberOfLives() - currentLives;

        if (livesToBeRefilled > 0)
        {
            secondsToBeRefilled = getRefillSecondsLeft();
        }

        if (livesToBeRefilled > 1)
        {
            for (int i = 0; i < livesToBeRefilled - 1; i++)
            {
                secondsToBeRefilled += LMConfig.REFILL_LIFE_SECONDS;
            }
        }

        return secondsToBeRefilled;
    }

    #endregion

    #region INTERNAL_API
    private void Start()
    {
        //Application.runInBackground = true;
        _instance = this;
        //DontDestroyOnLoad(gameObject);
        // If its the first time, initialize permanent data store
        if (SPlayerPrefs.GetInt(ID_FIRST_TIME) == 0)
        {
            FirstTimeInit();
        }

        // Load local variables with correct values
        currentLives = SPlayerPrefs.GetInt(ID_CURRENT_LIVES);
        extraLives = SPlayerPrefs.GetInt(ID_EXTRA_LIVE_SLOTS);
        regenerationTimestamp = SPlayerPrefs.GetString(ID_REGENERATION_TIMESTAMP);
        unlimitedTimestamp = SPlayerPrefs.GetString(ID_UNLIMITED_TIMESTAMP);

        // If you dont have full lives, start the refill timer
        if (currentLives < GetMaxNumberOfLives())
        {
            InvokeRepeating("CheckRegenerationTime", 0.0f, 1.0f);
        }

        // If you have unlimited lives, start the unlimited lives timer
        if (IsUnlimitedLives())
        {
            InvokeRepeating("CheckUnlimitedTime", 0.0f, 1.0f);
        }

       // Notifications.LocalNotificationsController.instance.ReScheduledFullEnergyNotification();
    }

    // If this is the first time, initialize all player preferences in permanent datastore
    private void FirstTimeInit()
    {
        Debug.Log("First Time Init");
        SPlayerPrefs.SetInt(ID_CURRENT_LIVES, LMConfig.BASIC_LIFE_SLOTS);
        SPlayerPrefs.SetString(ID_REGENERATION_TIMESTAMP, "0");
        SPlayerPrefs.SetString(ID_UNLIMITED_TIMESTAMP, "0");
        SPlayerPrefs.SetString(ID_EXTRA_LIVE_SLOTS, "0");
        SPlayerPrefs.SetInt(ID_FIRST_TIME, 1);
        SPlayerPrefs.Save();
    }

    // Resets all values in permanent store
    public void reset()
    {
        SPlayerPrefs.DeleteAll();
        SPlayerPrefs.Save();
        Start();
    }

    // Returns current lives text
    private string GetCurrentLivesMsg()
    {
        if (IsUnlimitedLives())
        {
            return "∞";
        }
        else
        {
            return currentLives.ToString();
        }
    }

    // Returns time left msg
    private string GetTimeLeftMsg()
    {
        if (IsUnlimitedLives())
            return SecondsToTimeFormatter(GetUnlimitedSecondsLeft());

        if (currentLives == GetMaxNumberOfLives())
        {
            return LMConfig.TEXT_FULL_LIVES;
        }
        else
        {
            return SecondsToTimeFormatter(getRefillSecondsLeft());
        }
    }

    // Format timer to appropriate format
    private string SecondsToTimeFormatter(double seconds)
    {

        if (seconds < 3600)
        {// Show minutes and seconds format
            return string.Format("{0:0}:{1:00}", Mathf.Floor((float)seconds / 60), Mathf.RoundToInt((float)seconds % 60));
        }
        else
        { // Show hours format
            return Mathf.CeilToInt((float)seconds / 3600).ToString() + " " + LMConfig.TEXT_HOURS_LEFT;
        }
    }

    // Check if unlimited lives have ended.
    private void CheckUnlimitedTime()
    {
        // If unlmited lives have ended, stop the timer and reset permanent datastore values
        if (GetUnlimitedSecondsLeft() <= 0)
        {
            unlimitedTimestamp = "0";
            SPlayerPrefs.SetString(ID_UNLIMITED_TIMESTAMP, "0");
            SPlayerPrefs.Save();
            CancelInvoke("CheckUnlimitedTime");
        }
    }

    // Check if a life has been refilled
    private void CheckRegenerationTime()
    {
        double refillSecondsLeft = getRefillSecondsLeft();

        if (refillSecondsLeft <= 0)
        {
            int numberOfLivesToRestore = 1;
            numberOfLivesToRestore += (int)Mathf.Abs((float)refillSecondsLeft) / LMConfig.REFILL_LIFE_SECONDS;
            refillXLives(numberOfLivesToRestore);

            //Overwrite regeneration time stamp with seconds left
            int secondsLeft = (int)Mathf.Abs((float)refillSecondsLeft) % LMConfig.REFILL_LIFE_SECONDS;
            if (secondsLeft > 0)
            {
                regenerationTimestamp = (GetCurrentTimeInSeconds() + LMConfig.REFILL_LIFE_SECONDS - secondsLeft).ToString();
                SPlayerPrefs.SetString(ID_REGENERATION_TIMESTAMP, regenerationTimestamp);
                SPlayerPrefs.Save();
            }
        }

        if (currentLives == GetMaxNumberOfLives())
        {
            CancelInvoke("CheckRegenerationTime");
            regenerationTimestamp = "0";
            SPlayerPrefs.SetString(ID_REGENERATION_TIMESTAMP, "0");
            SPlayerPrefs.Save();
        }
    }

    // Set life regeneration timestamp in permanent datastore
    private void SetLifeRegenerationTimer()
    {
        regenerationTimestamp = (GetCurrentTimeInSeconds() + LMConfig.REFILL_LIFE_SECONDS).ToString();
        SPlayerPrefs.SetString(ID_REGENERATION_TIMESTAMP, regenerationTimestamp);
        SPlayerPrefs.Save();
    }

    // Set unlmited lives timestamp in permanent datastore
    private void SetUnlimitedTimer()
    {
        unlimitedTimestamp = (GetCurrentTimeInSeconds() + LMConfig.UNLIMITED_LIVES_SECONDS).ToString();
        SPlayerPrefs.SetString(ID_UNLIMITED_TIMESTAMP, unlimitedTimestamp);
        SPlayerPrefs.Save();
    }

    // Get seconds left to end unlimited lives
    private double GetUnlimitedSecondsLeft()
    {
        return double.Parse(unlimitedTimestamp) - GetCurrentTimeInSeconds();
    }

    // Get current time in seconds
    private double GetCurrentTimeInSeconds()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        return timestamp;
    }

    // Get maximum number of lives
    private int GetMaxNumberOfLives()
    {
        return LMConfig.BASIC_LIFE_SLOTS + extraLives;
    }

    // Returns true if you have unlimited lives
    private  bool IsUnlimitedLives()
    {
        return GetUnlimitedSecondsLeft() > 0;
    }

    #endregion
}
