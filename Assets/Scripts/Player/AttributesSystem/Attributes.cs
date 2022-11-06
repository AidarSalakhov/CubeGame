using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public float healthInitial = 100;
    public float healthCurrent;

    public float foodInitial = 100;
    public float foodCurrent;

    void Start()
    {
        ResetHealth();
        ResetFood();
    }

    void Update()
    {
        GettingHungry(0.01f);

        if (foodCurrent / foodInitial >= 0.9f)
        {
            Heal(0.01f);
        }
    }


    public void ResetHealth()
    {
        healthCurrent = healthInitial;
    }

    public void TakeDamage(float damageAmount)
    {
        healthCurrent -= damageAmount;

        if (healthCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float healAmount)
    {
        healthCurrent += healAmount;

        if (healthCurrent > healthInitial)
        {
            ResetHealth();
        }
    }
   
    public void ResetFood()
    {
        foodCurrent = foodInitial;
    }

    public void GettingHungry(float foodAmount)
    {
        foodCurrent -= foodAmount;

        if (foodCurrent <= 0)
        {
            foodCurrent = 0;
            TakeDamage(0.01f);
        }
    }

    public void GettingFull(float foodAmount)
    {
        foodCurrent += foodAmount;

        if (foodCurrent >= foodInitial)
        {
            ResetFood();
        }
    }
}
