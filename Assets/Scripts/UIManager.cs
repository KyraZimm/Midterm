using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text AText, DText, SpaceText;
    public Image backdrop;
    private bool  showInst = true;

    private void Start()
    {
        StartCoroutine(FadeIn(AText));
        StartCoroutine(FadeIn(DText));
        StartCoroutine(FadeIn(SpaceText));
        StartCoroutine(FadePanel(true));
    }
    private void Update()
    {
        if (showInst && (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Jump")))
        {
            StartCoroutine(FadeOut(SpaceText));
            StartCoroutine(FadeOut(AText));
            StartCoroutine(FadeOut(DText));
            StartCoroutine(FadePanel(false));
            showInst = false;
        }
        
    }
    
    IEnumerator FadeIn(Text toFade)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            toFade.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
    
    IEnumerator FadeOut(Text toFade)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            toFade.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator FadePanel(bool fadeIn)
    {
        if (fadeIn)
        {
            for (float i = 0; i <= 0.5f; i += Time.deltaTime)
            {
                backdrop.color = new Color(0, 0, 0, i);
            }
        }
        else
        {
            for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
            {
                backdrop.color = new Color(0, 0, 0, i);
            }
        }

        yield return null;
    }

    IEnumerator ShowDashInst()
    {
        yield return null;
    }

    IEnumerator ShowDoubleJumpInst()
    {
        yield return null;
    }
}