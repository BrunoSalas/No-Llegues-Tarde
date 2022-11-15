using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public List<GameObject> obstacles;
    private float offset = 72f; 
    private int lastSpawnZ = 80;
    [SerializeField]
    Transform player;

    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
        Obstacule();
    }

    public void Obstacule()
    {
        lastSpawnZ += (int) player.position.z;

       GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
        /*GameObject obstacle = obstacles[0];Debug.Log(obstacle);
        obstacles.Remove(obstacle);
        float newZ = obstacles[obstacles.Count - 1].transform.position.z + offset;
        obstacle.transform.position = new Vector3(0, 0, newZ); Debug.Log(obstacle.transform.position);
        obstacles.Add(obstacle);*/
        Instantiate(obstacle, new Vector3(0, 0, lastSpawnZ), obstacle.transform.rotation);
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
