using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public TMP_InputField playerIdInputField;
    public static string playerId;

    private DatabaseReference databaseReference;
    public GameObject loadGameButton;
    public GameObject startGameButton;
    private void Start()
    {
        var options = new AppOptions
        {
            ApiKey = "AIzaSyCGeCKhYWfAzQHzllubl6kgtID5TvSgYqc",
            AppId = "1:585472712028:android:f91c311fcc21e7a2f6f599",
            ProjectId = "chamberly-a2a0c",
            DatabaseUrl = new System.Uri("https://chamberly-a2a0c-default-rtdb.firebaseio.com"),
            StorageBucket = "chamberly-a2a0c.firebasestorage.app"
        };
        FirebaseApp app = FirebaseApp.Create(options);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        loadGameButton.SetActive(false);
        startGameButton.SetActive(false);

    }
    public void StartGame()
    {
        if (string.IsNullOrEmpty(playerId))
        {
            return;
        }
        ResetPlayerData(playerId);
        StartCoroutine(LoadGameplayScene());
    }

    public void LoadGame()
    {
        if (string.IsNullOrEmpty(playerId))
        {
            return;
        }
        StartCoroutine(LoadGameplayScene());
    }

    public void CheckPlayer()
    {
        playerId = playerIdInputField.text.Trim();
        if (string.IsNullOrEmpty(playerId))
        {
            return;
        }
        CheckOrCreatePlayerNode(playerId);
    }

    private IEnumerator LoadGameplayScene()
    {
        AsyncOperation loadOp = SceneManager.LoadSceneAsync("GameplayScene");
        while (!loadOp.isDone)
        {
            yield return null;
        }
    }
    private void CheckOrCreatePlayerNode(string playerId)
    {
        databaseReference.Child("players").Child(playerId).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if (!snapshot.Exists)
                {
                    loadGameButton.SetActive(false);
                    startGameButton.SetActive(true);
                    CreateNewPlayerNode(playerId);
                }
                else
                {
                    loadGameButton.SetActive(true);
                    startGameButton.SetActive(true);
                }
            }
        });
    }

    private void CreateNewPlayerNode(string playerId)
    {
        var playerData = new Dictionary<string, object>
        {
            { "totalScore", 0 },
            { "gameState", "in_game" },
            { "scores", new Dictionary<string, object>() }
        };
        databaseReference.Child("players").Child(playerId).SetValueAsync(playerData);
    }

    private void ResetPlayerData(string playerId)
    {
        databaseReference.Child("players").Child(playerId).Child("scores").RemoveValueAsync();
        databaseReference.Child("players").Child(playerId).Child("totalScore").SetValueAsync(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
