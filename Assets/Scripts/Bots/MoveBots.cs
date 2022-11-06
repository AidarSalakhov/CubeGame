using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBots : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3[] foodArray;
    private GameObject food;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        foodArray = new Vector3[3];
        food = GameObject.FindGameObjectWithTag("FoodSmall");
        foodArray[0] = food.transform.position;
        food = GameObject.FindGameObjectWithTag("FoodMedium");
        foodArray[1] = food.transform.position;
        food = GameObject.FindGameObjectWithTag("FoodLarge");
        foodArray[2] = food.transform.position;
        agent.SetDestination(GetClosestFood(foodArray));
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
