using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehavior : MonoBehaviour
{
    [SerializeField] protected Rigidbody playerRb;
    [SerializeField] protected Animator characterAnim;
    public float JumpPower { get; protected set; }
    public float Speed { get; protected set; }
    protected GameManager gameManager;
    protected Vector3 move;
    protected Vector3 gravity;
    protected bool isGrounded;
    protected bool isJumping;
    protected float rotationSpeed = 1400;
    protected float horizontalInput;

    float startingJumpPower;
    float startingSpeed;
    protected virtual void Start()
    {
        gameManager = GameManager.instance;

        JumpPower = startingJumpPower;
        Speed = startingSpeed;
    }
    protected virtual void Update(){}
    protected virtual void FixedUpdate()
    {
        HandleMovement();
        HandleJump();

        if (isJumping)
        {
            playerRb.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
            isJumping = false;
        }
    }
    protected virtual void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        var movementPlane = new Vector3(playerRb.velocity.x, 0, 0);

        if (movementPlane.magnitude < Speed && gameManager.isGameActive)
        {
            move = new Vector3(horizontalInput * Speed * Time.deltaTime, 0, 0);
            characterAnim.SetFloat("Speed_f", 1);
        }
 
        if (horizontalInput != 0 && gameManager.isGameActive && isGrounded)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
            moveDirection.Normalize();
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            characterAnim.transform.rotation = Quaternion.RotateTowards(playerRb.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            characterAnim.SetFloat("Speed_f", 0);
        }

        playerRb.velocity = new Vector3(move.x, playerRb.velocity.y, playerRb.velocity.z);
    }

    protected virtual void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collided with endgame");

            if (GameManager.gemsCollected > 7)
            {
                gameManager.GameOver();
            }

            else
            {
                StartCoroutine(gameManager.ShowMessage(("Collect all the gems first"), 3.0f));
            }
        }
    }
}
