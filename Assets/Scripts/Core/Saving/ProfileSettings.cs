
using UnityEngine;
using System.Collections.Generic;
using System;

public partial class SaveManager
{
    [System.Serializable]
    public class ProfileSettings
    {
        [System.Serializable]
        public class InvitedUserData
        {
            public string id;
            public bool rewardReceived;

            public InvitedUserData(string id)
            {
                this.id = id;
                rewardReceived = false;
            }

            public void SetRewardReceived()
            {
                rewardReceived = true;
            }
        }

        [SerializeField]
        private string profileID;

        public bool adsDisabled;
        public bool rateUsWindowWasShown;
        public bool rateUsWindowWasShownAfter15Level;
        public bool vipWindowWasShown;
        public bool notificationWindowWasShown;
        public bool introWasViewed;
        public bool showGemsCounter;


        public Int32 dateTimeUtcFirstWin;
        public int openCrown;


        public string devToDevId;


        public List<InvitedUserData> invitedUsersData;

        public static string CurrentProfileID { get; private set; }

        public string ProfileID { get { return profileID; } }

        public ProfileSettings()
        {
            invitedUsersData = new List<InvitedUserData>();
        }

        public static ProfileSettings Default
        {
            get
            {
                ProfileSettings defaultSettings = new ProfileSettings();
                return defaultSettings;
            }
        }

        public static void SetProfileID(string newID)
        {
            if (!string.IsNullOrEmpty(newID) && newID != CurrentProfileID)
            {
                Debug.LogFormat("<color=red><b>Changing Profile ID</b>: {0} -> {1}</color>", CurrentProfileID, newID);
                var defaultSettings = PPSerialization.Load<ProfileSettings>(EPrefsKeys.ProfileSettings);
                if(defaultSettings == null)
                    defaultSettings = new ProfileSettings();
                defaultSettings.profileID = newID;
                CurrentProfileID = newID;
                PPSerialization.Save(EPrefsKeys.ProfileSettings, defaultSettings, true);
            }
        }

        public static void Validate()
        {
            ProfileSettings profile = PPSerialization.Load<ProfileSettings>(EPrefsKeys.ProfileSettings.ToString());
            if (profile == null)
            {
                profile = ProfileSettings.Default;
                PPSerialization.Save(EPrefsKeys.ProfileSettings.ToString(), profile, true, true);
            }
            else
            {
                if (profile.ValidateID())
                {
                    PPSerialization.Save(EPrefsKeys.ProfileSettings.ToString(), profile, true, true);
                }
            }
            profile.SetAsCurrent();
        }

        public bool IsUserAlreadyInvited(string id)
        {
            if (!invitedUsersData.IsNullOrEmpty())
            {
                int count = invitedUsersData.Count;
                for (int i = 0; i < count; i++)
                {
                    if (invitedUsersData[i].id == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateID()
        {
            if (string.IsNullOrEmpty(profileID))
            {
                if(Application.isEditor)
                {
#if UNITY_EDITOR
                    profileID = SaveManager.Instance.userID;
                    CurrentProfileID = profileID;
                    return true;
#endif
                }
                profileID = Social.FacebookManager.LastLoggedInFacebookID;
                if (string.IsNullOrEmpty(profileID))
                {
                    profileID = ProfileIDGenerator.GenerateID();
                    Debug.LogError($"CHANGE VALIDATE ID :{profileID}");
                }
                CurrentProfileID = profileID;

                AnalyticsController.Instance.LogMyEvent("Firebase", new Dictionary<string, string>()
                {
                    { "ProfileID", profileID }
                });

                return true;
            }
            Debug.LogError($"ValidateID :<b>{profileID}</b>");
            AnalyticsController.Instance.LogMyEvent("Firebase", new Dictionary<string, string>()
                {
                    { "ProfileID", profileID }
                });
            CurrentProfileID = profileID;
            return false;
        }

        private void SetAsCurrent()
        {
            if (string.IsNullOrEmpty(profileID))
            {
                Debug.Log($"Profile ID is IsNullOrEmpty generating new: {profileID}");
                profileID = ProfileIDGenerator.GenerateID();
            }
            CurrentProfileID = profileID;
#if UNITY_EDITOR
            profileID = SaveManager.Instance.userID;
            CurrentProfileID = profileID;
#endif
        }
    }

}
