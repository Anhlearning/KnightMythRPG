using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTTask_MoveToPatrolling : BTNode
{
    string key;
    Vector2 target;
    BehaviorTree tree;
    NavMeshAgent navMeshAgent;
    float acceptableDistance=2f;
    public BTTask_MoveToPatrolling(BehaviorTree tree,string key,float distance){
        this.tree=tree;
        this.key=key;
        this.acceptableDistance=distance;
    }

    protected override NodeResult Excute()
    {
        BlackBoard blackBoard=tree.Blackboard;
        if(blackBoard ==null || !blackBoard.GetBlackBoardData(key,out target)){
            return NodeResult.Failure;
        }
        navMeshAgent=tree.GetComponent<NavMeshAgent>();
        if(navMeshAgent==null){
            return NodeResult.Failure;
        }
        if(isAcceptableDistance()){
            return NodeResult.Succes;
        }
        navMeshAgent.SetDestination(target);
        navMeshAgent.isStopped=false;
        return NodeResult.Processing;
    }
    protected override NodeResult Update()
    {
        if(isAcceptableDistance()){
            navMeshAgent.isStopped=true;
            return NodeResult.Succes;
        }
        return NodeResult.Processing;
    }
    protected override void End()
    {
        Debug.Log("END Patrolling");
        navMeshAgent.isStopped=true;
        base.End();
    }

    private bool isAcceptableDistance(){
        return Vector2.Distance(tree.transform.position,target)<=acceptableDistance;
    }
}
