using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compositor : BTNode
{
    LinkedList<BTNode> child= new LinkedList<BTNode>();
    LinkedListNode<BTNode>currentChild;

    public void AddChild(BTNode bTNode){
        child.AddLast(bTNode);
    }
    protected override NodeResult Excute()
    {
        if(child.Count ==0){
            return NodeResult.Failure;
        }
        currentChild=child.First;
        return NodeResult.Processing;
    }
    protected BTNode getChildCurrent(){
        return currentChild.Value;
    }
    public bool Next(){
        if(currentChild != child.Last){
            currentChild=currentChild.Next;
            return true;
        }
        return false;
    }
    protected override void End()
    {   
        if(currentChild==null){
            return ;
        }
        currentChild.Value.Abort();
        currentChild=null;
    }
    public override BTNode Get()
    {
        if(currentChild ==null){
            if(child.Count == 0){
                return this;
            }
            else {
                return child.First.Value.Get();
            }
        }
        return currentChild.Value.Get();
    }
    public override void SortPriority(ref int priorityRef)
    {
        base.SortPriority(ref priorityRef);
        foreach(BTNode child in child){
            child.SortPriority(ref priorityRef);
        }
    }
} 
