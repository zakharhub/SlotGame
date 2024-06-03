using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public AudioSource musicSource;
    public Button musicButton;

    private bool isMusicPlaying = true;

    void Start()
    {
        musicButton.onClick.AddListener(ToggleMusic);
    }

    void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            musicSource.Stop();
            isMusicPlaying = false;
        }
        else
        {
            musicSource.Play();
            isMusicPlaying = true;
        }
    }
}
