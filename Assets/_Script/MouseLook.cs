using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] float mouseSens = 100f;

    [SerializeField] Transform playerBody;
    // [SerializeField] Transform playerCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        // Debug.Log(mouseX);
        // Debug.Log(mouseY);

    }
}
