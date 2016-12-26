using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour
{
    private float inputDirection;
    private float verticalVelocity;

    private float speed = 5.0f;
    private float gravity = 1.0f;

    private Vector2 moveVector;
    private CharacterController controller;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputDirection = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Spacebar!");

        if (controller.isGrounded)
            verticalVelocity = 0;
    }
   
     
}
