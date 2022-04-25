using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;

    [Header("Bullet properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] Transform target;
    [SerializeField] int damage = 10;
    
    
    void Start()
    {
        fireRateTimer = fireRate;
    }

    void Update()
    {
        if (CanFire())
        {
            Fire();
        }
    }

    bool CanFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (Input.GetButtonDown("Fire1")) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        Ray ray = new Ray(barrelPos.position, barrelPos.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<HealthSystem>();

            if (health != null)
                health.TakeDamage(damage);
        }
    }

    
}
