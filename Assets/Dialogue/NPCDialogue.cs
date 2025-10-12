using System;
// using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [Header("NPC Visual Cue")]
    [SerializeField] TextMeshProUGUI npcText;
    [SerializeField] string NPCString;

    [Header("Raycast Detection")]
    [SerializeField] RaycastForCam raycastCam;


    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool isDialogueActive = false;

    bool isShowingText = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        npcText.enabled = true;
    }
    void Update()
    {
        if (raycastCam.hitGameObject != null && raycastCam.hitGameObject.GetComponent<NPCDialogue>() != null)
        {
            raycastCam.hitGameObject.GetComponent<NPCDialogue>().RunTrigger();
        }
    }
    
    void RunTrigger()
    {
        // Returns true or false
              if (DialogueManager.GetInstance().dialogueIsPlaying)
              {
                  isDialogueActive = true;
              }
              else
              {
                  isDialogueActive = false;
              }

        if (!isDialogueActive)
        {
            if (raycastCam.hitGameObject.GetComponent<NPCDialogue>() != null)
            {
                if(isShowingText == false)
                {   
                    npcText.SetText(NPCString);
                    isShowingText = true;
                }

                if (isDialogueActive)
                {
                    return;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isDialogueActive = true;
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
                
            }
            else if(raycastCam.hitGameObject.GetComponent<NPCDialogue>())
            {
                npcText.SetText("");
                isShowingText = false;
            }
        }
        else
        {
                npcText.SetText("");
                isShowingText = false;
        }

        Debug.Log(isDialogueActive);
    }
}
