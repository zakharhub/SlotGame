using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Combinations;

public class SlotMachine : MonoBehaviour
{
    public int money;
    public Text moneyText;

    public int energe;
    public Text energeText;

    public int price;
    public Slot[] slots;
    public Combinations[] combinations;
    public float timeInterval = 0.025f;
    private int stoppedSlots = 3;
    private bool isSpin = false;
    public bool isAuto;

    private string moneySaveKey = "PlayerMoney";
    private string energeSaveKey = "PlayerEnerge";
  
    public Button deactivateButton;
    public GameObject objectToDeactivate1;
    public GameObject objectToDeactivate2;
    public int deactivateCost = 10;

    void Start()
    {
        if (PlayerPrefs.HasKey(moneySaveKey))
        {
            money = PlayerPrefs.GetInt(moneySaveKey);
        }
        else
        {
            money = 0;
        }
        Debug.Log("Loaded Money: " + money);
        UpdateMoneyUI();

        
        if (PlayerPrefs.HasKey(energeSaveKey))
        {
            energe = PlayerPrefs.GetInt(energeSaveKey);
        }
        else
        {
            energe = 0;
        }
        Debug.Log("Loaded Energe: " + energe);
        UpdateEnergeUI();

        
        if (deactivateButton != null)
        {
            deactivateButton.onClick.AddListener(DeactivateObjects);
        }
    }

    void UpdateMoneyUI()
    {
        moneyText.text = money.ToString();
    }

    void UpdateEnergeUI()
    {
        energeText.text = energe.ToString();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(moneySaveKey, money);
        PlayerPrefs.Save();
    }

    public void SaveEnerge()
    {
        PlayerPrefs.SetInt(energeSaveKey, energe);
        PlayerPrefs.Save();
    }

    public void ChangeMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
        SaveMoney();
    }

    public void ChangeEnerge(int amount)
    {
        energe += amount;
        UpdateEnergeUI();
        SaveEnerge();
    }

    public void Spin()
    {
        if (!isSpin && money - price >= 0)
        {
            ChangeMoney(-price);
            isSpin = true;
            foreach (Slot i in slots)
            {
                i.StartCoroutine("Spin");
            }
            SaveMoney();
        }
    }

    public void WaitResults()
    {
        stoppedSlots -= 1;
        if (stoppedSlots <= 0)
        {
            stoppedSlots = 3;
            CheckResults();
        }
    }

    public void CheckResults()
    {
        isSpin = false;
        foreach (Combinations i in combinations)
        {
            if (slots[0].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.FirstValue.ToString()
                && slots[1].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.SecondValue.ToString()
                && slots[2].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.ThirdValue.ToString())
            {
                ChangeMoney(i.prize);
                ChangeEnerge(i.energePrize);
                SaveMoney();
                SaveEnerge();
            }
        }
        if (isAuto)
        {
            Invoke("Spin", 0.4f);
        }
    }

    public void OnlyVictory()
    {
        if (!isSpin && money - price >= 0)
        {
            ChangeMoney(-price);
            SaveMoney();
            isSpin = true;
            SlotValue randItem = (SlotValue)Random.Range(0, 5);
            foreach (Slot i in slots)
            {
                i.randItem = randItem;
                i.StartCoroutine("CheatSpin");
            }
        }
    }

    public void DeactivateObjects()
    {
        if (energe >= deactivateCost)
        {
            ChangeEnerge(-deactivateCost);

            if (objectToDeactivate1 != null)
            {
                objectToDeactivate1.SetActive(false);
            }

            if (objectToDeactivate2 != null)
            {
                objectToDeactivate2.SetActive(false);
            }
        }
        else
        {
            Debug.Log("!");
        }
    }
}

[System.Serializable]
public class Combinations
{
    public enum SlotValue
    {
        Gold,
        Seven,
        Strawberry,
        Cherry,
        Coin
    }

    public SlotValue FirstValue;
    public SlotValue SecondValue;
    public SlotValue ThirdValue;
    public int prize;
    public int energePrize;
}
