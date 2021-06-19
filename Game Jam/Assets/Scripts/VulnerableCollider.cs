using System;
using System.Collections;
using System.Collections.Generic;
using Scripts_2;
using UnityEngine;

public class VulnerableCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other){
        if (other.transform.GetComponent<Bug>()){
            transform.parent.GetComponent<WormSegments>().DestroySegment();
        }
        
    }


}
