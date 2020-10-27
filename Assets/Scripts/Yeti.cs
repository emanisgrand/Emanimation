using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : MonoBehaviour {
    
    Animator m_animator;
    private static readonly int Clicked = Animator.StringToHash("Clicked");

    private void Awake() {
        m_animator = GetComponent<Animator>();
    }

    private void OnMouseDown() {
        m_animator?.SetTrigger(Clicked);
    }
}
