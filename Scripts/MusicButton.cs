using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    private Sprite musicOn;
    [SerializeField]
    private Sprite musicOff;

    private MusicAndSoundManager musicAndSoundManager;
    private Image spriteRenderer;

    private void Awake()
    {
        musicAndSoundManager = FindObjectOfType<MusicAndSoundManager>();
        spriteRenderer = GetComponent<Image>();
    }

    private void Update()
    {
        if (musicAndSoundManager.isMusicMuted)
        {
            spriteRenderer.sprite = musicOff;
        }
        else
        {
            spriteRenderer.sprite = musicOn;
        }
    }
}
