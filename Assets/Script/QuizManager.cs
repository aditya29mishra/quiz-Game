using System.Collections.Generic;
using Firebase.Database;
using Firebase.Firestore;
using UnityEngine;
using TMPro;
using System;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;
    public TextMeshProUGUI questionText;
    public List<TextMeshProUGUI> answerButtons;
    public GameObject canvasGameplay;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TotalscoreText;
    private FirebaseFirestore firestore;
    private DatabaseReference realtimeDatabase;
    private List<QuestionData> currentQuestions;
    private int currentQuestionIndex = 0;
    private int selectedAnswerIndex = -1;
    private int currentQuizScore = 0;
    private int totalScore = 0;
    private string currentQuizKey = "";
    private string playerId => MainMenuController.playerId;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        firestore = FirebaseFirestore.DefaultInstance;
        realtimeDatabase = FirebaseDatabase.DefaultInstance.RootReference;
    }
    void Update()
    {
        FetchAndUpdateTotalScore();
    }

    public void LoadQuiz(string quizKey)
    {
        currentQuizKey = quizKey;
        currentQuizScore = 0;
        ResetQuizScore(quizKey);
        firestore.Collection("objects").Document(quizKey).GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                var quizData = task.Result;
                if (quizData.Exists)
                {
                    currentQuestions = ParseQuizData(quizData);
                    currentQuestionIndex = 0;
                    DisplayQuestion();
                    UpdateGameState("in_quiz");
                }
            }
        });
    }

    List<QuestionData> ParseQuizData(DocumentSnapshot quizData)
    {
        var questions = new List<QuestionData>();
        var questionList = quizData.GetValue<List<Dictionary<string, object>>>("questions");
        foreach (var questionEntry in questionList)
        {
            var optionsList = (List<object>)questionEntry["options"];
            questions.Add(new QuestionData
            {
                question = questionEntry["question"].ToString(),
                options = optionsList.ConvertAll(o => o.ToString()),
                correctOption = int.Parse(questionEntry["correctOption"].ToString())
            });
        }
        return questions;
    }
    void DisplayQuestion()
    {
        if (currentQuestionIndex < currentQuestions.Count)
        {
            var question = currentQuestions[currentQuestionIndex];
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                questionText.text = question.question;
                for (int i = 0; i < answerButtons.Count; i++)
                {
                    if (i < question.options.Count)
                    {
                        answerButtons[i].text = question.options[i];
                    }
                    else
                    {
                        answerButtons[i].text = "";
                    }
                }
                selectedAnswerIndex = -1;
            });
        }
        else
        {
            EndQuiz();
        }
    }
    public void OnAnswerSelected(int buttonIndex)
    {
        selectedAnswerIndex = buttonIndex;
    }

    public void LoadNextQuestion()
    {
        if (selectedAnswerIndex == -1)
        {
            return;
        }

        var correctOption = currentQuestions[currentQuestionIndex].correctOption;
        if (selectedAnswerIndex == correctOption)
        {
            Debug.Log("Correct Answer!");
            currentQuizScore++;
            UpdateScore(currentQuizKey, 1);
            UpdateTextScore();
        }
        else
        {
            Debug.Log("Wrong Answer!");
        }
        if (currentQuestionIndex < currentQuestions.Count - 1)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }
        else
        {
            EndQuiz();
            scoreText.text = "0";
        }
    }

    private void UpdateTextScore()
    {
        scoreText.text = currentQuizScore.ToString();
    }
    private void FetchAndUpdateTotalScore()
{
    realtimeDatabase.Child("players").Child(playerId).Child("totalScore").GetValueAsync().ContinueWith(task =>
    {
        if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                totalScore = int.Parse(snapshot.Value.ToString());
                UnityMainThreadDispatcher.Instance().Enqueue(() =>
                {
                    TotalscoreText.text = totalScore.ToString();
                });
            }
            else
            {
                totalScore = 0;
                UnityMainThreadDispatcher.Instance().Enqueue(() =>
                {
                    TotalscoreText.text = "0";
                });
            }
        }
    });
}

    void EndQuiz()
    {
        canvasGameplay.SetActive(false);
        UpdateGameState("in_game");
    }

    void UpdateScore(string quizKey, int increment)
    {
        realtimeDatabase.Child("players").Child(playerId).Child("scores").Child(quizKey).RunTransaction(mutableData =>
        {
            int currentScore = mutableData.Value == null ? 0 : int.Parse(mutableData.Value.ToString());
            mutableData.Value = currentScore + increment;
            return TransactionResult.Success(mutableData);
        });
        realtimeDatabase.Child("players").Child(playerId).Child("totalScore").RunTransaction(mutableData =>
        {
            int currentTotalScore = mutableData.Value == null ? 0 : int.Parse(mutableData.Value.ToString());
            mutableData.Value = currentTotalScore + increment;
            return TransactionResult.Success(mutableData);
        }).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                FetchAndUpdateTotalScore();
            }
        });
    }
    public void UpdateGameState(string newState)
    {
        realtimeDatabase.Child("players").Child(playerId).Child("gameState").SetValueAsync(newState);
    }



    void ResetQuizScore(string quizKey)
    {
        realtimeDatabase.Child("players").Child(playerId).Child("scores").Child(quizKey).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if (snapshot.Exists)
                {
                    int oldQuizScore = int.Parse(snapshot.Value.ToString());
                    AdjustTotalScore(-oldQuizScore);
                    realtimeDatabase.Child("players").Child(playerId).Child("scores").Child(quizKey).SetValueAsync(0);
                    //FetchAndUpdateTotalScore();
                }
            }
        });
    }

    private void AdjustTotalScore(int scoreDelta)
    {
        realtimeDatabase.Child("players").Child(playerId).Child("totalScore").RunTransaction(mutableData =>
        {
            int currentTotalScore = mutableData.Value == null ? 0 : int.Parse(mutableData.Value.ToString());
            mutableData.Value = currentTotalScore + scoreDelta;
            return TransactionResult.Success(mutableData);
        });
    }
    public class QuestionData
    {
        public string question;
        public List<string> options;
        public int correctOption;
    }
}
