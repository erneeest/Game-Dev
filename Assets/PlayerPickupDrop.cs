using UnityEditor;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform objectGrabPointTransform;
    [SerializeField] RaycastForCam raycastForCam;

    // Update is called once per frame
    void Update()
    {
        // RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 20f)
            if (raycastForCam.didHit)
            {
                if (raycastForCam.hit.transform.TryGetComponent<ObjectGrabbable>(out ObjectGrabbable objectGrabbable))
                {
                    Debug.Log("HELLO");
                    objectGrabbable.Grab(objectGrabPointTransform);
                }
            }
        }
    }
}
