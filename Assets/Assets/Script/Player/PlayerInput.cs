using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance{set;get;}
    private PlayerController playerController;
    public event EventHandler PlayerInputOnAttack;
    public event EventHandler PlayerInputCancelAttack;
    public event EventHandler playerInputOnDash;
    public event EventHandler<IndexActiveEventArgs> PlayerInputActiveSlotInventory;

    public class IndexActiveEventArgs : EventArgs{
        public int indexActive;
    }
    // Start is called before the first frame update
    private void Awake() {
        Instance=this;
        playerController= new PlayerController();
        playerController.Enable();
    }
    private void OnEnable() {
    }
    private void Start()
    {
        playerController.Attack.Attack.performed += PlayerController_OnAttackInput;
        playerController.Attack.Attack.canceled += PlayerController_CancelAttackInput;
        playerController.Movement.Dash.performed += PlayerController_OnDash;
        playerController.Inventory.KeyBoard.performed += PlayerController_ActiveInventorySlot;
    }

    private void PlayerController_ActiveInventorySlot(InputAction.CallbackContext context)
    {   
        PlayerInputActiveSlotInventory?.Invoke(this,new IndexActiveEventArgs{
            indexActive=(int)context.ReadValue<float>()
        });
    }

    private void PlayerController_OnDash(InputAction.CallbackContext context)
    {
       playerInputOnDash?.Invoke(this,EventArgs.Empty);
    }

    private void PlayerController_CancelAttackInput(InputAction.CallbackContext context)
    {
        PlayerInputCancelAttack?.Invoke(this,EventArgs.Empty);
    }

    private void PlayerController_OnAttackInput(InputAction.CallbackContext context)
    {
        PlayerInputOnAttack?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormolized(){
        Vector2 inputvector= playerController.Movement.Move.ReadValue<Vector2>();
        return inputvector.normalized;
    }
    public int GetIndexInventory(){
        int indexInventory=(int)playerController.Inventory.KeyBoard.ReadValue<float>();
        return indexInventory;
    }
}
