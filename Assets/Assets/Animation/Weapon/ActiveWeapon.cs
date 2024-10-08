using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{   
    public event EventHandler ToggleAnimPlayer;
    [SerializeField] private Transform weaponCurrent;
    private bool isAttack,attacking=false;
    protected override void Awake() {
        base.Awake();
    }
    private void Start()
    {
        PlayerInput.Instance.PlayerInputOnAttack += ActiveWeapon_OnAttack;
        PlayerInput.Instance.PlayerInputCancelAttack += ActiveWeapon_CancelAttack;
    }

    private void ActiveWeapon_CancelAttack(object sender, EventArgs e)
    {
        isAttack=false;
    }

    private void ActiveWeapon_OnAttack(object sender, EventArgs e)
    {
        isAttack=true;
    }

    void Update()
    {
        Attack();   
    }
    public void ToggleAticeAttack(bool value){
        attacking=value;
    }
    private void Attack()
    {
        if(isAttack && !attacking){
            attacking=true;
            ToggleAnimPlayer?.Invoke(this,EventArgs.Empty);
            weaponCurrent.gameObject.SetActive(true);
            IWeapon weapon =weaponCurrent.GetComponent<IWeapon>();
            weapon?.Attack();
        }
    }
    public bool IsAttack(){
        return isAttack;
    }
}
