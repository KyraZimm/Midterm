using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PedestalScript : MonoBehaviour
{
    public string pedestalColor;

    private Text pedestalText;

    private PlayerScript player;

    private bool allowInteraction = false, deactivate = false;

    //control background
    private SpriteRenderer nightBG;
    private SpriteRenderer purpleBG;
    private SpriteRenderer pinkBG;
    private SpriteRenderer yellowBG;

    public UIManager uiScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dawn").GetComponent<PlayerScript>();

        nightBG = GameObject.Find("Background_Basic").GetComponent<SpriteRenderer>();
        purpleBG = GameObject.Find("Background_Purple").GetComponent<SpriteRenderer>();
        pinkBG = GameObject.Find("Background_Pink").GetComponent<SpriteRenderer>();
        yellowBG = GameObject.Find("Background_Orange").GetComponent<SpriteRenderer>();

        pedestalText = GetComponentInChildren<Text>();

    }

    void Update()
    {

        if (allowInteraction)
        {
            if (player.collectedPieces.Contains(pedestalColor) && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("key inserted");

                if (pedestalColor == "purple")
                {
                    player.dash = true;

                    StartCoroutine(FadeOut(nightBG));
                    StartCoroutine(FadeIn(purpleBG));

                    StartCoroutine(uiScript.ShowDashInst());

                }
                else if (pedestalColor == "pink")
                {
                    player.doubleJump = true;
                    StartCoroutine(FadeOut(purpleBG));
                    StartCoroutine(FadeIn(pinkBG));

                    StartCoroutine(uiScript.ShowDoubleJumpInst());
                }
                else
                {
                    StartCoroutine(FadeOut(pinkBG));
                    StartCoroutine(FadeIn(yellowBG));
                    
                }
                
                deactivate = true;
                allowInteraction = false;
                pedestalText.text = "";
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !deactivate)
        {
            allowInteraction = true;

            if (player.collectedPieces.Contains(pedestalColor))
            {
                pedestalText.text = "Press E To Use";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !deactivate)
        {
            allowInteraction = false;

            pedestalText.text = "";
        }
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

    IEnumerator Victory()
    {
        yield return null;
    }
    
    
}
