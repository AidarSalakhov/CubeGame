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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attributes = player.GetComponent<Attributes>();
        randomPosition = new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100));
        transform.position = randomPosition;
    }

    private void Update()
    {

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
        randomPosition = new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100));

        if (RandomPoint(Vector3.zero, 0f, out randomPosition))
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
        objectName = gameObject.name;
        food = Instantiate(gameObject, randomPosition, rotation);
        Destroy(gameObject);
        food.GetComponent<FoodLogic>().enabled = true;
        food.name = objectName;
        }
        
    }

  
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
