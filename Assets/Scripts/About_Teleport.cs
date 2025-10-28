using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About_Teleport : MonoBehaviour
{
    [Header("Button Settings")]
    public GameObject AboutInButtons;
    private bool isactive = false;
    public Animator animator;
    public float fadeDuration = 2f;
    public void Start()
    {
         animator.enabled = false;
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
        StartCoroutine(PlayFadeAndLoadScene("About"));
    }

    private System.Collections.IEnumerator PlayFadeAndLoadScene(string sceneName)
    {
        animator.enabled = true;
        animator.Play("Scene_Transition");

        // Wait for the fade animation to finish
        yield return new WaitForSeconds(fadeDuration);

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}
