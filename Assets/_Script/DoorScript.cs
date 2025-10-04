using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Animator door;
    // public Animator door;
    public GameObject openText;

    public bool inReach;

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
        if (inReach && Input.GetButtonDown("Interact") && isOpen)
        {
            DoorOpen();
            isOpen = !isOpen;
        }
        else if (inReach && Input.GetButtonDown("Interact") && !isOpen)
        {
            DoorCloses();
            isOpen = !isOpen;
        }
        
    }

    void DoorOpen()
    {
        // Debug.Log("Door Open");
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }

    void DoorCloses()
    {
        // Debug.Log("Door Closes");
        door.SetBool("Open", false);
        door.SetBool("Close", true);
    }
}
