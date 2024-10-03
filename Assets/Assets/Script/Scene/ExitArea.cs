using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{   
    [SerializeField]private string SceneToLoad;
    [SerializeField]private string sceneTrans;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Player>()){
            SceneManager.LoadScene(SceneToLoad);
            SceneManagement.Instance.SetTransitionScene(sceneTrans);
            CameraManager.Instance.SetCameraFollow();
        }
    }
}
