using UnityEngine;
using UnityEngine.SceneManagement;

public class bucketmiss : MonoBehaviour
{
    public string targetSceneName;
    private int collisionCount = 0;

    private HeartManager heartManager;

    private void Start()
    {
        heartManager = FindObjectOfType<HeartManager>();
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
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
