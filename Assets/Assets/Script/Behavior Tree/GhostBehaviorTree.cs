using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviorTree : BehaviorTree
{
    // [SerializeField] private float waitTime=2f;
    protected override void Constructree(out BTNode root)
    {
        Sequencer sequencer=new Sequencer();
        BTTask_GetPatrolling bTTask_GetPatrolling=new BTTask_GetPatrolling(this,"patrolling");
        BTTask_MoveToPatrolling bTTask_MoveToPatrolling=new BTTask_MoveToPatrolling(this,"patrolling",1.5f);
        BTTask_Wait bTTask_Wait=new BTTask_Wait(2f);
        sequencer.AddChild(bTTask_GetPatrolling);
        sequencer.AddChild(bTTask_MoveToPatrolling);
        sequencer.AddChild(bTTask_Wait);
        root=sequencer;
    }
}
