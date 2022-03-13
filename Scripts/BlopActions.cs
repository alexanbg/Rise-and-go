using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlopActions : MonoBehaviour
{
    [SerializeField]
    private LayerMask character;
    [SerializeField]
    public bool isHidden = true;
    [SerializeField]
    private Animator eyeAnimator;

    private Movement playerMovement;
    private Animator bodyAnimator;
    private AudioSource audioSource;
    private MusicAndSoundManager mAndSManager;




    private void Awake()
    {
        playerMovement = FindObjectOfType<Movement>();
        bodyAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        mAndSManager = FindObjectOfType<MusicAndSoundManager>();
        transform.position = new Vector3(Mathf.Round(transform.position.x + 0.5f) - 0.5f, Mathf.Round(transform.position.y + 0.5f) - 0.5f, 0);
    }

    public void Rise()
    {
        if (isHidden&&!mAndSManager.isSoundMuted)
        {
            audioSource.Play();
        }
        if (Physics2D.OverlapCircle(transform.position, 0.2f, character))
        {
            playerMovement.unwalkableArea = 64;
            playerMovement.walkableArea = 128;
            
        }
        gameObject.layer = 7;
        isHidden = false;
        bodyAnimator.SetBool("isHidden", false);
        eyeAnimator.SetBool("isHidden", false);
    }
    public void Hide()
    {
        if (!isHidden && !mAndSManager.isSoundMuted)
        {
            audioSource.Play();
        }
        if (Physics2D.OverlapCircle(transform.position, 0.2f, character))
        {
            playerMovement.unwalkableArea = 128;
            playerMovement.walkableArea = 64;
        }
        gameObject.layer = 6;
        isHidden = true;
        bodyAnimator.SetBool("isHidden", true);
        eyeAnimator.SetBool("isHidden", true);
    }


}
