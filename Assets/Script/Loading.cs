using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    public GameObject imageToShow;
    public float imageDisplayTime = 2f;
    public int nextSceneIndex;

    private void Start()
    {
        imageToShow.SetActive(false);
    }

    public void OnButtonClicked()
    {

        imageToShow.SetActive(true);

        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(imageDisplayTime);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
