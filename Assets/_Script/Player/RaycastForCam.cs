using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] Camera cam;
    float raycastRange = 20f;
    public RaycastHit hit;
    public bool didHit = false;

    void Update()
    {
        didHit = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, raycastRange);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * raycastRange, Color.green);
    } 
}
