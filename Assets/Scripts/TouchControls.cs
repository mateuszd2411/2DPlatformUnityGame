using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private PlayerController thePlayer;

    private Animator anim;

    private LevelLoader levelExit;

    private PauseMenu thePauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        anim = GetComponent<Animator>();

        levelExit = FindObjectOfType<LevelLoader>();

        thePauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void LeftArrow()
    {
        thePlayer.Move(-1);
    }

    public void RightArrow()
    {
        if (levelExit.playerInZone)
        {
            levelExit.LoadLevel();
        }

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

    public void JumpOnGayser()
    {
        thePlayer.JumpOnGayser();
    }

    public void UpOnLadderRope()
    {
        thePlayer.UpOnRope();
    }

    public void DoubleJump()
    {
        thePlayer.DoubleJumpPlayer();
    }

    public void Pause()
    {
        thePauseMenu.PauseUnpause();
    }
}
