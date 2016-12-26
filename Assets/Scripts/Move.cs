using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private float move_x;
    private float move_y;
    public float JumpSpeed;
    public float WalkSpeed;
    private float distToGround;
    private Rigidbody2D rb;
 
 void Start()
    {
        // get the distance to ground
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


// Update is called once per frame
void FixedUpdate ()
    {
        move_x = Input.GetAxis("Horizontal");
        move_y = Input.GetAxis("Vertical");
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(move_x * WalkSpeed, move_y * JumpSpeed);
        
    }

void Update()
    {

    }
}
