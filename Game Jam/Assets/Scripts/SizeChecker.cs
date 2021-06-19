using System.Collections;
using System.Collections.Generic;
using Destructible2D.Examples;
using UnityEngine;

public class SizeChecker : MonoBehaviour
{
    public float SizeLvl1;
    public float SizeLvl2;
    public float SizeLvl3;

    public D2dRepeatStamp RepeatStamp;
    
    public void CheckSize(){
        if (transform.localScale.x >= SizeLvl1){
            RepeatStamp.Layers += LayerMask.GetMask("One");
        }
        
        
    }
    
    
    
    
}
