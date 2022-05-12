using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int randomSeed = 0;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(randomSeed);
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // void OnFire(InputValue value) {
    //     Platform[] platforms = FindObjectsOfType<Platform>();
    //     foreach (Platform platform in platforms) {
    //         platform.ToggleSpriteRenderer();
    //     }
    //     Debug.Log(Random.value);
    // }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Red Platforms")) ||
            myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Blue Platforms"))) {
            myRigidbody.velocity += new Vector2 (0f, moveInput.y * jumpSpeed);
        }
    }

}
