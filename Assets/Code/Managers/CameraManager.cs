using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    #region Singleton
    public static CameraManager Instance { get; private set; }
    public void Awake()
    {
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

    [Header("Dependencies")]
    [Space(5)]
    [SerializeField] private GameObject cameraMap;
    [HideInInspector] public Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        InputSystemManager.Instance.inputActions.Player.CameraShortcut.performed += HandleCamera;
    }

    private void HandleCamera(InputAction.CallbackContext context)
    {
        if (!cameraMap.activeInHierarchy)
        {
            cameraMap.gameObject.SetActive(true);
        }
        else
        {
            cameraMap.GetComponent<CameraMapController>().ActivateMainCamera();
        }
    }
}
