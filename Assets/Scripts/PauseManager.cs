using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayerMovement player;
    GameObject pauseCanvas;
    GameSession gameSession;

    void Awake() {
        player = FindObjectOfType<PlayerMovement>();
        pauseCanvas = gameObject.transform.Find("PauseCanvas").gameObject;
        gameSession = FindObjectOfType<GameSession>();
    }

    void Start() {
        pauseCanvas.SetActive(false);
    }

    void Update() {
        if (player == null) {
            player = FindObjectOfType<PlayerMovement>();
        }
        pauseCanvas.SetActive(player.IsGamePaused());
    }

    public void UnPauseAndLoadNextScene() {
        player.UnPauseGame();
        gameSession.LoadNexScene();
    }
}
