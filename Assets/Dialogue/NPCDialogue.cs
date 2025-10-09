using System;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        npcText.enabled = true;
    }

    bool isShowingText = false;
    void Update()
    {
        if (raycastCam.hit.transform != null)
        {
            if (raycastCam.hitGameObject.CompareTag("NPC"))
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
                    Debug.Log(inkJSON.text);
                }

            }
            else if (!raycastCam.hitGameObject.CompareTag("NPC"))
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

    }



}
