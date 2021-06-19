using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    Vector3 targetDir = Vector3.right;
    public float Speed;
    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 3f);
        
        if (hit.collider != null){
            if (targetDir == Vector3.right){
                targetDir = Vector3.left;
            }
            else{
                targetDir = Vector3.right;
            }
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        transform.Translate(targetDir * Speed * Time.deltaTime);
        
    }
}
