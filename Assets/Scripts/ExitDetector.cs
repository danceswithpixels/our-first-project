using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitDetector : MonoBehaviour
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
            PlayerGraphics playerGraphics = other.GetComponent<PlayerGraphics>();
            if (playerSelect == 1) {
                toggle.isOn = true;
                playerGraphics.setPlayerAnimation("isPlayer1", true);
                playerGraphics.setPlayerAnimation("isPlayer2", false);
            } else if (playerSelect == 2) {
                toggle.isOn = false;
                playerGraphics.setPlayerAnimation("isPlayer1", false);
                playerGraphics.setPlayerAnimation("isPlayer2", true);
            }
            // if(SceneManager.GetActiveScene().buildIndex < 1) {
            //     gameSession.LoadNexScene();
            // } else {
            //     other.GetComponent<PlayerMovement>().PauseGame();
            // }
        }
    }
}
