using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    private int currentHearts;

    private void Start()
    {
        currentHearts = hearts.Length;
    }

    public void RemoveHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            hearts[currentHearts].enabled = false;
        }
    }
}
