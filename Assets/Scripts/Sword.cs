using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] PlayerInputReader _playerInputReader;
    [SerializeField] SwordAnimation _swordAnimation;
    [SerializeField] Transform _activeWeaponTransform;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Transform _playerTransform;

    private void Start()
    {
        _playerInputReader.AttackEvent += HandleAttack;
    }

    private void HandleAttack()
    {
        _swordAnimation.SetUpAttackAnimations();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    private void MouseFollowWithOffset() 
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = _mainCamera.WorldToScreenPoint(_playerTransform.position);

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if(mousePos.x < playerScreenPoint.x) 
        {
            //_activeWeaponTransform.rotation = Quaternion.Euler(0, -180, angle);
            _activeWeaponTransform.rotation = Quaternion.AngleAxis(180, _activeWeaponTransform.up);
        }
        else 
        {
            //_activeWeaponTransform.rotation = Quaternion.Euler(0, 0, angle);
            _activeWeaponTransform.rotation = Quaternion.AngleAxis(0, _activeWeaponTransform.up);
        }
    }
}