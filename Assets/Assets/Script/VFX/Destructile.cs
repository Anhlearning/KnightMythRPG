using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Destructile : MonoBehaviour
{
    [SerializeField] private GameObject destroyGameObjectVFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<DamageSource>()){
            Debug.Log("DESTRUCT");
            GameObject destroyGameObjectVFXTmp=Instantiate(destroyGameObjectVFX,transform.position,UnityEngine.Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
