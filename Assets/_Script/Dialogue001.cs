using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Dialogue001 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogue;
    [SerializeField] string dialogueText;
    [SerializeField] float timer;
    [SerializeField] DialogueRunner dialogueRunner;

    void Start()
    {
        dialogue.enabled = false;
        dialogueRunner.onNodeComplete.AddListener(CustomFunction);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // dialogue.enabled = true;
            // dialogue.text = dialogueText.ToString();
            // StartCoroutine(DisableText());
            dialogueRunner.StartDialogue("Nanay");
        }

    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        dialogue.enabled = false;
        Destroy(gameObject);
    }

    void CustomFunction(string node)
    {
        if(node == "Nanay")
        {
            Debug.Log("Hi");
            Debug.Log(node);
        }
    }

}
