using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour
{
    private Vector3 _startPos;
    public float ParallaxEffect;
    [SerializeField] private Transform _cameraTransform;


   
    private void Start(){
        _startPos = transform.position;
    }


    private void FixedUpdate(){


        float dist =  (_cameraTransform.position.x - _startPos.x) * ParallaxEffect;
        transform.position = new Vector3(_startPos.x + dist, transform.position.y, 0);
    }

}
