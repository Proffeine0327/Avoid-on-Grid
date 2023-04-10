using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorCamera : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOrigin;

    private void Awake() 
    {
        cam = GetComponent<Camera>();    
    }

    private void Update() 
    {
        Drag();
        ZoomInOut();
    }

    private void Drag()
    {
        if(Input.GetMouseButtonDown(1))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        if(!Input.GetMouseButton(1)) return;

        var diff = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.position = dragOrigin - diff;
    }

    private void ZoomInOut()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            cam.orthographicSize -= Input.mouseScrollDelta.y * 0.25f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 30);
        }
    }
}
