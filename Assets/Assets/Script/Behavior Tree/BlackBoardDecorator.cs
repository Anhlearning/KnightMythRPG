using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlackBoardDecorator : Decorator
{
    public enum Runcondition{
        KeyExits,
        KeyNotExits
    }
    public enum NotifyRule{
        RunconditionChange,
        KeyValueChange
    }
    public enum NotifyAbort{
        None,
        self,
        lower,
        both
    }
    string key;
    GameObject targetObject;
    BehaviorTree tree;
    Runcondition runcondition;
    NotifyRule notifyRule;
    NotifyAbort notifyAbort;

    public BlackBoardDecorator(BTNode child,BehaviorTree tree,string key,Runcondition runcondition,NotifyRule notifyRule,NotifyAbort notifyAbort) : base(child)
    {
        this.tree=tree;
        this.key=key;
        this.runcondition=runcondition;
        this.notifyAbort=notifyAbort;
        this.notifyRule=notifyRule;
    }
    protected override NodeResult Excute()
    {
        BlackBoard blackBoard= tree.Blackboard;
        if(blackBoard==null){
            return NodeResult.Failure;
        }
        blackBoard.OnBlackBoardValueChange -= CheckNotify;
        blackBoard.OnBlackBoardValueChange += CheckNotify;
        if(CheckCondition()){
            return NodeResult.Processing;
        }
        else {
            return NodeResult.Failure;
        }
    }
    protected override NodeResult Update()
    {
        return GetChild().UpdateNode();
    }

    private bool CheckCondition()
    {
        bool exits = tree.Blackboard.GetBlackBoardData(key,out targetObject);
        switch(runcondition){
            case Runcondition.KeyExits:
                return exits;
            case Runcondition.KeyNotExits:
                return !exits;
        }
        return false;
    }

    private void CheckNotify(object sender, BlackBoard.BlackBoardEventArgs e)
    {
        if(key != e.key){
            return ;
        }
        if(notifyRule == NotifyRule.RunconditionChange){
            bool preExits=targetObject !=null;
            bool currentExits=e.val !=null;
            if(preExits !=currentExits){
                Notify();
            }
        }
        else if(notifyRule == NotifyRule.KeyValueChange){
            if(targetObject !=(GameObject)e.val){
                Notify();
            }
        }
    }

    private void Notify()
    {
        switch (notifyAbort)
        {
            case NotifyAbort.None:
                break;
            case NotifyAbort.self:
                AbortSelft();
                break;
            case NotifyAbort.lower:
                Abortlower();
                break;
            case NotifyAbort.both:
                AbortBoth();
                break;
        }
    }

    private void AbortSelft()
    {
        Abort();
    }

    private void AbortBoth()
    {
        Abort();
        Abortlower();
    }

    private void Abortlower()
    {
        tree.AbortLowerSelf(getPriority());
    }
    protected override void End()
    {
        GetChild().Abort();
        base.End();
    }
}
