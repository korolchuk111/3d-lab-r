using System;
using System.Collections.Generic;
using InfoText;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private List<NewWeapon> weapons;
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Transform crosshair;

    private NewWeapon _currentWeapon;
    private int _currentWeaponIndex;
    private PlayerInput _playerInput;
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _currentWeapon = weapons[0];
        _weaponInfo.OnWeaponChanged(_currentWeapon);
    }

    private void Update()
    {
        var scrollValue = _playerInput.Player.Scroll.ReadValue<float>();

        TryChangeWeapon(scrollValue);
        
        var mouseClickValue = _playerInput.Player.Fire.ReadValue<float>();
        if(mouseClickValue > 0)
            Fire();
    }

    public void AddAmmoToCurrentWeapon(int ammoCount)
    {
        _currentWeapon.AddAmmo(ammoCount);
        _weaponInfo.OnWeaponChanged(_currentWeapon);
    }

    private void TryChangeWeapon(float scrollValue)
    {
        if (scrollValue > 0)
        {
            if (_currentWeaponIndex + 1 < weapons.Count)
                ChangeWeapon(weapons[++_currentWeaponIndex]);
        }
        else if (scrollValue < 0)
        {
            if (_currentWeaponIndex - 1 >= 0)
                ChangeWeapon(weapons[--_currentWeaponIndex]);
        }
    }

    private void Fire()
    {
        Vector3 point = FindShootPoint();
        _currentWeapon.TryShoot(point);
        _weaponInfo.OnWeaponChanged(_currentWeapon);
    }


    private void ChangeWeapon(NewWeapon nextNewWeapon)
    {
        if (_currentWeapon != null) 
            _currentWeapon.gameObject.SetActive(false);
        
        _currentWeapon = nextNewWeapon;
        _currentWeapon.gameObject.SetActive(true);
        
       _weaponInfo.OnWeaponChanged(_currentWeapon);
    }

    private Vector3 FindShootPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
        return ray.GetPoint(100);
    }
    
    
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}