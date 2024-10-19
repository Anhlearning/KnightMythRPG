using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingComp : MonoBehaviour
{
    [SerializeField] Transform[] patrollingPoint;
    int currentIdx=-1; 

    public bool GetNextPatrolling(out Vector2 point){
        point=Vector2.zero;
        if(patrollingPoint.Length==0){
            return false;
        }
        point=patrollingPoint[(currentIdx+=1)%patrollingPoint.Length].position;
        return true;
    }
}
