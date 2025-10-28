using UnityEngine;
using DialogueEditor;
//using UnityEngine.UI;

public class StartDialogue : MonoBehaviour
{
    //serialize field
    [SerializeField] public NPCConversation myconversation;
    public GameObject ButtonText; 

    public void Start()
    {
        ButtonText.SetActive(false);
    }

    //condition method

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.CompareTag("Player"))
        {
            ButtonText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            //keycode
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DisappearText();
                ConversationManager.Instance.StartConversation(myconversation);
            }
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        DisappearText();
    }

    void DisappearText()
    {
        ButtonText.SetActive(false);
    }
}
