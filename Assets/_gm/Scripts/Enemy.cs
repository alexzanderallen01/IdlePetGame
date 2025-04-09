using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform _transformToFollow;
    public NavMeshAgent _navMeshAgent;

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(_transformToFollow.position);
    }
}
