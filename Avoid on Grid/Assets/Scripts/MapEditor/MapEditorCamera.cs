using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorCamera : MonoBehaviour
{
    public static MapEditorCamera manager { get; private set; }

    private Camera cam;
    private Vector3 dragOrigin;

    public Vector3 WorldMousePosition => cam.ScreenToWorldPoint(Input.mousePosition);

    private void Awake() 
    {
        manager = this;
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
            dragOrigin = WorldMousePosition;
            return;
        }

        if(!Input.GetMouseButton(1)) return;

        var diff = WorldMousePosition - transform.position;
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
