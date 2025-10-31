using UnityEditor;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{
    [SerializeField] Transform objectGrabPointTransform;
    [SerializeField] RaycastForCam raycastForCam;

    private ObjectGrabbable objectGrabbable;
    // Update is called once per frame
    void Update()
    {
        // RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null)
            {
                // Not carrying an object, try to grab
                if (raycastForCam.didHit)
                {
                    if (raycastForCam.hit.transform.TryGetComponent<ObjectGrabbable>(out objectGrabbable))
                    {
                        Debug.Log("HELLO");
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                //Currently carying something, drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
