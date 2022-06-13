using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardDetector : MonoBehaviour
{
    // void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if (other.tag == "Player") {

    //         PlayerGraphics playerGraphics = other.GetComponent<PlayerGraphics>();

    //         playerGraphics.setPlayerAnimation("isDead", true);

    //         Invoke("ReloadScene", 0.7f);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            PlayerGraphics playerGraphics = other.gameObject.GetComponent<PlayerGraphics>();

            playerGraphics.setPlayerAnimation("isDead", true);

            Invoke("ReloadScene", 0.7f);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}