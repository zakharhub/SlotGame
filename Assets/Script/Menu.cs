using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void _SceneNumber(int n)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(n);
    }

    public void _SceneName(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void _SceneNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void _Exit()
    {
        Application.Quit();
    }
}
