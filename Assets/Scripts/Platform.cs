using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] int index = -1;
    SpriteRenderer mySpriteRenderer;
    PlayerMovement player;

    bool tagged = false;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();
        if (index != -1) {
            mySpriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (index != -1 && index <= player.blocksJumped) {
        //     mySpriteRenderer.enabled = true;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && tagged == false) {
            tagged = true;
            player.blocksJumped++;
        }
    }
}
