using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinDetector : MonoBehaviour
{
    CircleCollider2D myCircleCollider;

    void Start()
    {
        myCircleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().PauseGame();
        }
    }
}
