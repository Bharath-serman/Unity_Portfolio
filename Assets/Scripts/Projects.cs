using UnityEngine;
using UnityEngine.UI;

public class Projects : MonoBehaviour
{
    [Header("Project_URL_Buttons")]
    public Button project1;  //AR_portal.
    public Button project2;  //VR_Builder.
    public Button project3;  //VR Black_Hole.
    public Button project4;  //Cassiora.
    public Button project5;  //Drive_Link.

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

    public void navigate3()
    {
        Application.OpenURL("https://github.com/Bharath-serman/VR_BLACK_HOLE");
        Debug.Log("Opened URL-3");
    }

    public void navigate4()
    {
        Application.OpenURL("https://github.com/Bharath-serman/Cassiora");
        Debug.Log("Opened URL-4");
    }

    public void navigate5()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1vaEnhpUqaJqcC7a07x_cpO9LhhJ3VcbF?usp=sharing");
        Debug.Log("Opened URL-5");
    }
}
