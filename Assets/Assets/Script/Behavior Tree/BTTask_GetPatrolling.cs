using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTask_GetPatrolling : BTNode
{
    PatrollingComp patrollingComp;
    BehaviorTree tree;
    string patrollingKey;
    Vector2 patrollingPos;
    public BTTask_GetPatrolling(BehaviorTree tree,string key){
        this.tree=tree;
        patrollingComp=tree.GetComponent<PatrollingComp>();
        this.patrollingKey=key;
    }

    protected override NodeResult Excute()
    {
        if(patrollingComp!=null &&patrollingComp.GetNextPatrolling(out patrollingPos)){
            tree.Blackboard.SetOrAddData(patrollingKey,patrollingPos);
            Debug.Log(patrollingPos);
            return NodeResult.Succes;
        }
        return NodeResult.Failure;
    }

}
