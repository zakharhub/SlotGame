using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : MonoBehaviour
{
    public int coinValue = 20; 
    private SlotMachine slotMachine;

    void Start()
    {
        slotMachine = FindObjectOfType<SlotMachine>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible")) 
        {
            slotMachine.ChangeMoney(coinValue); 
            Destroy(other.gameObject); 
        }
    }
}
