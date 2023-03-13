using System;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
    public class pressKey: MonoBehaviour
    {
        public string text;
        private InteractionPromptUI _interactionPromptUI;
        private bool _isEntered = false;
        
        public void Start()
        {
            _interactionPromptUI = GameObject.Find("InteractiveCanva").GetComponent<InteractionPromptUI>();
            if (_interactionPromptUI == null)
            {
                Debug.Log("ERROR: InteractionPromptUI not found");
                Destroy(this);
            }
        }
        
        public void OnEnter()
        {
            _interactionPromptUI.SetUp(text);
            Debug.Log("Player entered interactable range");
            _isEntered = true;
        }
        
        public void OnExit()
        {
            _interactionPromptUI.Close();
            Debug.Log("Player exited interactable range");
            _isEntered = false;
        }

        public void Update()
        {
            if (_isEntered && Input.GetKey(KeyCode.F))
            {
                _interactionPromptUI.SetUp("F was pressed");
            }
        }
    }