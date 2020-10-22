using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text instructionText;

    private bool ADinst = false, Spaceinst = false;

    private void Start()
    {
        instructionText.text = "A to move Left   D to move Right";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal") && !ADinst)
        {
            instructionText.text = "Space to Jump";
            ADinst = true;
        }
    }
}

