using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public string pieceColor;

    private PlayerScript player;

    void Start()
    {
        player = GameObject.Find("Dawn").GetComponent<PlayerScript>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.collectedPieces.Add(pieceColor);
            Destroy(gameObject);
        }
    }
}
