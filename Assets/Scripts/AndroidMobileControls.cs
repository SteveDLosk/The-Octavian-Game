using UnityEngine;
using System.Collections;


public class AndroidMobileControls : MonoBehaviour
{
    float speed;
    public float speedX;
    public bool Grounded;
    public bool Jumping, facingRight;
    public Rigidbody2D rb;
    public float jumpSpeedY;
    public GameObject player;
    public Transform Feet, Feet2, Feet3, GroundTest, GroundTest2, GroundTest3;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = this.gameObject;

        // 1024 X 600 default resolution
        const int defaultHt = 600;
        const int defaultWt = 1024;
        int height = Camera.current.pixelHeight;
        int width = Camera.current.pixelWidth;

        float scaleHt = height / defaultHt;
        float scaleWt = width / defaultWt;

        Camera camera = Camera.current;
        camera.aspect = scaleHt / scaleWt;
       
	}

    // Update is called once per frame
    public void Update()
    {
        // player movement
        MovePlayer(speed);

        // check for fall off screen 
        FellOffScreen();

        // Flipping code
        Flip();

        // Ground check to see if jumping is possible
        GroundCheck();
        /*
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

            // Play jump sound
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            audio.Play(44100);
        }*/
    }

    void GroundCheck()
    {
        bool grounded1, grounded2, grounded3;
        grounded1 = Physics2D.Linecast(Feet.position, GroundTest.position);
        grounded2 = Physics2D.Linecast(Feet2.position, GroundTest2.position);
        grounded3 = Physics2D.Linecast(Feet3.position, GroundTest3.position);

        if (grounded1 || grounded2 || grounded3)
            Grounded = true;
        else
            Grounded = false;
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
        if (speed < 0 && !facingRight || speed > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }


    public void PressLeft()
    {
        speed = -speedX;
    }

    public void ReleaseLeft()
    {
        speed = 0;
    }

    public void PressRight()
    {
        speed = speedX;
    }

    public void ReleaseRight()
    {
        speed = 0;
    }

    public void Jump()
    {
        if (Grounded)
        {
            Jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));

            //  anim.SetInteger("State", 3);

            // Play jump sound
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            audio.Play(44100);
        }
    }

    public void FellOffScreen()
    {
        if (rb.position.y < -25)
            //Debug.Log("Fell to death, newMove script");
            gameObject.SendMessage("FellToDeath");
    }
}
