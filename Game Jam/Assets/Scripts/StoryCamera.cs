using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCamera: MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    
    public float FinishYCoordinate;
    public float Speed;
    public GameObject[] UnEnabled;
    public MonoBehaviour[] MonoEnabled;

    public GameObject DisableCanvas;

    private bool _isStart;


    private void Start(){

        foreach (var go in UnEnabled){
            go.SetActive(false);
        }
        foreach (var mono in MonoEnabled){
            mono.enabled = false;
        }
    }


    public void StartMove(){
        DisableCanvas.SetActive(false);
        _isStart = true;
    }


    private void Update(){
        if (_isStart == false) return;

        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= FinishYCoordinate){
            MakeEnabled();
            Camera1.enabled = true;
            Destroy(gameObject);
        }


    }


    void MakeEnabled(){
        foreach (var go in UnEnabled){
            go.SetActive(true);
        }
        foreach (var mono in MonoEnabled){
            mono.enabled = true;
        }
    }


}
