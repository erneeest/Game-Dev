using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] Animator door;
    [SerializeField] GameObject openText;

    [SerializeField] bool inReach;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inReach = false;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Reach"))
        {
            openText.SetActive(true);
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Reach"))
        {
            openText.SetActive(false);
            inReach = false;
        }
    }

    bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && !isOpen)
        {
            DoorOpen(true);
            isOpen = !isOpen;
        }
        else if (inReach && Input.GetButtonDown("Interact") && isOpen)
        {
            DoorOpen(false);
            isOpen = !isOpen;
        }
    }

    void DoorOpen(bool isOpen)
    {
        // Debug.Log("Door Open");
        door.SetBool("Open", isOpen);
    }
}
