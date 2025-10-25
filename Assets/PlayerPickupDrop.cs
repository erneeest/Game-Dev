using UnityEditor;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform objectGrabPointTransform;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
            {
                if (hit.transform.TryGetComponent<ObjectGrabbable>(out ObjectGrabbable objectGrabbable))
                {
                    Debug.Log("HELLO");
                    objectGrabbable.Grab(objectGrabPointTransform);
                }
            }
        }
    }
}
