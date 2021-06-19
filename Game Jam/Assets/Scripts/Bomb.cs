using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Scripts_2;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]private PointEffector2D pe;
    private void OnTriggerEnter2D(Collider2D other){
        pe.enabled = true;
        WormSegments.Instance.DestroySegment();
        Invoke(nameof(DestroyBomb) , 0.2f);
    }

    void DestroyBomb(){
        Destroy(pe.gameObject);
    }


}
