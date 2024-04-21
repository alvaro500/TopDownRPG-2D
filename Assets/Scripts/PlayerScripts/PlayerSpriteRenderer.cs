using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
	[SerializeField] SpriteRenderer _playerSpriteRenderer;
	
	public void AdjustPlayerFacingDirection()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
		
		if(mousePos.x < playerScreenPoint.x)
		{
			_playerSpriteRenderer.flipX = true;
		}else
		{
			_playerSpriteRenderer.flipX = false;
		}
	}
}
