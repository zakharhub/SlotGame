using System.Collections;
using UnityEngine;

public class MoneyCheckAndShowImage : MonoBehaviour
{
    public GameObject imageToShow;
    public float showDuration = 3f;
    public int moneyThreshold = 25;

    public void CheckAndShowImage()
    {
        if (GameObject.FindGameObjectWithTag("SlotMachine").GetComponent<SlotMachine>().money < moneyThreshold)
        {
            StartCoroutine(ShowImage());
        }
    }

    IEnumerator ShowImage()
    {
        imageToShow.SetActive(true);

        yield return new WaitForSeconds(showDuration);

        imageToShow.SetActive(false);
    }
}
