using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBlock : MonoBehaviour
{
    [SerializeField] int[] initialLocksToUnlock = new int[] {3,4,5};

    GameObject[] locks;

    PlayerMovement player;

    void Start() 
    {
        player = FindObjectOfType<PlayerMovement>();
        player.SetInitialLockUnlocked(true);
        locks = GameObject.FindGameObjectsWithTag("Lock");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (player.IsInitialLockUnlocked()) 
            {
                foreach (int i in initialLocksToUnlock) 
                {
                    Destroy(locks[i]);
                }
                player.SetInitialLockUnlocked(false);
            } else 
            {
                foreach (GameObject lk in locks)
                {
                    Destroy(lk);
                }
            }
            Destroy(gameObject);
        }
    }
}
