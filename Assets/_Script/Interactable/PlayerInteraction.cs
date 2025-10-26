using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Interactable currentInteractable;
    public bool isInDialogue = false;

    [Header("Raycast")]
    [SerializeField] RaycastForCam raycastForCam;
    // Update is called once per frame
    void Update()
    {
        CheckInteraction();

        // CheckIfDialogueIsEnded();
        if (currentInteractable != null && currentInteractable.isDialogueEnded)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null && !isInDialogue)
        {
            currentInteractable.Interact();
            currentInteractable.isDialogueEnded = true;         
        }

    }

    void CheckInteraction()
    {

        //if colliders with anything within player reach
        if (raycastForCam.didHit)
        {
            if (raycastForCam.hit.collider.CompareTag("Interactable"))//if looking at an interactable object
            {
                Interactable newInteractable = raycastForCam.hit.collider.GetComponent<Interactable>();

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

        if (isInDialogue)
        {
            currentInteractable.DisableOutline();
            HUDController.instance.DisableInteractionText();
            return;
        }

        // CheckIfDialogueIsEnded();
        if (currentInteractable != null && currentInteractable.isDialogueEnded)
        {
            return;
        }

        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
    
    void CheckIfDialogueIsEnded()
    {
        if (currentInteractable != null && currentInteractable.isDialogueEnded)
        {
            return;
        }
    }
}
