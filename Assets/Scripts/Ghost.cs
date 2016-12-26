using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

    public int Damage;
    public float Speed;
    public float SightRange;
    public GameObject Target;
    private Rigidbody2D rb;

    public GameObject HealthUI;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameO = other.gameObject;
        
        if (gameO.CompareTag("Player"))
        {
            gameO.SendMessage("TakeDamage", Damage);
        }
        else if (gameO.CompareTag("MagicCircle"))
        {
            // Toast ghosts that enter magic circle
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        float targetXPos = Target.gameObject.transform.position[0];
        float thisXPos = gameObject.transform.position[0];
        float xDist = targetXPos - thisXPos;

        float targetYPos = Target.gameObject.transform.position[1];
        float thisYPos = gameObject.transform.position[1];
        float yDist = targetYPos - thisYPos;

        // If close enough
        if (xDist > -SightRange && xDist < SightRange
            && yDist > -SightRange && yDist < SightRange)
        // Move closer
        {
            if (xDist > 0)

            {
                if (yDist > 0)
                    {
                        rb.velocity = new Vector3(Speed, Speed, 0);
                    }
                else if (yDist < 0)
                    {
                        rb.velocity = new Vector3(Speed, -Speed, 0);
                    }

                }
                else if (xDist < 0)
                {
                    if (yDist > 0)

                    {
                        rb.velocity = new Vector3(-Speed, Speed, 0);
                    }
                    else if (yDist < 0)
                    {
                        rb.velocity = new Vector3(-Speed, -Speed, 0);
                    }

                }

            }
        }
    }

