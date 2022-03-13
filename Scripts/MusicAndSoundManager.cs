using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSoundManager : MonoBehaviour
{
    public bool isMusicMuted = false;
    public bool isSoundMuted = false;

    [SerializeField]
    private AudioSource backgroundMusic;

    [SerializeField]
    private Animator musicAnimator;
    [SerializeField]
    private Animator soundAnimator;

    public void changeMusic()
    {
        musicAnimator.SetBool("isPressed", true);
        isMusicMuted = !isMusicMuted;
        if (isMusicMuted)
        {
            backgroundMusic.volume = 0.3f;
        }
        else
        {
            backgroundMusic.volume = 1;
        }
    }
    public void changeSound()
    {
        isSoundMuted = !isSoundMuted;
        soundAnimator.SetBool("isPressed", true);
    }
}
