using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f; 
    private float runningSpeed = 7f;
    private float jumpPush = 14f;
    private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }
    private AudioSource jumpSoundEffect;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal"); //Raw is added to not let the player slide
        rb.velocity = new Vector2(dirX * runningSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsOnTheGround())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPush);
        }

       UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

         if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsOnTheGround()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

