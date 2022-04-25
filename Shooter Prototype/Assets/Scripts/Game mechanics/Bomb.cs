using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject _explosionParticle;
    
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosionParticle, transform.position, Quaternion.identity);

        collision.transform.GetComponent<HealthSystem>()?.TakeDamage(20);
        Destroy(this.gameObject);
    }
}
