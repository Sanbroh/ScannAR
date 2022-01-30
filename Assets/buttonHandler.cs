using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    private bool flashOn = false;
    private bool itemMenuOn = false;

    public GameObject Source;

    void Start()
    {
        Source.SetActive(false);
    }

    public void toggleCamera()
    {

    }

    public void toggleFlash()
    {

        if (flashOn == false)
        {
            //CameraDevice.Instance.SetFlashTorchMode(true);
            flashOn = true;
        }
        else
        {
            //CameraDevice.Instance.SetFlashTorchMode(false);
            flashOn = false;
        }
    }

    public void toggleItemMenu()
    {
        if (!itemMenuOn)
        {
            Source.SetActive(true);
            itemMenuOn = true;
        }
        else
        {
            Source.SetActive(false);
            itemMenuOn = false;
        }
    }
}
