using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerSceneLoader : MonoBehaviour
{
    public GameObject panelUI;         
    public Button goButton;            
    public string sceneName = "NombreDeTuEscena";  

    void Start()
    {
        panelUI.SetActive(false);
        goButton.onClick.AddListener(CargarEscena);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Transform cameraTransform = Camera.main.transform;
            Vector3 forward = cameraTransform.forward;
            Vector3 panelPosition = cameraTransform.position + forward * 1.5f; 
            panelUI.transform.position = panelPosition;

            
            panelUI.transform.LookAt(cameraTransform);
            panelUI.transform.Rotate(0, 180, 0); 

            panelUI.SetActive(true);
        }
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(sceneName);
    }
}

