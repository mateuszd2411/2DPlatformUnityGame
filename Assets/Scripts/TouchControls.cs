using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private PlayerController thePlayer;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        anim = GetComponent<Animator>();
    }

    public void LeftArrow()
    {
        thePlayer.Move(-1);
    }

    public void RightArrow()
    {
        thePlayer.Move(1);
    }

    public void UnpressedArrow()
    {
        thePlayer.Move(0);
    }

    public void Defend()
    {
        thePlayer.Defend();
    }

    public void ResetDefend()
    {
        thePlayer.ResetDefend();
    }

    public void Bullet()
    {
        thePlayer.FireBullet();
    }

    public void BulletUp()
    {
        thePlayer.FireBulletUp();
    }

    public void Jump()
    {
        thePlayer.Jump();
    }
}
