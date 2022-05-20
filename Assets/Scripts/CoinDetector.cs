using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinDetector : MonoBehaviour
{
    [SerializeField] int playerSelect = 0;
    CircleCollider2D myCircleCollider;
    GameSession gameSession;
    Toggle toggle;

    void Awake() {
        gameSession = FindObjectOfType<GameSession>();
        toggle = FindObjectOfType<Toggle>();
    }

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
            if (playerSelect == 1) {
                toggle.isOn = true;
            } else if (playerSelect == 2) {
                toggle.isOn = false;
            }
            if(SceneManager.GetActiveScene().buildIndex < 1) {
                gameSession.LoadNexScene();
            } else {
                other.GetComponent<PlayerMovement>().PauseGame();
            }
        }
    }
}
