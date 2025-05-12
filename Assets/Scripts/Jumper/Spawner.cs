using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab = null;
    public Transform spawnpoint = null;
    public float min = 1.0f;
    public float max = 3.5f;
    void Start()
    {
        Invoke("Spawn", Random.Range(min, max));
    }

    private void Spawn()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z);
        Invoke("Spawn", Random.Range(min, max));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
