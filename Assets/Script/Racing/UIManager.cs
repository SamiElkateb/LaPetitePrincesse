using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool _isTextActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLapText(string message) {
        Debug.Log("Go here");
        text.text = message;
    }
    
    public void ActivateText() {
        _isTextActive = true;
        text.gameObject.SetActive(true);
    }
    
    public void DeactivateText() {
        _isTextActive = false;
        text.gameObject.SetActive(false);
    }
}
