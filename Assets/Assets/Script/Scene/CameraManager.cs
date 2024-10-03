using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public void SetCameraFollow(){
        cinemachineVirtualCamera=FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow=Player.Instance.transform;
    }
}
   

