using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField]
    private Material whiteFlash;
    [SerializeField]
    private float restoreMatTime;
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        enemyHealth=GetComponent<EnemyHealth>();
        defaultMaterial=spriteRenderer.material;
    }
    public IEnumerator FlashRoutine(){
        spriteRenderer.material=whiteFlash;
        yield return new WaitForSeconds(restoreMatTime);
        spriteRenderer.material=defaultMaterial;
        enemyHealth.DetectDeath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
