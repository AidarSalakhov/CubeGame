using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBots : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3[] foodPositionArray;
    private GameObject[] foodArray;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        foodPositionArray = new Vector3[3];
        foodArray = new GameObject[3];

        for (int i = 0; i < foodArray.Length; i++)
        {
            foodArray = GameObject.FindGameObjectsWithTag("Food");
            foodPositionArray[i] = foodArray[i].transform.position;
        }

        agent.SetDestination(GetClosestFood(foodPositionArray));
    }

    private Vector3 GetClosestFood(Vector3[] food)
    {
        Vector3 tMin = new Vector3(0,0,0);
        float minDist = Mathf.Infinity;
        Vector3 botPosition = transform.position;
        foreach (Vector3 foodPosition in food)
        {
            float dist = Vector3.Distance(foodPosition, botPosition);
            if (dist < minDist)
            {
                tMin = foodPosition;
                minDist = dist;
            }
        }
        return tMin;
    }
}
