using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestalScript : MonoBehaviour
{
    private Text pedestalText;
    public string pedestalColor;

    private PlayerScript player;

    private bool allowInteraction = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pedestalText = gameObject.GetComponentInChildren<Text>();
        player = GameObject.Find("Dawn").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (allowInteraction)
        {
            if (player.collectedPieces.Contains(pedestalColor) && Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("key inserted");

                if (pedestalColor == "pink")
                {
                    player.doubleJump = true;
                }
                else if (pedestalColor == "orange")
                {
                    player.dash = true;
                }
                else
                {
                    
                }
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        pedestalText.text = "Press G to Use.";

        if (col.gameObject.tag == "Player")
        {
            allowInteraction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pedestalText.text = "";

        allowInteraction = false;
    }
}
