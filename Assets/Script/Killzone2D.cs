using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone2D : MonoBehaviour
{
    public bool killMe;
    public bool killOther;
    public bool killPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (killMe == true)
        {
            Destroy(gameObject);
        }
        if (killOther == true && other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        if (killPlayer == true && other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
