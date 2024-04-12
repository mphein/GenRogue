using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToadMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.transform.LookAt(player.transform.position);
        agent.SetDestination(player.transform.position);
    }
}
