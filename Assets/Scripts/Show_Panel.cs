using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Show_Panel : MonoBehaviour
{
    #region Inputs
    public GameObject BioPanel;
    public PlayableDirector director;
    public GameObject AccessDeniedButton;
    private bool ButtonStatus = false;
    [SerializeField] public GameObject ExperiencePanels;  //For site scene's Experience.
    private bool PanelStatus = false;
    [SerializeField] public Button closePanelbutton;
    public GameObject MiniMap;
    #endregion
    void Start()
    {
        BioPanel.SetActive(false);
        director.stopped += OnTimelineStopped;
        //ExperiencePanels.SetActive(PanelStatus); 
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        if (pd == director && BioPanel != null)
        {
            BioPanel.SetActive(true);
        }
        else
        {
            Debug.Log("No timeline found");
        }
    }

    public void PlayDirectorOnClick()
    {
        //Play the director when the button click happens
        if (director != null && BioPanel != null)
        {
            director.Play();
            OnTimelineStopped(director);
        }
        else
        {
            Debug.Log("Failed to run");
        }
            AccessDeniedButton.SetActive(ButtonStatus);
        BioPanel.SetActive(ButtonStatus);
    }

    public void BacktoSite()
    {
        SceneManager.LoadScene("Site");
    }

    #region Project_Panel_Logic
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            //Show the Respective Panel.
            ExperiencePanels.SetActive(!PanelStatus);  //True.

            //Disable the pause button and the BG time.
            Pause_Menu.Instance.PauseButton.gameObject.SetActive(PanelStatus);  //False.
            Time.timeScale = 0f;  //Pause the time.
            MiniMap.SetActive(PanelStatus);  //False.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Remove the Panels.
        ExperiencePanels.SetActive(PanelStatus); //False

        //Enable the pause button and the BG time.
        Pause_Menu.Instance.PauseButton.gameObject.SetActive(!PanelStatus);  //True.
        Time.timeScale = 1f;  //Resume the time.
        MiniMap.SetActive(!PanelStatus);  //True.
    } 
    #endregion

    public void closepanelonclick()
    {
        ClosedPanels();
    }

    void ClosedPanels()
    {
        Time.timeScale = 1f;  //Resume the time.
        ExperiencePanels.SetActive(false);
        MiniMap.SetActive(!PanelStatus);  //True.
    }
}
