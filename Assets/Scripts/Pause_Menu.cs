using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [Header("UI_Buttons")]
    public Button PauseButton; //Assign the pause button.
    public Button closebutton; //Quit/Close Button.
    public Button dropdownbutton;
    public Button resumebutton;
    public Button teleportbutton;
    public Button quitbutton;
    [Header("UI_Images")]
    public Image PauseImage; //Assign the Menu / Panel.
    public GameObject Dropdownimage;
    [Header("UI_GameObject")]
    public GameObject Panel;

    private bool isActive = true;

    private void Start()
    {
        PauseImage.gameObject.SetActive(!isActive); //False.
        Dropdownimage.SetActive(!isActive);
    }

    public void EnableMenu()
    {
        ShowMenu();
    }
    
    void ShowMenu()
    {
        if (PauseButton == null || PauseImage == null)
        {
            Debug.Log("Button not assigned");  //Shows Error.
        }

        //Show the menu
        PauseImage.gameObject.SetActive(isActive);
        Time.timeScale = 0f;

        //CloseImage();
    }

    public void CloseImage()
    {
         PauseImage.gameObject.SetActive(false);   //Closes the menu.
    }

    public void resume()
    {
        PauseImage.gameObject.SetActive(false); //Closes.
        Time.timeScale = 1f;
    }  
    
    public void openPanel()
    {
        //PauseImage.gameObject.SetActive(false);
        Panel.SetActive(false);
        Dropdownimage.SetActive(true);
    }

    public void showchoices()
    {
        Panel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
            Time.timeScale = 0f;  //Freeze the game once it is paused.
        }
    }

    public void CloseDrawImage()
    {
        Dropdownimage.SetActive(false);
        PauseImage.gameObject.SetActive(true);   
    }

    public void quit()
    {
        //Close the application.
        Application.Quit();
    }
}
