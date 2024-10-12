using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{   
    // [SerializeField] private float timeDurationToggleWeapon=0.5f;
    public event EventHandler ToggleAnimPlayer;
    public Transform WeaponCurrent{get;set;}
    private float timeBetweenAttack;

    private bool isAttack,attacking=false;
    protected override void Awake() {
        base.Awake();
    }
    private void Start()
    {
        PlayerInput.Instance.PlayerInputOnAttack += ActiveWeapon_OnAttack;
        PlayerInput.Instance.PlayerInputCancelAttack += ActiveWeapon_CancelAttack;
        AttackCountDown();
    }
    void Update()
    {
        Attack();   
    }
    public void WeaponNull(){
        WeaponCurrent=null;
    }
    public void NewWeapon(Transform weaponCurrent){
        WeaponCurrent=weaponCurrent;
        AttackCountDown();
        timeBetweenAttack=weaponCurrent.GetComponent<IWeapon>().GetWeaponInfo().weaponCountDown;
    }
    private void ActiveWeapon_CancelAttack(object sender, EventArgs e)
    {
        isAttack=false;
    }

    private void ActiveWeapon_OnAttack(object sender, EventArgs e)
    {
        isAttack=true;
    }
    private void AttackCountDown(){
        attacking=true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttackCountDown());
    }
    IEnumerator TimeBetweenAttackCountDown(){
        yield return new WaitForSeconds(timeBetweenAttack);
        attacking=false;
    }
    private void Attack()
    {
        if(isAttack && !attacking){
            AttackCountDown();
            ToggleAnimPlayer?.Invoke(this,EventArgs.Empty);
            WeaponCurrent.gameObject.SetActive(true);
            IWeapon weapon =WeaponCurrent.GetComponent<IWeapon>();
            weapon?.Attack();
        }
    }
    public bool IsAttack(){
        return isAttack;
    }
    public float getTimeBeetweenAttack(){
        return timeBetweenAttack;
    }
}
