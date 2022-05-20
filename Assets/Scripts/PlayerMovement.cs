using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int randomSeed = 0;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] int playerSpawn = 0;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;

    public int blocksJumped = 0;
    bool isGamePaused = false;

    void Start()
    {
        Random.InitState(randomSeed);
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

        Toggle toggle = FindObjectOfType<Toggle>();
        if (playerSpawn == 1 && !toggle.isOn) {
            Destroy (gameObject);
        } else if (playerSpawn == 2 && toggle.isOn) {
            Destroy (gameObject);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        Run();
    }


    void OnMove(InputValue value)
    {
        if(isGamePaused) { return; }

        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        // if (!isAlive) { return; }
        if (isGamePaused ||
            (
            !myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Red Platforms")) &&
            !myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Blue Platforms")) &&
            !myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Neutral Platforms"))
            )
        ) {
            return;
        }
        
        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    public void PauseGame() {
        isGamePaused = true;
        Time.timeScale = 0;
    }

    public void UnPauseGame() {
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public bool IsGamePaused() {
        return isGamePaused;
    }
}
