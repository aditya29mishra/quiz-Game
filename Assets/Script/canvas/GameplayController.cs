using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public void PauseGame()
    {
        UIManager.Instance.ShowPauseMenu();
    }

    public void NextQuestion()
    {
        QuizManager.Instance.LoadNextQuestion(); 
    }
}
