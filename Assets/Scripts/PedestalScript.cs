using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestalScript : MonoBehaviour
{
    public string pedestalColor;

    private PlayerScript player;

    private bool allowInteraction = false;
    
    //control background
    private SpriteRenderer nightBG;
    private SpriteRenderer purpleBG;
    private SpriteRenderer pinkBG;
    private SpriteRenderer yellowBG;

    public Text instructionText;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dawn").GetComponent<PlayerScript>();

        nightBG = GameObject.Find("Background_Basic").GetComponent<SpriteRenderer>();
        purpleBG = GameObject.Find("Background_Purple").GetComponent<SpriteRenderer>();
        pinkBG = GameObject.Find("Background_Pink").GetComponent<SpriteRenderer>();
        yellowBG = GameObject.Find("Background_Orange").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (allowInteraction)
        {
            if (player.collectedPieces.Contains(pedestalColor) && Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("key inserted");

                if (pedestalColor == "purple")
                {
                    player.dash = true;

                    StartCoroutine(FadeOut(nightBG));
                    StartCoroutine(FadeIn(purpleBG));

                    instructionText.text = "Left mouse to dash.";
                }
                else if (pedestalColor == "pink")
                {
                    player.doubleJump = true;
                    StartCoroutine(FadeOut(purpleBG));
                    StartCoroutine(FadeIn(pinkBG));
                }
                else
                {
                    StartCoroutine(FadeOut(pinkBG));
                    StartCoroutine(FadeIn(yellowBG));
                }
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        //pedestalText.text = "Press G to Use.";

        if (col.gameObject.tag == "Player")
        {
            allowInteraction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //pedestalText.text = "";

        allowInteraction = false;
    }
    
    IEnumerator FadeIn(SpriteRenderer sprite)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            sprite.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
    
    IEnumerator FadeOut(SpriteRenderer sprite)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            sprite.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
    
    
}
