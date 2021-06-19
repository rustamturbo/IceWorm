using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall: MonoBehaviour
{
    public GameObject[] boxes;
   
    private void OnCollisionEnter2D(Collision2D other){
        if (other.transform.tag == "Player"){
            foreach (var b in boxes){
                b.transform.parent = null;
                b.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
