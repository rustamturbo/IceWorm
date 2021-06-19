using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bug : MonoBehaviour
{
    private Vector3 point;
    public float Speed;
    private Vector3 _startPos;
    public Transform target;
    public float PatrolRadius;
    public float Distance;
    public enum State
    {
        Patrol,
        Attack
    }

    public State currentState = State.Patrol;
    
    
    
    
    private void Start(){
        _startPos = transform.position;
        point = GetRandomPointOnBox(PatrolRadius);
        
    }

    private void Update(){
        switch (currentState){
            case State.Patrol:
                Patrol(point);
                break;
            case State.Attack:
                Attack();
                break;
        }
      
        
    }

    void Patrol(Vector3 point){
        //transform.LookAt(point);
        transform.position = Vector3.MoveTowards(transform.position, point, Speed * Time.deltaTime);
        if (transform.position == point){
            this.point = GetRandomPointOnBox(PatrolRadius);
        }
    }



    Vector3 GetRandomPointOnBox(float radius){
        float x = Random.Range(-radius, radius);
        float y = Random.Range(-radius, radius);

        return new Vector3(x + _startPos.x, y + _startPos.y, 0);
    }

    void Attack(){
        if (target == null){
            currentState = State.Patrol;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        CheckHome();
    }


    void CheckHome(){
        float distance = Vector3.Distance(transform.position, _startPos);
        if (distance > Distance){
            currentState = State.Patrol;
            point = GetRandomPointOnBox(PatrolRadius);
        }
        
    }
  


}
