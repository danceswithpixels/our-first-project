using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    Timer timer;

    void Start() 
    {
        timer = FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            timer.ResetTimer();
            Destroy(gameObject);
        }
    }
}
