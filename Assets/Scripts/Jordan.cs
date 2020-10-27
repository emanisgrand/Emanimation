using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jordan : MonoBehaviour {
    
    [SerializeField] float m_onClickGravity = 4f;
    Rigidbody2D m_rigidbody2D;
    private float rotationZ;
    private float rotationSpeed;
    
    void Awake() {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        m_rigidbody2D.gravityScale = 0;
    }

    private void OnMouseDown() {
        if (m_rigidbody2D != null)
            m_rigidbody2D.gravityScale = m_onClickGravity;
    }
}
