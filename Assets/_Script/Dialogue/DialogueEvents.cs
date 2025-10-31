using System.Collections;
using Unity.Cinemachine;
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

    [Header("Mouse Look")]
    [SerializeField] MouseLook mouseLook;

    [Header("Player Movement")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] HeadBob headBob;

    [Header("Cinemachine Brain")]
    [SerializeField] CinemachineBrain cinemachineBrain;
    private CinemachineCamera currentCam;
    private CinemachineCamera prioCam;

    void Start()
    {
        // dialogueRunner.onNodeComplete.AddListener(CustomFunction);
        dialogueRunner.onNodeComplete.AddListener(AfterDialogue); // Adding listener
    }

    //=========================================================== Start a dialogue in the interactable
    public void CustomStartDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);
        mouseLook.enabled = false;
    }
    public void CustomEndDialogue(string node)
    {
        prioCam.Priority.Value = 0;
        mouseLook.enabled = true;
        currentCam.Priority.Value = 999;
    }
    

    public void LookAtInteract(CinemachineCamera priorityCam)
    {
        currentCam = cinemachineBrain.ActiveVirtualCamera as CinemachineCamera;
        prioCam = priorityCam;
 
        if (currentCam != null)
        {
            currentCam.Priority.Value = 0;
        }

        if (priorityCam != null)
        {
            priorityCam.Priority.Value = 999; // make it the active camera
        }
    }

    //=========================================================== onNodeComplete functions

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
    
    //=========================================================== Fix in Dialogue
    //On every node that started, disable [E]
    public void DisableInteractWhenStartDialoguue(string node)
    {
        playerInteraction.isInDialogue = true;
    }
    public void EnableInteractWhenStartDialogue(string node)
    {
        playerInteraction.isInDialogue = false;
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
