using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsController : MonoBehaviour
{
    private PlayerShoot shoot;
    private PlayerMelee melee;
    private PlayerChargedShot chargedShot;
    private bool firingPrimary;
    private bool firingSecondary;
    
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<PlayerShoot>();
        melee = GetComponent<PlayerMelee>();
        chargedShot = GetComponent<PlayerChargedShot>();
    }

    private void ChooseWeapon()
    {
        if (firingPrimary && firingSecondary)
        {
            chargedShot.beganChargingTime = Time.time;
            chargedShot.firing = true;
            shoot.firing = false;
            melee.firing = false;
        }
        else if (firingPrimary)
        {
            chargedShot.firing = false;
            shoot.firing = true;
            melee.firing = false;
        }
        else if (firingSecondary)
        {
            chargedShot.firing = false;
            shoot.firing = false;
            melee.firing = true;
        }
        else
        {
            chargedShot.firing = false;
            shoot.firing = false;
            melee.firing = false;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        firingPrimary = inputValue.isPressed;
        ChooseWeapon();
    }

    private void OnMeleeAttack(InputValue inputValue)
    {
        firingSecondary = inputValue.isPressed;
        ChooseWeapon();
    }
}
