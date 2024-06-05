using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private bool movingRight = true;
    // Player movement
    public float speed;
    private float move;

    // Player jumping
    public float jump;
    public bool isJumping;
    private Rigidbody2D rb;

    // Powerup
    public GameObject PowerUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        // Flip the player sprite based on the direction of movement
        if (move > 0 && !movingRight)
        {
            Flip();
        }
        else if (move < 0 && movingRight)
        {
            Flip();
        }
    }

    // Enable jumps on ground but no infinite jumps
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        // Power up functionality
        else if (other.gameObject.CompareTag("Powerup"))
        {
            speed += 2;
            jump += 100;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    // Reset jumping for respawn
    public void ResetJumpState()
    {
        isJumping = false;
        speed = 7;
        jump = 550;
    }

    // Method to flip the player sprite
    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = player.transform.localScale;
        localScale.x *= -1;
        player.transform.localScale = localScale;
    }
}
