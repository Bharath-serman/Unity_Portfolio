using UnityEngine;
using DialogueEditor;

public class StartDialogue : MonoBehaviour
{
    //serialize field
    [SerializeField] public NPCConversation myconversation;

    //condition method
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            //keycode
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ConversationManager.Instance.StartConversation(myconversation);
            }
        }     
    }
}
