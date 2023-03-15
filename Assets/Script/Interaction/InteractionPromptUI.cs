using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCamera;
    public bool isDisplayed = false;
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject _uiPanel;
    void Start()
    {
        _mainCamera = Camera.main;
        _uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
