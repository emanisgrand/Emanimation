using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour {
  [SerializeField] AnimationCurve m_animCurve;
  
  float m_startScale;
  float m_endScale;

  static float _t = 0.0f;

  void Awake() {
    m_startScale = gameObject.transform.localScale.x;
    m_endScale = m_startScale + 0.04f;
  }

  void Update() {
    transform.localScale 
      = new Vector2(Mathf.Lerp(m_startScale, m_endScale, m_animCurve.Evaluate(_t)), 1);
    
    _t += 0.47f * Time.deltaTime;

    if (_t > m_endScale) {
      float temp = m_endScale;
      m_endScale = m_startScale;
      
      m_startScale = temp;
      _t = 0.0f;
    }
  }
}
