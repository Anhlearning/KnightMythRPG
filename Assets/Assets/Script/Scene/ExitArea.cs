using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{   
    [SerializeField]private string SceneToLoad;
    [SerializeField]private string sceneTrans;

    private float wattingLoadScene=1f;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Player>()){
            SceneManagement.Instance.SetTransitionScene(sceneTrans);
            FadeTransition.Instance.FadeToBlack();
            StartCoroutine(LoadSceneCroutine());
        }
    }
    IEnumerator LoadSceneCroutine(){
        while(wattingLoadScene >=0){
            wattingLoadScene-=Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneToLoad);
    }
}
