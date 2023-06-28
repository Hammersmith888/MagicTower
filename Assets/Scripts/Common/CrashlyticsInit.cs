using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
//using Firebase.Unity.Editor;

public class CrashlyticsInit : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://magic-siege-57930146.firebaseio.com/");
        //FirebaseApp.DefaultInstance.SetEditorP12FileName("YOUR-FIREBASE-APP-P12.p12");
        //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("SERVICE-ACCOUNT-ID@YOUR-FIREBASE-APP.iam.gserviceaccount.com");
        //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // Crashlytics will use the DefaultInstance, as well;
                // this ensures that Crashlytics is initialized.
                FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here for indicating that your project is ready to use Firebase.
                Debug.Log("Firebase CRASHLYTIC INITIALIZE");
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
                Debug.LogError("Firebase CRASHLYTIC NOT INITIALIZE");
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
