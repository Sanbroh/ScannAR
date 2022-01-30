using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AR_Cursor_Script : MonoBehaviour
{
    public GameObject objectToPlace1;
    public GameObject objectToPlace2;
    public GameObject objectToPlace3;
    public GameObject objectToPlace4;
    public GameObject objectToPlace5;

    public GameObject cursorChildObject;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    public bool placingObject;
    public bool useCursor;
    public GameObject newObject;
    public togglePlacement tp;

    void Start()
    {
        cursorChildObject.SetActive(useCursor);
        placingObject = true;
        useCursor = false;
        togglePlacingOn();
        tp.forceToggleTrue();
    }

    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && placingObject == true)
        {
            if (useCursor)
            {
                newObject = GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if (hits.Count > 0)
                {
                    newObject = GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        } else if (Input.touchCount > 0 && placingObject == false)
        {
            
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

    public void togglePlacing()
    {
        if (!placingObject)
        {
            placingObject = true;
        } else
        {
            placingObject = false;
        }
    }

    public void togglePlacingOn()
    {
        placingObject = true;
    }

    public void togglePlacingOff()
    {
        placingObject = false;
    }

    public void deleteOld()
    {
        if (placingObject)
        {
            Destroy(newObject);
        }
    }

    public void deleteOldDouble()
    {
        if (placingObject)
        {
            Destroy(newObject);
            Destroy(newObject);
        }
    }

    public void deleteAll()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("placed");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
    }

    public void swapItem(int n)
    {
        if (n == 1)
        {
            objectToPlace = objectToPlace1;
        }
        else if (n == 2)
        {
            objectToPlace = objectToPlace2;
        }
        else if (n == 3)
        {
            objectToPlace = objectToPlace3;
        }
        else if (n == 4)
        {
            objectToPlace = objectToPlace4;
        }
        else if (n == 5)
        {
            objectToPlace = objectToPlace5;
        }
    }
}
