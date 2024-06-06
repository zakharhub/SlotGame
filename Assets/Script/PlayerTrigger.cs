using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SlotMachine slotMachine;

    void Start()
    {
        slotMachine = FindObjectOfType<SlotMachine>();
        if (slotMachine == null);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null && slotMachine != null)
            {
                slotMachine.ChangeMoney(coin.value);
                Destroy(other.gameObject);
            }
        }
    }
}
