using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Transform centerPoint; // Center point of the area around which the enemy patrols
    public float patrolRadius = 7f; // Radius of the patrol area
    public float patrolSpeed = 4f; // The speed at which the enemy patrols
    public float rotationSpeed = 100f; // The speed at which the enemy rotates
    public float chaseRange = 10f; // The range at which the enemy starts chasing the player
    public float chaseSpeed = 5f; // The speed at which the enemy chases the player
    public float waypointTolerance = 0.2f; // Distance tolerance to consider reaching a waypoint

    private Vector3[] patrolWaypoints;
    private int currentWaypointIndex = 0;
    private Rigidbody enemyRigidbody;
    private bool isChasing = false;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        CreatePatrolWaypoints();
    }

    private void CreatePatrolWaypoints()
    {
        // Calculate patrol waypoints evenly distributed around the center point
        int numWaypoints = 8; // Adjust this based on how many waypoints you want
        patrolWaypoints = new Vector3[numWaypoints];

        for (int i = 0; i < numWaypoints; i++)
        {
            float angle = i * 360f / numWaypoints;
            float radians = angle * Mathf.Deg2Rad;
            Vector3 waypointPosition = centerPoint.position + new Vector3(
                Mathf.Cos(radians) * patrolRadius,
                0f,
                Mathf.Sin(radians) * patrolRadius
            );
            patrolWaypoints[i] = waypointPosition;
        }
    }

    private void Update()
    {
        // Check if the player is within the chase range
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Rotate towards the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the enemy towards the player
            enemyRigidbody.velocity = transform.forward * chaseSpeed;
        }
        else
        {
            // Check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, patrolWaypoints[currentWaypointIndex]) < waypointTolerance)
            {
                // Reached the current waypoint, so move to the next one
                currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Length;
            }

            // Rotate towards the current waypoint
            Vector3 directionToWaypoint = (patrolWaypoints[currentWaypointIndex] - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToWaypoint);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the enemy forward
            enemyRigidbody.velocity = transform.forward * patrolSpeed;
        }
    }
}