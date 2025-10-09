using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] float range = 5f;
    public RaycastHit hit;
    public GameObject hitGameObject;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            hitGameObject = hit.transform.gameObject;
        }

        // Debug.DrawRay(transform.position, transform.forward * range, Color.red);

    }
}
