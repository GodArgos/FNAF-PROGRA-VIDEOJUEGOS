using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] public GameObject currentCamera;
    [SerializeField] private int cameraIndex;
    [SerializeField] public bool isActive = false;

    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = CameraManager.Instance.mainCamera.gameObject;

        foreach (var cam in cameras)
        {
            cam.GetComponent<Camera>().enabled = false;
            cam.GetComponent<AudioListener>().enabled = false;
        }

        ConnectButtonsToCameras();

        gameObject.SetActive(false);
    }

    public void DeactivateCameras()
    {
        mainCamera.SetActive(false);
        foreach (GameObject go in cameras)
        {
            if (go == currentCamera)
            {
                go.GetComponent<Camera>().enabled = true;
                go.GetComponent<AudioListener>().enabled = true;
            }
            else
            {
                go.GetComponent<Camera>().enabled = false;
                go.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    public void ActivateMainCamera()
    { 
        foreach (GameObject go in cameras)
        {
            go.GetComponent<Camera>().enabled = false;
            go.GetComponent<AudioListener>().enabled = false;
        }

        mainCamera.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ConnectButtonsToCameras()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            buttons.Add(child.gameObject);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<CameraButtonController>().designedCamera = cameras[i];
        }
    }
}
