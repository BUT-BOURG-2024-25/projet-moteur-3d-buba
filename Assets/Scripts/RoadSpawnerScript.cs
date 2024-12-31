using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    public static RoadSpawnerScript instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] GameObject Road_Tile;
    [SerializeField] Transform spawn_Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnRoad()
    {
        Instantiate(Road_Tile, spawn_Pos.position, Quaternion.identity);
        spawn_Pos.position = new Vector3(spawn_Pos.transform.position.x, spawn_Pos.transform.position.y, spawn_Pos.transform.position.z + 58.45f);
    }

    private void OnDestroy()
    {
        Destroy(instance);
    }
}
