using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PerceptionComp perceptionComp;
    [SerializeField] private BehaviorTree behaviorTree;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        perceptionComp.OnPerceptionTargetChanged += Enemy_TargetChanged;
        navMeshAgent=GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation=false;
        navMeshAgent.updateUpAxis=false;
        
    }

    private void Enemy_TargetChanged(object sender, PerceptionComp.TargetStimuli e)
    {
        if(e.sensed){
            behaviorTree.Blackboard.SetOrAddData("target",e.stimuli.gameObject);
        }
        else {
            behaviorTree.Blackboard.RemoveData("target");
        }
    }
    private void OnDrawGizmos() {
        if(behaviorTree && behaviorTree.Blackboard.GetBlackBoardData("target",out GameObject target)){
            Gizmos.DrawWireSphere(target.transform.position,0.7f);
            Gizmos.DrawLine(transform.position,target.transform.position);
        }
    }
}
