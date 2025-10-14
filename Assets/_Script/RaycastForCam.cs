using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] float range = 5f;
    public RaycastHit hit;
    public GameObject hitGameObject;

    [SerializeField] TextMeshProUGUI npcText;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            hitGameObject = hit.transform.gameObject;
            CheckInteract();
        }

        // Debug.DrawRay(transform.position, transform.forward * range, Color.red);
    }

    void CheckInteract()
    {
        if(hit.transform.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact();
        }
        else
        {
            npcText.text = "";
        }
    }
}
