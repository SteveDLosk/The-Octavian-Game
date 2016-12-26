using UnityEngine;
using System.Collections;

public class BaseEnemyAI : MonoBehaviour {

    public Transform sightStart, sightEndLeft, sightEndRight;

    // Enemy characteristics
    public float speed;
    public float jumpSpeedY;
    public float SightRange;

    public int Damage;

    public bool StuffInWay;
    public int Health;

    bool facingRight, Jumping;
    private float x_Position;


    Rigidbody2D rb; 

    // Target the player
    public GameObject Target;
    
    
    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Raycasting();
        x_Position = gameObject.transform.position[0];
        bool CloseEnough = TestIfCloseEnough(Target);
        if (CloseEnough)

        {
                GetCloser(Target);
        }
    }

    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEndLeft.position, Color.green);

        if (facingRight == false)
            StuffInWay = Physics2D.Linecast(sightStart.position, sightEndLeft.position);
        else if (facingRight)
            StuffInWay = Physics2D.Linecast(sightStart.position, sightEndRight.position);
    }

    // Check is player is close enough to chase/attack
    bool TestIfCloseEnough(GameObject player)
    {
        float distance;
        distance = Vector2.Distance(player.gameObject.transform.position, 
            gameObject.transform.position);
        distance = System.Math.Abs(distance); 
        if ((distance < SightRange))
            return true;
        else
            return false;
    }

    void GetCloser(GameObject Target)
    {
        
        float targetPos = Target.gameObject.transform.position[0];
        float thisPos = gameObject.transform.position[0];
        // calculate direction
        float distance;

        distance = targetPos - thisPos;

        // Jump over obstacles
        if (StuffInWay)
            Jump();
        
        // Correct way, left or right
        if (distance < 0)
        {   
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            facingRight = false;
        }
        else
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            facingRight = true;
        }
    }

    void GetCloser(GameObject Target, bool stuck)
    {
        if (stuck)
        {
            Debug.Log("stuck");

            float targetPos = Target.gameObject.transform.position[0];
            float thisPos = gameObject.transform.position[0];
            // calculate direction
            float distance;

            distance = targetPos - thisPos;
          
        if (distance < 0)
                rb.AddForce(new Vector2(-speed, jumpSpeedY));
            else
                rb.AddForce(new Vector2(speed, jumpSpeedY));
        
        }
        
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

    void Jump()
    {
        if (!Jumping)
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
        Jumping = true;
    }

    void OnCollisionEnter2D(Collision2D other)
        // Be able to jump again, after landing
    {
        if (other.gameObject.tag == "GROUND")
        {
            Jumping = false;
            //anim.SetInteger("State", 0);
        }

        else if (other.gameObject.tag == "BowlingBall")
        {
            // Bowling ball hits to hurt enemy
            float impact = Vector3.Dot(other.contacts[0].normal, other.relativeVelocity)
                    * other.rigidbody.mass;
            // Make all impacts positive
            impact = Mathf.Abs(impact);
            // format numbers to "easier to work with"
            int damage = (int)Mathf.Floor(impact / 10);
            Debug.Log(damage.ToString());
            LooseHealth(damage);
        }
    }

    void LooseHealth (int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
