using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }

    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //if colliders with anything within player reach
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.CompareTag("Interactable"))//if looking at an interactable object
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                //if there is a currentInteracable and it is not the newInteractable
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else//if new interactable is not enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else //if not an interactable
            {
                DisableCurrentInteractable();
            }
        }
        else //if nothing in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }
    
    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
