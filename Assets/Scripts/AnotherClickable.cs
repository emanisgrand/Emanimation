using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherClickable : MonoBehaviour, IClickable
{
    //private static readonly int IsClicked = Animator.StringToHash("Clicked");
    Animator _anim;
    Rigidbody2D _rb2D;
    
    void Awake()
    {
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb2D.simulated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()  {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            GetClicked();
        }
    }
    
    public void GetClicked()
    {
        _rb2D.simulated = true;
    }
}
