using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerScript pScript;
    private Camera mainCamera;
    public Transform CamTarget;
    private float CamSpeed = 0.5f;
    public bool victoryMet;

    private UIManager uiManager;

    void Start()
    {
        pScript = GameObject.Find("Dawn").GetComponent<PlayerScript>();
        mainCamera = GameObject.Find("Dawn").GetComponentInChildren<Camera>();
        CamTarget = GameObject.Find("Victory Camera Position").GetComponent<Transform>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (victoryMet)
        {
            StartCoroutine(Victory());
            victoryMet = false;
        }
    }

    IEnumerator Victory()
    {
        mainCamera.transform.parent = null;
        pScript.victory = true;

        uiManager.showTitle = true;
        yield return new WaitForSeconds(3);
        
        float step = CamSpeed * Time.deltaTime;
        while (true)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, CamTarget.transform.position, step);

            // If the object has arrived, stop the coroutine
            if (mainCamera.transform.position == CamTarget.position)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
        
        /*
        pScript.canMove = false;
        pScript.canJump = false;

        yield return new WaitForSeconds(1);
        float step = CamSpeed * Time.deltaTime;
        mainCamera.transform.position = Vector3.MoveTowards(transform.position, CamTarget.position, step);
        */
    }
}

