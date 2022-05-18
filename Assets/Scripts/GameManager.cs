using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    PlayerMovement player;
    PauseCanvas pauseCanvas;

    void Awake() {
        pauseCanvas = FindObjectOfType<PauseCanvas>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Start() {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update() {
        if(player.IsGamePaused()) {
            pauseCanvas.gameObject.SetActive(true);
        } else {
            pauseCanvas.gameObject.SetActive(false);
        }
    }
    
    public void LoadNexScene() {
        player.UnPauseGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
