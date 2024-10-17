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
}
