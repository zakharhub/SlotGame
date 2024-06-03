using UnityEngine;
using System.Collections;

public class AudioButton : MonoBehaviour
{
    public GameObject objectToActivate;
    private bool isActive = false;

    public void ActivateObject()
    {       
        if (!isActive)
        {
            isActive = true;
            objectToActivate.SetActive(true);
            StartCoroutine(DeactivateObjectAfterDelay(4f));
        }
    }

    private IEnumerator DeactivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        objectToActivate.SetActive(false);
        isActive = false;
    }
}

