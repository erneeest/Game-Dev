using System;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [Header("NPC Visual Cue")]
    [SerializeField] TextMeshProUGUI npcText;
    [SerializeField] string NPCString;

    [Header("Raycast Detection")]
    [SerializeField] RaycastForCam raycastCam;
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
            if (raycastCam.hit.transform.gameObject.CompareTag("NPC") && !isShowingText)
            {
                npcText.SetText(NPCString);
                isShowingText = true;
            }
            else if (!raycastCam.hit.transform.gameObject.CompareTag("NPC") && isShowingText)
            {
                npcText.SetText("");
                isShowingText = false;
            }
            Debug.Log(raycastCam.hit.transform.gameObject.tag);
        }
        else
        {
                npcText.SetText("");
                isShowingText = false;
        }

    }



}
