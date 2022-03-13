using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;

    private MusicAndSoundManager musicAndSoundManager;
    private Image spriteRenderer;

    private void Awake()
    {
        musicAndSoundManager = FindObjectOfType<MusicAndSoundManager>();
        spriteRenderer = GetComponent<Image>();
    }

    private void Update()
    {
        if (musicAndSoundManager.isSoundMuted)
        {
            spriteRenderer.sprite = soundOff;
        }
        else
        {
            spriteRenderer.sprite = soundOn;
        }
    }
}
