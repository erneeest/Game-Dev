using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float raycastRange = 3f;
    public RaycastHit hit;
    public bool didHit = false;

    void Update()
    {
        didHit = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, raycastRange);
    } 
}
