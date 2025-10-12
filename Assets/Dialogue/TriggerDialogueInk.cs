using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerDialogueInk : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

}
