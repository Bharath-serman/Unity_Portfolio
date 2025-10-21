using UnityEngine;
using UnityEngine.UI;

public class ProjectTeleport : MonoBehaviour
{
    [Header("Project Teleport Customization")]
    public GameObject projectbutton; //Get the button

    //public Camera cam;
    [Header("Teleportation Settings")]
    public Transform player;

    public Transform targetpos;  //Target position.

    public void Start()
    {
        //Disable the button if enabled.
        projectbutton.SetActive(false);  //False.
    }

    private void OnTriggerEnter(Collider projectcollider)
    {
        projectbutton.SetActive(true);
    }

    private void OnTriggerStay(Collider Projectcollider)
    {
        //Debug.Log("In the collider");
        if (Projectcollider.CompareTag("Player"))
        {
            ShowButton();  //True.
        }
        
    }
    void ShowButton()
    {
        projectbutton.SetActive(true);  //True.
    }

    private void OnTriggerExit(Collider projectcollider)
    {
        projectbutton.SetActive(false);
    }
    public void teleport()
    {
        if (player != null && targetpos != null)
        {
           Debug.Log("Teleport completed");
        }
        
        CharacterController cc = player.GetComponent<CharacterController>();
        if(cc != null)  cc.enabled = false;

            player.position = targetpos.position;
            player.rotation = targetpos.rotation;

        if(cc != null) cc.enabled = true;

        Disappear();
        
    }

    void Disappear()
    {
        projectbutton.SetActive(false);  //Disappears the button once teleport completed.
    }
}
