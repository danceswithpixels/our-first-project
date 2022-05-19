using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] int index = -1;
    SpriteRenderer mySpriteRenderer;
    PlayerMovement player;

    void Awake() {
        player = FindObjectOfType<PlayerMovement>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (index != -1) {
            mySpriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index != -1 && index <= player.blocksJumped) {
            mySpriteRenderer.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && index >= player.blocksJumped) {
            player.blocksJumped++;
        }
    }
}
