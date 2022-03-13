using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    
    [SerializeField]
    private Transform movepoint;
    [SerializeField]
    private Animator bugAnimator;

    public LayerMask walkableArea;
    public LayerMask unwalkableArea;
    public LayerMask stoneLayer;
    private AudioSource audioSource;
    private MusicAndSoundManager mAndSManager;

    [SerializeField]
    public Transform spriteTransform;

    private void Awake()
    {
        movepoint.parent = null;
        audioSource = GetComponent<AudioSource>();
        mAndSManager = FindObjectOfType<MusicAndSoundManager>();

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movepoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movepoint.position) < 0.1f)
        {
            bool isOnLevel2 = walkableArea == 128;
            bugAnimator.SetBool("isUp", isOnLevel2);
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if ((!IsHorizontallyWalkingInto(unwalkableArea) || (isOnLevel2 && IsHorizontallyWalkingInto(walkableArea)))&&!IsHorizontallyWalkingInto(stoneLayer))
                {
                    movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    if (!mAndSManager.isSoundMuted)
                    {
                        audioSource.Play();
                    }
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if ((!IsVerticallyWalkingInto(unwalkableArea) || (isOnLevel2 && IsVerticallyWalkingInto(walkableArea)))&&!IsVerticallyWalkingInto(stoneLayer))
                {
                    movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    if (!mAndSManager.isSoundMuted)
                    {
                        audioSource.Play();
                    }
                }
            }
        }

        
    }

    private bool IsVerticallyWalkingInto(LayerMask layer)
    {
        return Physics2D.OverlapCircle(movepoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.4f, layer);
    }
    private bool IsHorizontallyWalkingInto(LayerMask layer)
    {
        return Physics2D.OverlapCircle(movepoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.4f, layer);
    }
}
