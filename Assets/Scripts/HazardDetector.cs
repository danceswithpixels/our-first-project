using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement.getCheckpoint() != null) {
                other.gameObject.transform.position = playerMovement.getCheckpoint().transform.position;
            } else {
                PlayerGraphics playerGraphics = other.gameObject.GetComponent<PlayerGraphics>();
                playerGraphics.setPlayerAnimation("isDead", true);
                Invoke("ReloadScene", 0.7f);
            }
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}