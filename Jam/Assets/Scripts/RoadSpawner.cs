using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public List<GameObject> obstacles;
    private float offset = 72f; 
    public float lastSpawnZ ;
    public GameObject[] a;
    [SerializeField]
    Transform player;
    public bool spawnObstacles;
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
        Obstacule();
    }
    private void Update()
    {

        a = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    public void Obstacule()
    {
        if (spawnObstacles)
        {
            float z;
            z = lastSpawnZ + player.position.z;
            Debug.Log(z);

            GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
            /*GameObject obstacle = obstacles[0];Debug.Log(obstacle);
            obstacles.Remove(obstacle);
            float newZ = obstacles[obstacles.Count - 1].transform.position.z + offset;
            obstacle.transform.position = new Vector3(0, 0, newZ); Debug.Log(obstacle.transform.position);
            obstacles.Add(obstacle);*/
            Instantiate(obstacle, new Vector3(0, 0, z), obstacle.transform.rotation);
            spawnObstacles = false;
        }
    }


    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
    }
}
