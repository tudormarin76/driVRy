using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System.Threading.Tasks;
using System;

public class FirebaseManager : MonoBehaviour
{
    [SerializeField]
    InputField email;

    [SerializeField]
    Button continueButton;

    [SerializeField]
    Text error;

    private bool loginState = false;
    private string buffer;

    public GameObject toast;

    void Start()
    {
        //Only used by unity editor
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://drivry-70d9a.firebaseio.com");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public async void Login()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        await auth.CreateUserWithEmailAndPasswordAsync(email.text, "123456").ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                buffer = task.Exception.GetBaseException().Message;
                loginState = false;
                return;
            }
            if (task.IsFaulted)
            {
                buffer = task.Exception.GetBaseException().Message;
                loginState = false;
                return;
            }

            loginState = true;
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });

        if (loginState)
        {
            gameObject.GetComponent<MenuManager>().emailPopup.SetActive(false);
            toast.SetActive(true);
            StartCoroutine(ShowToast());
            
        }
        else
        {
            
            error.color = Color.red;
            error.text = buffer;
        }

    }

    private void OnDestroy()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }


    IEnumerator ShowToast()
    {
        yield return new WaitForSecondsRealtime(2);
        toast.SetActive(false);
    }
}
