using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationSystem : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        speed = agent.speed;
        animator.SetFloat("Speed", speed);
    }
}
