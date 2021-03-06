﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    float m_minPanX, m_minPanY, m_maxPanX, m_maxPanY;
    [SerializeField] SpriteRenderer m_panLimit;
    
    Vector3 m_camDragFrom;
    Vector3 m_camDragTo;
    
    Camera m_cam;

    private void Awake() {
        m_cam = Camera.main;
        
        var position = m_panLimit.transform.position;
        var bounds = m_panLimit.bounds;

        m_minPanX = position.x - bounds.size.x / 2;
        m_minPanY = position.y - bounds.size.y / 2;
        m_maxPanX = position.x + bounds.size.x / 2;
        m_maxPanY = position.y + bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update() 
    {
        PanCam();
    }

    void PanCam()
    {
        //start Pan or move objects at mouse position
        if (Input.GetMouseButtonDown(2)) {
            m_camDragFrom = m_cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
        // Pan at mouse position
        if (Input.GetMouseButton(2)) {
            Vector3 difference 
                = m_camDragFrom - m_cam.ScreenToWorldPoint(Input.mousePosition);
            
            m_cam.transform.position = CameraClamp(m_cam.transform.position + difference);
        }
    }

    Vector3 CameraClamp(Vector3 boundPosition) {
        var orthographicSize = m_cam.orthographicSize;
        
        float camHeight = orthographicSize;
        float camWidth = orthographicSize * m_cam.aspect;

        float minX = m_minPanX + camWidth;
        float maxX = m_maxPanX - camWidth;
        float minY = m_minPanY + camHeight;
        float maxY = m_maxPanY - camHeight;

        float newX = Mathf.Clamp(boundPosition.x, minX, maxX);
        float newY = Mathf.Clamp(boundPosition.y, minY, maxY);
        
        return new Vector3(newX, newY, boundPosition.z);
    }
}
