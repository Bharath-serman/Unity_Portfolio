using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Show_Panel : MonoBehaviour
{

    public GameObject BioPanel;
    public PlayableDirector director;
    public GameObject AccessDeniedButton;
    private bool ButtonStatus = false;
    public GameObject ExperiencePanels;  //For site scene's Experience.
    private bool PanelStatus = false;
    public Button closePanelbutton;
    void Start()
    {
        BioPanel.SetActive(false);
        director.stopped += OnTimelineStopped;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            //Show the Respective Panel.
            ExperiencePanels.SetActive(!PanelStatus);  //True.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Remove the Panels.
        ExperiencePanels.SetActive(PanelStatus); //False
    }

    public void closepanelonclick()
    {
        ClosedPanels();
    }

    void ClosedPanels()
    {
        ExperiencePanels.SetActive(false);
    }
}
