using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    float zoomOutMin = 1.2f;
    float zoomoutMax = 2.0f;
    private Camera m_camera;

    private void Awake() {
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        ZoomScroll(Input.GetAxis("Mouse ScrollWheel"));
    }

    void ZoomScroll(float increment) {
        m_camera.orthographicSize
            = Mathf.Clamp(m_camera.orthographicSize 
                          - increment, zoomOutMin, zoomoutMax);
    }
}
