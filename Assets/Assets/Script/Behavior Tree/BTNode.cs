using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeResult{
    Succes,
    Failure,
    Processing
}
public class BTNode 
{
    private bool started=false;
    int priority;
    public NodeResult UpdateNode(){
        if(!started){
            started=true;
            NodeResult nodeResult = Excute();
            if(nodeResult != NodeResult.Processing){
                EndNode();
                return nodeResult;
            }
        }
        NodeResult nodeUpdate=Update();
        if(nodeUpdate != NodeResult.Processing){
            EndNode();
        }
        return nodeUpdate;
    }
    protected virtual NodeResult Excute(){
        return NodeResult.Succes;
    }
    protected virtual void End(){

    }
    protected virtual NodeResult Update(){
        return NodeResult.Succes;
    }
    private void EndNode(){
        started=false;
        End();
    }
    public virtual void Abort(){
        EndNode();
    }
    public virtual BTNode Get(){
        return this;
    }
    public int getPriority(){
        return priority;
    }
    public virtual void SortPriority(ref int priorityRef){
        priority=priorityRef++;
        Debug.Log($"{this} has priority {priority}");
    }
}
