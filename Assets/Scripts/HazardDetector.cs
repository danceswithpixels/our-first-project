using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardDetector : MonoBehaviour
{
    bool hasTriggeredHazard = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Hazard" && !hasTriggeredHazard) 
        {           
            hasTriggeredHazard = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
