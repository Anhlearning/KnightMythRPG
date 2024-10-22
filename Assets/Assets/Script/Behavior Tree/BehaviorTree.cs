using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTree : MonoBehaviour
{
    BTNode bTNode;
    BlackBoard blackBoard= new BlackBoard();
    BTNode preNode;
    public BlackBoard Blackboard{
        get{return blackBoard;}
    }
    void Start()
    {
        Constructree(out bTNode);
        SortTree();
    }
    protected abstract void Constructree(out BTNode root);

    private void SortTree(){
        int priorityRef=0;
        bTNode.SortPriority(ref priorityRef);

    }
    // Update is called once per frame
    void Update()
    {
        bTNode.UpdateNode();
        // BTNode currentNode=bTNode.Get();
        // if(preNode != currentNode){
        //     preNode =currentNode;
        //     Debug.Log($"current Node Changed to {preNode}");
        // }
    }
    public void AbortLowerSelf(int priority){
        BTNode bTNodeCurrent = bTNode.Get();
        if(bTNodeCurrent.getPriority() > priority ){
            bTNode.Abort();
        }
    }
}
