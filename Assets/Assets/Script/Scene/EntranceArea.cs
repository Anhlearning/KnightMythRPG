using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceArea : MonoBehaviour
{
    [SerializeField] private string transitionName;
   private void Start() {
        if(transitionName==SceneManagement.Instance.TransitionScene){
            FadeTransition.Instance.FadeToClear();
            Player.Instance.transform.position=this.transform.position;
            CameraManager.Instance.SetCameraFollow();
        }
   }
}
