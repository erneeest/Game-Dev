using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Bob Settings")]
    public float bobSpeed = 10f;
    public float bobAmount = 0.05f;

    private float timer = 0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // detect if player is walking
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        bool isWalking = (x != 0 || z != 0);

        if (isWalking)
        {
            timer += Time.deltaTime * bobSpeed;
            float newY = startPos.y + Mathf.Sin(timer) * bobAmount;
            transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
        }
        else
        {
            timer = 0f; // reset bob
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 5f);
        }
    }
}
