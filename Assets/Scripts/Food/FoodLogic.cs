using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoodLogic : MonoBehaviour
{
    private GameObject player;
    private Attributes attributes;
    private GameObject food;
    public float FoodAmount;
    public string GameObjectTag;
    private string objectName;
    private Vector3 randomPosition;
    private bool isOnNavmesh;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attributes = player.GetComponent<Attributes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            attributes.GettingFull(FoodAmount);
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
        //isOnNavmesh = NavMesh.FindClosestEdge(randomPosition,out Hit, NavMesh.AllAreas);
        isOnNavmesh = NavMesh.SamplePosition(randomPosition,out Hit, 2f, NavMesh.AllAreas);
        if (isOnNavmesh)
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
