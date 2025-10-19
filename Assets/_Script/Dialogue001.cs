using System.Collections;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class Dialogue001 : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] TextMeshProUGUI dialogue;
    [SerializeField] string dialogueText;
    [SerializeField] float timer;

    void Start()
    {
        dialogue.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // dialogue.enabled = true;
            // dialogue.text = dialogueText.ToString();
            // StartCoroutine(DisableText());
            Destroy(gameObject);
            dialogueRunner.StartDialogue("Nanay");
        }

    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        dialogue.enabled = false;
        Destroy(gameObject);
    }
}
