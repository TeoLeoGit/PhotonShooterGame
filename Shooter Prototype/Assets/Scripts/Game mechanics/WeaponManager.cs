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
    // Start is called before the first frame update
    void Start()
    {
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
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
        //Debug.Log("fire rate timer: " + fireRateTimer);
        if (fireRateTimer < fireRate) return false;

        if (Input.GetButtonDown("Fire1")) return true;
        if (Input.GetButtonDown("Fire1")) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        GameObject fireBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
        Rigidbody rb = fireBullet.GetComponent<Rigidbody>();
        rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
    }
}
