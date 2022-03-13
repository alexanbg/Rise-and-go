using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredBlop : MonoBehaviour
{
    [SerializeField]
    private Sprite hiddenBlop;
    [SerializeField]
    private Sprite risedBlop;

    private MusicAndSoundManager musicAndSoundManager;
    private BlopActions blopActions;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        musicAndSoundManager = FindObjectOfType<MusicAndSoundManager>();
        blopActions = GetComponent<BlopActions>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (spriteRenderer.isVisible)
        {
            if (!musicAndSoundManager.isSoundMuted)
            {
                blopActions.Hide();

            }

            if (musicAndSoundManager.isSoundMuted && musicAndSoundManager.isMusicMuted)
            {
                blopActions.Rise();
            }

            spriteRenderer.sprite = blopActions.isHidden ? hiddenBlop : risedBlop;
        }
        
    }
}
