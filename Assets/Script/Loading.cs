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
        Debug.Log("Start method called. Hiding image.");
        imageToShow.SetActive(false);
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button clicked. Showing image and starting coroutine.");
        imageToShow.SetActive(true);

        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        Debug.Log($"Coroutine started. Waiting for {imageDisplayTime} seconds.");
        yield return new WaitForSeconds(imageDisplayTime);

        Debug.Log($"Time elapsed. Loading scene with index {nextSceneIndex}.");
        SceneManager.LoadScene(nextSceneIndex);
    }
}
