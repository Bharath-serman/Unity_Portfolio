using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProjectTeleport : MonoBehaviour
{
    [Header("Project Teleport Customization")]
    public GameObject projectbutton; //Get the button
    public GameObject ExitProjectButton;
    public GameObject AboutInButton;
    public enum teleportType { Entering , Exiting };
    public teleportType type;
    public Pause_Menu menus;
    //public Camera cam;
    [Header("Teleportation Settings")]
    public Transform player;

    public CharacterController cc;

    public Transform initialpos;  //Initial position.

    public Transform targetpos;  //Target position.

    public void Start()
    {
        cc = player.GetComponent<CharacterController>();
        //Disable the button if enabled.
        projectbutton.SetActive(false);  //False.
        ExitProjectButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider projectcollider)
    {
        if (projectcollider.CompareTag("Player"))
        {
            if(type == teleportType.Entering)
            {
                ShowButton();
                ExitProjectButton.SetActive(false);
            }
            else if(type == teleportType.Exiting)
            {
                ShowExitButton();
                projectbutton.SetActive(false);
            }

        }
        
    }

    private void OnTriggerStay(Collider named)
    {
        if (named.CompareTag("Player"))
        {
            if (type == teleportType.Entering)
            {
                ShowButton();
                ExitProjectButton.SetActive(false);
            }
            else if (type == teleportType.Exiting)
            {
                ShowExitButton();
                projectbutton.SetActive(false);
            }

        }
    }
    void ShowButton()
    {
        projectbutton.SetActive(true);  //True.
    }

    void ShowExitButton()
    {
        ExitProjectButton.SetActive(true);
    }

    private void OnTriggerExit(Collider projectcollider)
    {

        if (projectcollider.CompareTag("Player"))
        {
            projectbutton.SetActive(false);
            ExitProjectButton.SetActive(false);
        }
        
    }

    public void GeneralEnter()
    {
        projectbutton.SetActive(false);
        Enter();
    }

    private void Enter()
    {

        //menus.RemoveEverything();  

        if (player != null && targetpos != null)
        {
            Debug.Log("Entered");
        }

        //CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.position = targetpos.position;
        player.rotation = targetpos.rotation;

        if (cc != null) cc.enabled = true;

        Disappear();
    }
    public void MenuEnter()
    {

        menus.RemoveEverything();  //Referencing from the Pause_Menu script.
        
        if (player != null && targetpos != null)
        {
           Debug.Log("Entered");
        }
        
        //CharacterController cc = player.GetComponent<CharacterController>();
        if(cc != null)  cc.enabled = false;

            player.position = targetpos.position;
            player.rotation = targetpos.rotation;

        if(cc != null) cc.enabled = true;

        Disappear();
        
    }

    public void Exit()
    {

        if(player != null && initialpos != null)
        {
            Debug.Log("Exited");
        }

        //Check for characterController
        if(cc!= null) cc.enabled = false;
            
            player.position = initialpos.position;
            player.rotation = initialpos.rotation;
        if(cc != null)
        {
            cc.enabled = true;
        }

        exitDisappear();  //Exit Button to disappear.
        
    }

    void Disappear()
    {
        projectbutton.SetActive(false);  //Disappears the button once teleport completed.
    }

    void exitDisappear()
    {
        ExitProjectButton.SetActive(false);
    }

    public void LoadAboutScene()
    {
        menus.RemoveEverything();
        AboutInButton.SetActive(false);
        SceneManager.LoadScene("About");
        Debug.Log("The Scene Loaded");
    }
}
