using UnityEngine;
using UnityEngine.UI;

public class Projects : MonoBehaviour
{
    [Header("Project_URL_Buttons")]
    public Button project1;  //AR_portal.
    public Button project2;  //VR_Builder.

    public void navigate1()
    {
        //Opens the URL
        Application.OpenURL("https://github.com/Bharath-serman/AR_Portal");
        Debug.Log("Opened URL-1");
    }

    public void navigate2()
    {
        Application.OpenURL("https://github.com/Bharath-serman/VR_Builder_Sample_Game");
        Debug.Log("Opened URL-2");
    }
}
