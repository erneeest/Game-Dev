using Unity.Cinemachine;
using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] Camera cam;
    float raycastRange = 20f;
    public RaycastHit hit;
    public bool didHit = false;

    void Update()
    {
        CinemachineBrain brain = gameObject.GetComponent<CinemachineBrain>();

        if (brain != null && brain.ActiveVirtualCamera != null)
        {
            ICinemachineCamera activeCam = brain.ActiveVirtualCamera;

            // Get position and forward direction from the active Cinemachine camera state
            Vector3 camPos = activeCam.State.GetFinalPosition();
            Vector3 camForward = activeCam.State.GetFinalOrientation() * Vector3.forward;

            // Perform the raycast
            didHit = Physics.Raycast(camPos, camForward, out hit, raycastRange);

            // Draw debug ray
            Debug.DrawRay(camPos, camForward * raycastRange, didHit ? Color.red : Color.green);
        }
    }
}
