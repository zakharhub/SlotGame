using UnityEngine;
using UnityEngine.UI;

public class bucketmiss : MonoBehaviour
{
    private int collisionCount = 0;

    private HeartManager heartManager;
    private SlotMachine slotMachine;

    public Text energyText;
    public GameObject gameOverPanel;

    private void Start()
    {
        heartManager = FindObjectOfType<HeartManager>();
        slotMachine = FindObjectOfType<SlotMachine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;

        if (collisionCount == 1)
        {
            heartManager.RemoveHeart();
        }

        if (collisionCount >= 1)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        Time.timeScale = 0; 
        energyText.text = "" + slotMachine.GetSessionEnerge().ToString();
        gameOverPanel.SetActive(true);
    }
}
