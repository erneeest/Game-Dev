using UnityEngine;

public class RaycastForCam : MonoBehaviour
{
    [SerializeField] float range = 5f;
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            // hit.transform.gameObject.SetActive
        }

        Debug.DrawRay(transform.position, transform.forward * range, Color.red);

    }
}
