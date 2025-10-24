using System.Collections;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogueEvents : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] GameObject NPC;

    [SerializeField] PlayerInteraction playerInteraction;

    [Header("Thunder Effect")]
    [SerializeField] Camera cam;
    [SerializeField] GameObject lightning;
    [SerializeField] AudioSource lightingSound;

    [Header("Player Movement")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] HeadBob headBob;
    void Start()
    {
        // dialogueRunner.onNodeComplete.AddListener(CustomFunction);
        dialogueRunner.onNodeComplete.AddListener(AfterDialogue); // Adding listener
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

    //test thunder
    void AfterDialogue(string node) // this will happen the node's done
    {
        if (node == "Nanay")
        {
            cam.backgroundColor = Color.white;
            lightingSound.Play();
            lightning.SetActive(true);
            StartCoroutine(ThunderForSec());
        }
    }
    IEnumerator ThunderForSec()
    {
        yield return new WaitForSeconds(0.2f);
        lightning.SetActive(false);
        cam.backgroundColor = Color.black;
    }

    //Movement 
    public void StopMovement()
    {
        playerMovement.enabled = false;
        headBob.enabled = false;
    }

    public void GoMovement()
    {
        playerMovement.enabled = true;
        headBob.enabled = false;
    }


}
