using System;
using System.Collections;
using System.Collections.Generic;
using Destructible2D.Examples;
using UnityEngine;
using UnityEngine.UI;

public class WormMover: MonoBehaviour
{
    public Animator Animator;
    public float TimeOff;
    public float Force;
    public Camera _camera;
    private Vector3 _startPos;
    public Rigidbody2D _rb;
    public Transform Head;
    public float RotationForce;
    public GameObject[] Grounds;
    public D2dRepeatStamp rs;
    private float _time;
    public bool IsDash;
    public bool OnGround;
    
   

    private void Update(){
        if (OnGround){
            CheckSwipe();
        }

        TransformHead();
        if (IsDash){
            _time += Time.deltaTime;
            if (_time >= TimeOff){
                OnGroundCollider();
                IsDash = false;
            }
        }
    }

    void Dash(float force, Vector3 direction){

        _rb.AddForce(-force * direction * Force, ForceMode2D.Impulse);
        IsDash = true;
        OffGroundCollider();

    }


    void CheckSwipe(){
        if (Input.GetMouseButtonDown(0)){
            _startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _startPos = new Vector3(_startPos.x, _startPos.y, 0);
        }
        if (Input.GetMouseButtonUp(0)){
            Vector3 endPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            endPos = new Vector3(endPos.x, endPos.y, 0);
            float force = Vector3.Distance(_startPos, endPos);
            Vector3 dir = (endPos - _startPos).normalized;
            if (force > 6f){
                Dash(force, dir);
            }
        }
    }
    void TransformHead(){
        if (_rb.velocity.magnitude < 2){
            return;
        }
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * _rb.velocity;
        Quaternion lookAtVelocity = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
        Head.rotation = Quaternion.Lerp(Head.rotation, lookAtVelocity, RotationForce * Time.deltaTime);

    }


    void OffGroundCollider(){
        Animator.SetBool("Dashing", true);
        _time = 0;
        rs.enabled = true;
        for (int i = 0; i < Grounds.Length; i++){
            Grounds[i].layer = LayerMask.NameToLayer("IgnorePlayer");
        }
    }

    void OnGroundCollider(){
        Animator.SetBool("Dashing", false);
        _time = 0;
        rs.enabled = false;
        for (int i = 0; i < Grounds.Length; i++){
            Grounds[i].layer = LayerMask.NameToLayer("Default");
        }
    }

}
