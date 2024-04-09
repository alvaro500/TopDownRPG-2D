using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private float _moveSpeed;
	[SerializeField] private Rigidbody2D _rigidbody;
	
	[SerializeField] private PlayerAnimations _playerAnimations;
	[SerializeField] private PlayerSpriteRenderer _playerSpriteRenderer;

    //private Vector2 _moveDirection;
	private Vector2 _movement; //Hace lo mismo que el de arriba pero la variable tiene el nombre cambiado

    // Start is called before the first frame update
    void Start()
    {
        _playerInputReader.MoveEvent += HandleMove;
    }

    //private void HandleMOve(Vector2 direction)
    private void HandleMove(Vector2 direction)
    {
        //_moveDirection = direction;
		_movement = direction;
		//_playerAnimations.SetUpAnimations(_movement);

        //Debug.Log("En X: "+ direction.x);
        //Debug.Log("En Y: "+ direction.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		_playerSpriteRenderer.AdjustPlayerFacingDirection();
        Move();
    }

    private void Move()
    {
        //transform.position += new Vector3(_moveDirection.x, _moveDirection.y) * _speed;
        //transform.position += new Vector3(_moveDirection.x, _moveDirection.y) * (_speed * Time.deltaTime);
		_rigidbody.MovePosition(_rigidbody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
		_playerAnimations.SetUpAnimations(_movement);
		
    }
}