using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public Transform HeadTransform;
    public Camera Camera;
    public Transform leftBotPoint;
    public Transform rightTopPoint;
    public float SpeedLerp;
    public float ScalerCamera;
    
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothness;
    private float height;
    private float width;
    private float _startSize;
    private float newCameraSize;

    private void Start(){
       RecalculateSize();
       _startSize = Camera.orthographicSize - HeadTransform.localScale.x;
       newCameraSize = Camera.orthographicSize;
    }

    private void Update(){
        Vector3 target = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, _smoothness * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(
                                             transform.position.x,
                                             leftBotPoint.position.x + width / 2,
                                             rightTopPoint.position.x - width / 2),
                                         Mathf.Clamp(
                                             transform.position.y,
                                             leftBotPoint.position.y + height / 2,
                                             rightTopPoint.position.y - height / 2),
                                         transform.position.z);
        Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, newCameraSize, SpeedLerp * Time.deltaTime);

    }

        
    public void ChangeSize(){
        newCameraSize = _startSize + HeadTransform.localScale.x * ScalerCamera;
        RecalculateSize();
    }



    void RecalculateSize(){
        height = 2f * Camera.orthographicSize;
        width = height * Camera.aspect;
    }

}
