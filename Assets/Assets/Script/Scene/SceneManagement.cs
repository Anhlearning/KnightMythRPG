using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : Singleton<SceneManagement>
{  
    public string TransitionScene{get;private set;}
    public void SetTransitionScene(string sceneTrans){
        this.TransitionScene=sceneTrans;
    }
}
