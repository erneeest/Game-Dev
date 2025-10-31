using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    Interactable currentInteractable;

    [Header("Raycast")]
    [SerializeField] RaycastForCam raycastForCam;
    // Update is called once per frame
    void Update()
    {
        CheckInteraction();

        // CheckIfDialogueIsEnded();
        if (currentInteractable != null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();   
        }

    }

    void CheckInteraction()
    {

        //if colliders with anything within player reach
        if (!raycastForCam.didHit){
            DisableCurrentInteractable();
            return;
        }
            
        
            if (raycastForCam.hit.collider.CompareTag("ObjectInteractable"))//if looking at an interactable object
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

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;

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
}
