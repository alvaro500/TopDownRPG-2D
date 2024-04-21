using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	[SerializeField] Animator _playerAnimator;
	
	public void SetUpAnimations(Vector2 movementVector)
	{
		_playerAnimator.SetFloat("moveX", movementVector.x);
		_playerAnimator.SetFloat("moveY", movementVector.y);
	}
}
