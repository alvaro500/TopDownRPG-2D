using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class PlayerInputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.ICombatActions
{
    private GameInput _gameInput;

    public event Action<Vector2> MoveEvent;
    private Vector2 _direction;

    public event Action AttackEvent;
    public event Action AttackCancelledEvent;

    public Vector2 Direction { get { return _direction; } private set { _direction = value; } }

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            //Add callbacks for inputs (started, perfomed, canceled)
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.Combat.SetCallbacks(this);

            SetGameInput();
        }
    }

    public void SetGameInput()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.Combat.Enable();

        //Set Movement whitout InputAction.started
        //_gameInput.Gameplay.Move.performed += ReadInputForMovement;
        //_gameInput.Gameplay.Move.canceled += ReadInputForMovement;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("Phase: " + context.phase + ", Value: " + context.ReadValue<Vector2>());
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
        //MoveEvent?.Invoke(_direction);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Debug.Log("Input Atacar");
            AttackEvent?.Invoke();
        }


    }
}