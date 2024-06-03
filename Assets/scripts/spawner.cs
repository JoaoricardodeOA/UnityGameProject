using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public int spawnCount = 0;
    public float acceleration = 0;

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
    }
    public void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        Pipes script = pipes.GetComponent<Pipes>();

        script.speed = script.speed + acceleration;
        acceleration += 0.1f;
        spawnRate += 1f;
        spawnCount++;
        
      
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
