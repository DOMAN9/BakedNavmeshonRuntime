using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RatWalk : MonoBehaviour
{
    public NavMeshAgent rat;
    public float walkPointRange = 10f;
    private Vector3 walkPoint;
    private bool walkPointSet;



    [SerializeField] private LayerMask whatIsGround;

    private void Awake()
    {
        rat = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
        {
            rat.SetDestination(walkPoint);
            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        Vector3 potentialWalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(potentialWalkPoint + Vector3.up * 2f, Vector3.down, 3f, whatIsGround))
        {
            walkPoint = potentialWalkPoint;
            walkPointSet = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }
}
