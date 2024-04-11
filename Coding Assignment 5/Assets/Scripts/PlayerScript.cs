using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Rigidbody property for the parent object
    public Rigidbody2D playerRigidBody;

    //GameObject property for attack hitbox
    public GameObject atkBox;

    // properties for movement & and HP
    public float jumpStrength;
    public float playerSpeed;
    public int playerHealth;

    // KeyCode properties (for having multiple player controllers)
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode atk;


    // properites for ground detection
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    bool isGrounded;
    bool isMoving;
    float atkTimer = 0;

    //grabs the animator
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if player's grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        //checks for jumps!
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            playerRigidBody.velocity = Vector2.up * jumpStrength;
        }
        //checks for attacks, stops player movement if so
        if (Input.GetKeyDown(atk) && isGrounded && atkTimer <= 0)
        {
            playerRigidBody.velocity = new Vector2(0, 0);
            Instantiate (atkBox, transform.position, transform.rotation);
            atkTimer = 1.3f;
        }

        //atktimer ticks down
        if (atkTimer > 0)
        {
            atkTimer = atkTimer - Time.deltaTime;
        }
        else //player can't move or jump while attacking
        {
            //checks player left/right input, moves velocity in the proper direction
            if (Input.GetKey(left))
            {
                playerRigidBody.velocity = new Vector2(-playerSpeed, playerRigidBody.velocity.y);
            }
            else if (Input.GetKey(right))
            {
                playerRigidBody.velocity = new Vector2(playerSpeed, playerRigidBody.velocity.y);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
            }
        }

        //checks for movement animaton
        if (playerRigidBody.velocity.x > 0.1 || playerRigidBody.velocity.x < -0.1)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
        //tells the animator what to do to match the move being made
        anim.SetBool("IsMoving", isMoving);
        anim.SetBool("IsGrounded", isGrounded);
    }
}
