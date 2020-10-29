using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text AText, DText, SpaceText, InstructText, titleText, creditText;
    public Image backdrop;
    private bool showInst = true;
    public bool showTitle = false;

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

        if (showTitle)
        {
            StartCoroutine(TitleFade());
            showTitle = false;
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

    public IEnumerator ShowDashInst()
    {
        InstructText.text = "Press Left Mouse To Dash";
        StartCoroutine(FadeIn(InstructText));
        yield return new WaitForSeconds(5);
        StartCoroutine(FadeOut(InstructText));

    }

    public IEnumerator ShowDoubleJumpInst()
    {
        InstructText.text = "Tap Space Twice To Double-Jump";
        StartCoroutine(FadeIn(InstructText));
        yield return new WaitForSeconds(5);
        StartCoroutine(FadeOut(InstructText));
    }

    public IEnumerator TitleFade()
    {
        yield return new WaitForSeconds(1);
        titleText.text = "DAWN";
        creditText.text = "By Kyra Zimmermann";
        StartCoroutine(FadeIn(titleText));
        StartCoroutine(FadeIn(creditText));
    }
}