using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    private NavMeshSurface surface;
    [SerializeField] private int numObstacles;
    [SerializeField] private List<GameObject> obstaclePrefab;
    [SerializeField] private Vector2 randomPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        Baker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Baker()
    {
        for (int i = 0; i < numObstacles; i++) 
        {
            int prefabIndex = Random.Range(0, obstaclePrefab.Count);
            float xpos = Random.Range(randomPos.x, randomPos.y);
            float zpos = Random.Range(randomPos.x, randomPos.y);

            GameObject newObstacle = Instantiate(obstaclePrefab[prefabIndex]);
            newObstacle.transform.position = new Vector3(xpos, newObstacle.transform.position.y, zpos);
        }
        surface.BuildNavMesh();
    }
}
