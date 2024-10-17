using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviorTree : BehaviorTree
{
    [SerializeField] private float waitTime=2f;
    protected override void Constructree(out BTNode root)
    {
        root= new BTTask_MoveToTarget("target",2f,this);
    }
}
