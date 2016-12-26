using UnityEngine;
using System.Collections;

public class NewMove : MonoBehaviour
{
    public float speedX;
    public float jumpSpeedY;
    public Transform Feet, GroundTest;

    bool facingRight, Jumping;
    public bool Grounded;  // check whether can jump
    float speed;

    // Add animation later
    //Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // player movement
        MovePlayer(speed);

        // check for fall off screen 
        FellOffScreen();

        // Flipping code
        Flip();

        // Ground check to see if jumping is possible
        GroundCheck();

        // left player movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }
        //

        // right player movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
        //

        // jumping player code
        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            Jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
           
          //  anim.SetInteger("State", 3);
        }
    }

    void GroundCheck()
    {

        Debug.DrawLine(Feet.position, GroundTest.position, Color.green);
        Debug.Log("Raycasting");

        Grounded = Physics2D.Linecast(Feet.position, GroundTest.position);
        
    }

    void MovePlayer(float playerSpeed)
    {
        // code for player movement and animation 

        // if player is moving
        if (playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
        {
            //anim.SetInteger("State", 2);
        }
        // if player is standing
        if (playerSpeed == 0 && !Jumping)
        {
            //anim.SetInteger("State", 0);
        }


        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void Flip()
    {
        // code to flip the player direction
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GROUND")
        {
            Jumping = false;
            //anim.SetInteger("State", 0);
        }
    }

    public void WalkLeft()
    {
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }

    public void StopMoving()
    {
        speed = 0;
    }
    
    public void FellOffScreen()
    {
        if (rb.position.y < -25)
            //Debug.Log("Fell to death, newMove script");
            gameObject.SendMessage("FellToDeath");
    }
}










