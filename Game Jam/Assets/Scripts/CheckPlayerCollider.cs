using System;
using UnityEngine;

namespace Scripts_2
{
    public class CheckPlayerCollider: MonoBehaviour
    {
        private Bug bug;
        private void Start(){
            bug = transform.parent.GetComponent<Bug>();
        }
        private void OnTriggerEnter2D(Collider2D other){
            VulnerableCollider vc = other.GetComponent<VulnerableCollider>();
            if (vc && bug.currentState != Bug.State.Attack){
                bug.currentState = Bug.State.Attack;
                bug.target = vc.transform;
            }
            
            if (bug.currentState == Bug.State.Attack && bug.target == null){
                if (vc){
                    bug.target = vc.transform;
                }
                
            }
            
            
            
        }

    }
}
