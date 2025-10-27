using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Show_Panel : MonoBehaviour
{

    public GameObject BioPanel;
    public PlayableDirector director;
    public GameObject AccessDeniedButton;
    private bool ButtonStatus = false;
    void Start()
    {
        BioPanel.SetActive(false);
        director.stopped += OnTimelineStopped;
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        if( pd == director && BioPanel != null)
        {
            BioPanel.SetActive(true);
        }
    }

    public void PlayDirectorOnClick()
    {
        //Play the director when the button click happens
        if(director != null)
        {
            director.Play();
            OnTimelineStopped(director);
        }
        AccessDeniedButton.SetActive(ButtonStatus);
        BioPanel.SetActive(ButtonStatus);
    }

    public void BacktoSite()
    {
        SceneManager.LoadScene("Site");
    }
}
