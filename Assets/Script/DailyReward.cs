using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyReward : MonoBehaviour
{
    public GameObject dailyRewardPanel;
    public Text rewardMessage;
    public Button claimButton;

    private DateTime lastClaimTime;
    private TimeSpan cooldown = TimeSpan.FromHours(24);
    private string lastRewardTimeKey = "LastClaimTime";
    public int dailyRewardAmount = 100;

    private SlotMachine slotMachine;

    void Start()
    {
        claimButton.onClick.AddListener(ClaimReward);

        if (PlayerPrefs.HasKey(lastRewardTimeKey))
        {
            lastClaimTime = DateTime.Parse(PlayerPrefs.GetString(lastRewardTimeKey));
        }
        else
        {
            lastClaimTime = DateTime.MinValue;
        }

        slotMachine = FindObjectOfType<SlotMachine>();

        CheckRewardStatus();
    }

    void Update()
    {
        if (!CanClaimReward())
        {
            TimeSpan timeUntilNextReward = (lastClaimTime + cooldown) - DateTime.Now;
            rewardMessage.text = "Next reward in: " + timeUntilNextReward.Hours + "h " + timeUntilNextReward.Minutes + "m " + timeUntilNextReward.Seconds + "s";
        }
    }

    void CheckRewardStatus()
    {
        if (CanClaimReward())
        {
            rewardMessage.text = "You have a reward available!";
            claimButton.interactable = true;
        }
        else
        {
            TimeSpan timeUntilNextReward = (lastClaimTime + cooldown) - DateTime.Now;
            rewardMessage.text = "Next reward in: " + timeUntilNextReward.Hours + "h " + timeUntilNextReward.Minutes + "m " + timeUntilNextReward.Seconds + "s";
            claimButton.interactable = false;
        }
    }

    bool CanClaimReward()
    {
        return DateTime.Now >= lastClaimTime + cooldown;
    }

    void ClaimReward()
    {
        if (slotMachine != null)
        {
            slotMachine.ChangeMoney(dailyRewardAmount);
        }

        lastClaimTime = DateTime.Now;
        PlayerPrefs.SetString(lastRewardTimeKey, lastClaimTime.ToString());
        PlayerPrefs.Save();

        CheckRewardStatus();
    }
}
