using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour
{
    public Transform minTransform;
    private Vector3 _startPos;
    public float ParallaxEffectX;
    public float ParallaxEffectY;
    [SerializeField] private Transform _cameraTransform;


    private void Start(){
        _startPos = transform.position;
    }


    private void FixedUpdate(){


        float distX = (_cameraTransform.position.x - _startPos.x) * ParallaxEffectX;
        float distY = (_cameraTransform.position.y - _startPos.y) * ParallaxEffectY;
        transform.position = new Vector3(_startPos.x + distX, Mathf.Clamp((_startPos.y + distY), minTransform.position.y, Mathf.Infinity), 0);
    }

}
