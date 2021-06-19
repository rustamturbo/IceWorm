using System;
using System.Collections;
using System.Collections.Generic;
using Destructible2D.Examples;
using Scripts_2;
using UnityEngine;

public class Head: MonoBehaviour
{
    public CameraFollow CameraFollow;
    public SizeChecker SizeChecker;
    public WormSegments WormSegments;
    public WormMover WormMover;
    public D2dRepeatStamp RepeatStamp;
    public float RayScaler;
    private void OnTriggerEnter2D(Collider2D other){
        Food food = other.GetComponent<Food>();
        if (food){
            transform.localScale = new Vector3(transform.localScale.x * food.FoodValue, transform.localScale.y * food.FoodValue, 1);
            RepeatStamp.Size += new Vector2(food.FoodValue, food.FoodValue);
            SizeChecker.CheckSize();
            WormSegments.TryAddSegment();
            CameraFollow.ChangeSize();
            Destroy(food.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        Bug bug = other.transform.GetComponent<Bug>();
        if (bug && WormMover.IsDash){
            Destroy(bug.gameObject);
        }
    }




    private void Update(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.x *RayScaler, LayerMask.GetMask("Default"), -Mathf.Infinity, -1);
        Debug.DrawRay(transform.position, Vector2.down * transform.localScale.x * RayScaler);
        if (hit.collider != null){
            Debug.Log(hit.collider.gameObject.name);
            WormMover.OnGround = true;
        }
        else{
            WormMover.OnGround = false;
        }
    }


}
