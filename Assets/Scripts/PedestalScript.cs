using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedestalScript : MonoBehaviour
{
    private Text pedestalText;
    public string pedestalColor;
    private GameManager manager;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        pedestalText = gameObject.GetComponentInChildren<Text>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        pedestalText.text = "Press Space to Use.";

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("panel should move");
        }

        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("panel move");
            panel.GetComponent<RectTransform>().Translate(0, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pedestalText.text = "";
    }
}
