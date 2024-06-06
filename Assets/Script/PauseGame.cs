using UnityEngine;

public class PauseGame : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
