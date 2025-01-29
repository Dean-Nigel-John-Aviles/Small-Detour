using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    //Naming of Player and Enemy Nav
    private Transform player;
    private NavMeshAgent agent;

    //Bool for Following
    public bool FC;

    //EnemyAnimation
    private Rigidbody rb;
    private Animator anim;

    //Player
    public float followDistance = 10f;

    //Waypoint
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
   

    private void Awake()
    { 
        player = GameObject.Find("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        WaypointFollower();
    }

    // Update is called once per frame
    void Update()
    {
        if (FC == true)
        {
            FollowPlayer();
        }
        if (FC == false)
        {
            WaypointFollower();
            if (Vector3.Distance(transform.position, target) < 2)
            {
                IterateWaypointIndex();
            }
        }
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) < followDistance)
            {
                agent.SetDestination(player.position);
            }

            if (rb.velocity.magnitude > 2f)
            {
                anim.SetTrigger("IsMoving");
            }
        }
        else
        {
            Debug.Log("Player is Missing!");
        }
    }

    private void WaypointFollower()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);

        if (rb.velocity.magnitude > 0.5f)
        {
            anim.SetTrigger("IsMoving");
        }
    }

    private void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
