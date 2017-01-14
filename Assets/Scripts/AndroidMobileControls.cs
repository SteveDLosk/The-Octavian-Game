using UnityEngine;
using System.Collections;

public class AndroidMobileControls : MonoBehaviour
{
    float speed;
    public float speedX;
    public bool Grounded;
    public bool Jumping;
    public Rigidbody2D rb;
    public float jumpSpeedY;
    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void PressLeft()
    {
        speed = -speedX;
    }

    void ReleaseLeft()
    {
        speed = 0;
    }

    void PressRight()
    {
        speed = speedX;
    }

    void ReleaseRight()
    {
        speed = 0;
    }

    void Jump()
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


}
