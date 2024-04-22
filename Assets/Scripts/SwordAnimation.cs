using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
	[SerializeField] Animator _swordAnimator;

	public void SetUpAttackAnimations()
	{
		_swordAnimator.SetTrigger("Attack");
	}
}
