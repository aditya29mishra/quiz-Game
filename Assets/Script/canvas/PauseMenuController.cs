using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void ResumeGame()
    {
        UIManager.Instance.HidePauseMenu();
    }
    public void QuitToMainMenu()
    {
        Application.Quit();
    }
}
