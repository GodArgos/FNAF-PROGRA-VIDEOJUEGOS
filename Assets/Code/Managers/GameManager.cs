using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
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

    [SerializeField] private CameraMapController cmController;
    [SerializeField] public GameObject mainCamera;

    private void Start()
    {
        InputSystemManager.Instance.inputActions.Player.CameraShortcut.performed += HandleCamera;
    }

    private void HandleCamera(InputAction.CallbackContext context)
    {
        if (!cmController.isActive)
        {
            cmController.gameObject.SetActive(true);
            cmController.isActive = true;
        }
        else
        {
            cmController.gameObject.SetActive(false);
            cmController.isActive = false;
        }
    }
}
