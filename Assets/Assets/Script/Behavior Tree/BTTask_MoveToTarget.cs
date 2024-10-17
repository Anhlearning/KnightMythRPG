using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTTask_MoveToTarget : BTNode
{
    string targetkey;
    GameObject targetObject;
    float acceptableDistance;
    NavMeshAgent navMeshAgent;
    BehaviorTree behaviorTree;
    public BTTask_MoveToTarget(string targetkey,float acceptableDistance,BehaviorTree behaviorTree){
        this.targetkey=targetkey;
        this.acceptableDistance=acceptableDistance;
        this.behaviorTree=behaviorTree;
    }
    protected override NodeResult Excute()
    {
        navMeshAgent=behaviorTree.GetComponent<NavMeshAgent>();
        BlackBoard blackBoard=behaviorTree.Blackboard;
        if(blackBoard==null || !blackBoard.GetBlackBoardData(targetkey,out targetObject)){
            return NodeResult.Failure;
        }
        if(IsTargetInAcceptable()){
            return NodeResult.Succes;
        }
        if(navMeshAgent==null){
            return NodeResult.Failure;
        }
        blackBoard.OnBlackBoardValueChange+= BlackBoardValueChange;
        navMeshAgent.SetDestination(targetObject.transform.position);
        navMeshAgent.isStopped=false;
        return NodeResult.Processing;
    }

    private void BlackBoardValueChange(object sender, BlackBoard.BlackBoardEventArgs e)
    {
        if(targetkey==e.key){
            targetObject=(GameObject)e.val;
        }
    }

    protected override NodeResult Update()
    {
        if(targetObject ==null){
            navMeshAgent.isStopped=true;
            return NodeResult.Failure;
        }
        navMeshAgent.SetDestination(targetObject.transform.position);
        if(IsTargetInAcceptable()){
            navMeshAgent.isStopped=true;
            return NodeResult.Succes;
        }
        return NodeResult.Processing;
    }
    private bool IsTargetInAcceptable(){
        return Vector2.Distance(behaviorTree.gameObject.transform.position,targetObject.transform.position)<=acceptableDistance;
    }
}
