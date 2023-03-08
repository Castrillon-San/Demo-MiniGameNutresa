using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using Firebase;
using System.Threading.Tasks;

public class ButtonFirebaseManager : MonoBehaviour
{
    //FirebaseController firebaseController;
    //[SerializeField] TMP_InputField email, password;

    //public void LogIn()
    //{
    //    if (email.text == "" || password.text == "") return;
    //    firebaseController.SignIn(email.text, password.text);
    //}

    //public void Register()
    //{
    //    if (email.text == "" || password.text == "") return;
    //    firebaseController.RegisterNewUser(email.text, password.text);
    //}

    //public void LogOut()
    //{
    //    firebaseController.SignOut();
    //}
}

//public class FirebaseController
//{
//    Firebase.Auth.FirebaseAuth auth = null;
//    Firebase.Auth.FirebaseUser user = null;

//    public FirebaseController()
//    {
//        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
//            var dependencyStatus = task.Result;
//            if (dependencyStatus == Firebase.DependencyStatus.Available)
//            {
//                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//                user = auth.CurrentUser;
//            }
//            else
//            {
//                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
//            }
//        });

//    }
//    public Task RegisterNewUser(string email, string password)
//    {
//        return auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled) return;
//            if (task.IsFaulted) return;
//            user = task.Result;
//        });
//    }

//    public Task SignIn(string email, string password)
//    {
//        return auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled) return;
//            if (task.IsFaulted) return;
//            user = task.Result;
//        });
//    }

//    public void SignOut()
//    {
//        auth.SignOut();
//        user = null;
//    }
//}//public class FirebaseController
//{
//    Firebase.Auth.FirebaseAuth auth = null;
//    Firebase.Auth.FirebaseUser user = null;

//    public FirebaseController()
//    {
//        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
//            var dependencyStatus = task.Result;
//            if (dependencyStatus == Firebase.DependencyStatus.Available)
//            {
//                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//                user = auth.CurrentUser;
//            }
//            else
//            {
//                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
//            }
//        });

//    }
//    public Task RegisterNewUser(string email, string password)
//    {
//        return auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled) return;
//            if (task.IsFaulted) return;
//            user = task.Result;
//        });
//    }

//    public Task SignIn(string email, string password)
//    {
//        return auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled) return;
//            if (task.IsFaulted) return;
//            user = task.Result;
//        });
//    }

//    public void SignOut()
//    {
//        auth.SignOut();
//        user = null;
//    }
//}
