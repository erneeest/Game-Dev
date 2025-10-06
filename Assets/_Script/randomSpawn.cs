using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    [SerializeField] Transform objectPos;
    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        int randomSpawn = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawn].position;
    }

}
