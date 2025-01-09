using UnityEngine;

public class InteractiveObjectMobile : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    public GameObject canvasGameplay;
    public GameObject canvasPauseMenu;
    public string objectQuizKey;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (canvasGameplay.activeSelf || canvasPauseMenu.activeSelf)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        TriggerQuiz();
                    }
                }
            }
        }
        # if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    TriggerQuiz();
                }
            }
        }
        # endif
    }

    void TriggerQuiz()
    {
        Debug.Log($"[InteractiveObjectMobile] Triggering quiz with key: {objectQuizKey}");

        objectRenderer.material = highlightMaterial;
        canvasGameplay.SetActive(true);
        QuizManager.Instance.LoadQuiz(objectQuizKey);
    }
    public void ResetMaterial()
    {
        objectRenderer.material = originalMaterial;
    }
}
