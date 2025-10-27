using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About_Teleport : MonoBehaviour
{
    [Header("Button Settings")]
    public GameObject AboutInButtons;
    private bool isactive = false;
    public void Start()
    {   
         AboutInButtons.SetActive(false); //Button disappears.
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AboutInButtons.SetActive(!isactive);  //True.
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AboutInButtons.SetActive(!isactive);  //True.
        }
    }

    public void OnTriggerExit(Collider other)
    {
        AboutInButtons.SetActive(false); //Disappears once the player leaves the collider.
    }

    public void loadscene()
    {
        SceneManager.LoadScene("About");
    }
}
