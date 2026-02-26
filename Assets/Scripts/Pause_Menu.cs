using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [Header("UI_Buttons")]
    public Button PauseButton; 
    public Button closebutton; //Quit/Close Button.
    public Button dropdownbutton;
    public Button resumebutton;
    public Button teleportbutton;
    public Button quitbutton;
    public Button optionsbutton;
    [Header("UI_Images")]
    public GameObject PauseImage;
    public GameObject Dropdownimage;
    public GameObject Optionsimage;
    [Header("UI_GameObject")]
    public GameObject Panel;

    private bool isActive = true;
    private bool Ispressed = true;  //For Pause Window
    private bool ActivePanel = false;

    private void Start()
    {
        PauseImage.gameObject.SetActive(!isActive); //False.
        Dropdownimage.SetActive(!isActive);
        Optionsimage.SetActive(!isActive);
    }

    public void EnableMenu()
    {

        if (Optionsimage.activeSelf)
        {
            Optionsimage.SetActive(false);
            PauseImage.SetActive(true);
            return;
        }
        if (Dropdownimage.activeSelf)
        {
            Dropdownimage.SetActive(false);
        }
        if (PauseImage.activeSelf)
        {
            return;
        }
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
        if (ActivePanel == false)
        {
            Panel.SetActive(true);  //True.
            ActivePanel = true;  //True.
        }
        else if (ActivePanel == true)
        {
            Panel.SetActive(false);
            ActivePanel = false;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Optionsimage.activeSelf)
            {
                Optionsimage.SetActive(false);
                PauseImage.SetActive(true);
                return;
            }
            if (Dropdownimage.activeSelf)
            {
                Dropdownimage.SetActive(false);
                PauseImage.SetActive(true);
                return;
            }
            if (Ispressed)
            {
                Ispressed = false;
                ShowMenu();
            }
            else
            {
                RemoveEverything();
                Ispressed = true;
            }
        }
    }

    public void CloseDrawImage()
    {
        Dropdownimage.SetActive(false);
        PauseImage.SetActive(true);   
    }

    public void quit()
    {
        //Close the application.
        Debug.Log("Quitted");
        Application.Quit();
    }

    public void RemoveEverything()
    {
        PauseImage.SetActive(false);
        Dropdownimage.SetActive(false);
        //Resume the game.
        Time.timeScale = 1f;
    }

    public void openoptions()
    {
        //Enable the options.
        PauseImage.SetActive(false);
        Optionsimage.SetActive(true);
    }

    public void closeOptions()
    {
        Optionsimage.SetActive(false);
        PauseImage.SetActive(true);
    }
}
