using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoodLogic : MonoBehaviour
{
    private GameObject player;
    private Attributes attributes;
    private GameObject food;
    public float foodAmount;
    public string gameObjectTag;
    private string objectName;
    private Vector3 randomPosition;
    private bool onNavmesh;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attributes = player.GetComponent<Attributes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            attributes.GettingFull(foodAmount);
            SpawnFood();
        }

        if (other.tag.Equals("Bot"))
        {
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        NavMeshHit Hit;
        randomPosition = new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100));
        onNavmesh = NavMesh.FindClosestEdge(randomPosition,out Hit, NavMesh.AllAreas);
        if (onNavmesh)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            objectName = gameObject.name;
            food = Instantiate(gameObject, Hit.position, rotation);
            Destroy(gameObject);
            food.GetComponent<FoodLogic>().enabled = true;
            food.name = objectName;
        }
        else
        {
            SpawnFood();
        }
    }
}
