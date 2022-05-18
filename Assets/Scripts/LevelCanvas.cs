using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Awake() 
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update() 
    {
        timerImage.fillAmount = timer.fillFraction;
        if (!timer.isCompletingLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
