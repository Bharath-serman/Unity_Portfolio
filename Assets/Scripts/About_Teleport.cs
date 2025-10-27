using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About_Teleport : MonoBehaviour
{
    [Header("Button Settings")]
    public GameObject AboutInButton;
    private bool isactive = false;
    void Start()
    {
       if(AboutInButton != null)
        {
            AboutInButton.SetActive(isactive); //Button disappears.
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AboutInButton.SetActive(!isactive);  //True.
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AboutInButton.SetActive(!isactive);  //True.
        }
    }

    public void OnTriggerExit(Collider other)
    {
        AboutInButton.SetActive(false); //Disappears once the player leaves the collider.
    }

    public void loadscene()
    {
        sceneloadmanager();
        Debug.Log("Scene_Loaded");
    }

    void sceneloadmanager()
    {
        SceneManager.LoadScene("About");  
    }
}
