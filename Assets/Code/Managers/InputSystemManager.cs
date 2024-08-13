using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemManager : MonoBehaviour
{
    #region Singleton
    public static InputSystemManager Instance { get; private set; }
    public void Awake()
    {
        inputActions = new DefaultControls();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }
    #endregion

    #region Activation Functions
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    #endregion

    public DefaultControls inputActions;

    private void Update()
    {
        if (inputActions == null)
        {
            inputActions = new DefaultControls();
        }
    }
}
