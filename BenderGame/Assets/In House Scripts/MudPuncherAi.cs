using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent agent;
    public Transform player;

    [Header("Detection Settings")]
    public float detectionRange = 15f;
    public float viewAngle = 60f; 
    public float chaseRange = 10f;
    public float meleeAttackRange = 4f;
    public float attackCooldown = 3.5f;

    [Header("Debug")]
    public bool playerDetected = false;

    private float lastAttackTime = 0f;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Vision cone check
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        bool inView = distance <= detectionRange && angleToPlayer <= viewAngle;

        // Detect player
        if (!playerDetected && inView)
        {
            playerDetected = true;
            Debug.Log("Player detected in vision cone!");
        }
        else if (playerDetected && distance > detectionRange + 5f)
        {
            playerDetected = false;
            Debug.Log("Lost sight of player.");
            StopChasing();
        }

        // Behavior
        if (playerDetected)
        {
            if (distance <= attackRange)
                AttackPlayer();
            else if (distance <= chaseRange)
                ChasePlayer();
            else
                StopChasing();
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void StopChasing()
    {
        agent.isStopped = true;
    }

    void meleeAttackPlayer()
    {
        agent.isStopped = true;
        transform.LookAt(player);

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Enemy punches the player!");
            lastAttackTime = Time.time;
        }
    }

    // 🧭 Draw vision cone & ranges for debugging
    void OnDrawGizmosSelected()
    {
        if (playerDetected) Gizmos.color = Color.red;
        else Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw vision cone
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle, 0) * transform.forward;
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * detectionRange);
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * detectionRange);
    }
}