using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTree : MonoBehaviour
{
    BTNode bTNode;
    BlackBoard blackBoard= new BlackBoard();
    
    public BlackBoard Blackboard{
        get{return blackBoard;}
    }
    void Start()
    {
        Constructree(out bTNode);
    }
    protected abstract void Constructree(out BTNode root);

    
    // Update is called once per frame
    void Update()
    {
        bTNode.UpdateNode();
    }
}
