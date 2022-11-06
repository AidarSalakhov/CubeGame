using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    private Text foodAmountText;

    private Attributes attributes;
    private GameObject player;

    private void Start()
    {
        foodAmountText = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        attributes = player.GetComponent<Attributes>();
    }

    private void Update()
    {
        foodAmountText.text = $"ׁûעמסעü: {Mathf.RoundToInt(attributes.foodCurrent)}/{Mathf.RoundToInt(attributes.foodInitial)}";
    }
}
