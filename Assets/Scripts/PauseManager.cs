using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayerMovement player;
    PauseCanvas pauseCanvas;
    GameSession gameSession;

    void Awake() {
        player = FindObjectOfType<PlayerMovement>();
        pauseCanvas = FindObjectOfType<PauseCanvas>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Start() {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update() {
        pauseCanvas.gameObject.SetActive(player.IsGamePaused());
    }

    public void UnPauseAndLoadNextScene() {
        player.UnPauseGame();
        gameSession.LoadNexScene();
    }
}
