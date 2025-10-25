using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private BoxCollider boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
          objectRigidbody.MovePosition(objectGrabPointTransform.position);
        }
    }
}
