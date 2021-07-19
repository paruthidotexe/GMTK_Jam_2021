///-----------------------------------------------------------------------------
///
/// PlayerController
/// 
/// Player Controller with new input systems
///
///-----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 moveDirInputAction = Vector2.zero;
    Vector3 moveDir = Vector3.zero;

    public delegate void OnMove(Vector3 moveDir);
    public static event OnMove OnMoveAction;


    void Start()
    {
    }


    void Update()
    {

    }


    public void OnMoveInputAction(InputAction.CallbackContext context)
    {
        //if (context.performed)
        //{
        //    //Debug.Log("OnMoveInputAction : " + context.ReadValue<Vector2>());
        //    //Debug.Log(context.ReadValue<Vector3>());
        //    //moveDirInputAction = context.ReadValue<Vector2>();
        //    moveDir.x = moveDirInputAction.x;
        //    moveDir.y = 0;
        //    moveDir.z = moveDirInputAction.y;
        //    Raise_OnMoveAction(moveDir);
        //}
    }


    // Events
    void Raise_OnMoveAction(Vector3 moveDir)
    {
        if (OnMoveAction != null)
            OnMoveAction(moveDir);
    }


    public void OnMoveLeftAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnMoveLeft : " + context);
            //Debug.Log(context.ReadValue<Vector3>());
            //moveDirInputAction = context.ReadValue<Vector2>();
            moveDir.x = -1;
            moveDir.y = 0;
            moveDir.z = 0;
            Raise_OnMoveAction(moveDir);
        }
    }


    public void OnMoveRightAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnMoveRight : " + context);
            //Debug.Log(context.ReadValue<Vector3>());
            //moveDirInputAction = context.ReadValue<Vector2>();
            moveDir.x = 1;
            moveDir.y = 0;
            moveDir.z = 0;
            Raise_OnMoveAction(moveDir);
        }
    }


    public void OnMoveUpAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnMoveUp : " + context);
            //Debug.Log(context.ReadValue<Vector3>());
            //moveDirInputAction = context.ReadValue<Vector2>();
            moveDir.x = 0;
            moveDir.y = 0;
            moveDir.z = 1;
            Raise_OnMoveAction(moveDir);
        }
    }

    public void OnMoveDownAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnMoveDown : " + context);
            //Debug.Log(context.ReadValue<Vector3>());
            //moveDirInputAction = context.ReadValue<Vector2>();
            moveDir.x = 0;
            moveDir.y = 0;
            moveDir.z = -1;
            Raise_OnMoveAction(moveDir);
        }
    }

}

// 2do
// As Scriptable objects class
// Scriptable events as channel
//

