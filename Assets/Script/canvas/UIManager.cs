using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("UI Canvases")]
    public GameObject canvasMainMenu;
    public GameObject canvasGameplay;
    public GameObject canvasPauseMenu;
    public GameObject canvasJoystick;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #region Public Methods

    public void ShowMainMenu()
    {
        HideAllCanvases();
        canvasMainMenu.SetActive(true);
    }
    public void ShowGameplay()
    {
        HideAllCanvases();
        canvasGameplay.SetActive(false);
        canvasJoystick.SetActive(true);
    }
    public void ShowPauseMenu()
    {
        canvasJoystick.SetActive(false);
        canvasPauseMenu.SetActive(true);
        Time.timeScale = 0; 
    }
    public void HidePauseMenu()
    {
        if (canvasGameplay.activeSelf)
        {
            canvasPauseMenu.SetActive(false);
        }
        else
        {
            canvasPauseMenu.SetActive(false); 
            canvasJoystick.SetActive(true); 
        }
        Time.timeScale = 1;
    }
    public void ShowQuiz()
    {
        canvasGameplay.SetActive(true);
        canvasJoystick.SetActive(false);
    }
    private void HideAllCanvases()
    {
        canvasMainMenu?.SetActive(false);
        canvasGameplay?.SetActive(false);
        canvasPauseMenu?.SetActive(false);
        canvasJoystick?.SetActive(false);
    }
    #endregion
}
