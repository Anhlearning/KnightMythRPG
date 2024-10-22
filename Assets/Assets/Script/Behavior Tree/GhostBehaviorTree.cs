using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviorTree : BehaviorTree
{
    // [SerializeField] private float waitTime=2f;
    protected override void Constructree(out BTNode root)
    {
        Selector selector= new Selector();
        Sequencer attackMoveToTarget= new Sequencer();
        BTTask_MoveToTarget moveToTarget = new BTTask_MoveToTarget("target",2f,this);
        attackMoveToTarget.AddChild(moveToTarget);
        BlackBoardDecorator blackBoardDecorator = new BlackBoardDecorator(attackMoveToTarget,this,"target",
                                                    BlackBoardDecorator.Runcondition.KeyExits,BlackBoardDecorator.NotifyRule.RunconditionChange,BlackBoardDecorator.NotifyAbort.both);

        selector.AddChild(blackBoardDecorator);

        Sequencer sequencerMoveLoc=new Sequencer();

        BTTask_GetPatrolling bTTask_GetPatrolling=new BTTask_GetPatrolling(this,"patrolling");
        BTTask_MoveToPatrolling bTTask_MoveToPatrolling=new BTTask_MoveToPatrolling(this,"patrolling",1.5f);
        BTTask_Wait bTTask_Wait=new BTTask_Wait(2f);

        sequencerMoveLoc.AddChild(bTTask_GetPatrolling);
        sequencerMoveLoc.AddChild(bTTask_MoveToPatrolling);
        sequencerMoveLoc.AddChild(bTTask_Wait);

        selector.AddChild(sequencerMoveLoc);
        
        root=selector;
    }
}
