using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class DialogueEvents : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] GameObject NPC;

    [SerializeField] PlayerInteraction playerInteraction;

    void Start()
    {
        // dialogueRunner.onNodeComplete.AddListener(CustomFunction);
    }

    //when interacted with the NPC
    public void CustomStartDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);

    }

    //OnNodeComplete
    void CustomFunction(string node)
    {
        if (node == "Dog")
        {
            StartCoroutine(delay());
            Debug.Log(node);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        NPC.SetActive(true);
    }

        //On every node that started, disable [E]
    public void DisableInteractWhenStartDialoguue(string node)
    {
        playerInteraction.isInDialogue = true;
    }
    public void EnableInteractWhenStartDialogue(string node)
    {
        playerInteraction.isInDialogue = false;        
    }

}
