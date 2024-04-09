using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class PlayerInputReader : ScriptableObject, GameInput.IGameplayActions
{
    private GameInput _gameInput;
    public event Action<Vector2> MoveEvent;
    //public event Action MoveEvent;
    private Vector2 _direction;

    public Vector2 Direction { get { return _direction; } private set { _direction = value; } }

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            //Add callbacks for inputs (started, perfomed, canceled)
            _gameInput.Gameplay.SetCallbacks(this);

            SetGameInput();
        }
    }

    public void SetGameInput()
    {
        _gameInput.Gameplay.Enable();

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

    //private void ReadInputForMovement(InputAction.CallbackContext context) 
    //{
    //    //_direction = context.ReadValue<Vector2>();
    //    _direction = context.ReadValue<Vector2>();

    //    MoveEvent?.Invoke(_direction);
    //    //return _direction;
    //}
}