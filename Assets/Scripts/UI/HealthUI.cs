using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Text healthAmountText;

    private Attributes attributes;
    private GameObject player;

    void Start()
    {
        healthAmountText = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        attributes = player.GetComponent<Attributes>();
    }

    void Update()
    {
        healthAmountText.text = $"Çהמנמגüו: {Mathf.RoundToInt(attributes.healthCurrent)}/{Mathf.RoundToInt(attributes.healthInitial)}";
    }
}
