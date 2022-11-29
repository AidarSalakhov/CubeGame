using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationSystem : MonoBehaviour
{
    private Animator animator;
    public float Speed;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Speed = agent.desiredVelocity.magnitude;
        animator.SetFloat("Speed", Speed);
    }
}
