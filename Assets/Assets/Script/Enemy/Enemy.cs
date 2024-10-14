using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PerceptionComp perceptionComp;
    GameObject target;
    void Start()
    {
        perceptionComp.OnPerceptionTargetChanged += Enemy_TargetChanged;
    }

    private void Enemy_TargetChanged(object sender, PerceptionComp.TargetStimuli e)
    {
        if(e.sensed){
            target=e.stimuli;
        }
        else {
            target=null;
        }
    }
    private void OnDrawGizmos() {
        if(target!=null){
            Gizmos.DrawWireSphere(target.transform.position,0.7f);
            Gizmos.DrawLine(transform.position,target.transform.position);
        }
    }
}
