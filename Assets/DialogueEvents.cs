using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class DialogueEvents : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] GameObject NPC;

    void Start()
    {
        dialogueRunner.onNodeComplete.AddListener(CustomFunction);
    }
    
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
}
