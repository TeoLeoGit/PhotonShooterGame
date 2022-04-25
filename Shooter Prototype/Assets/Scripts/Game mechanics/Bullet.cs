using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string enemyTag;
    [SerializeField] private int damage;

    void Awake()
    {
        Destroy(this.gameObject, 1.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
            Debug.Log(hitObject);
        if (hitObject.tag.CompareTo(enemyTag) == 0)
        {
            HealthSystem enemyHealth = hitObject.GetComponent<HealthSystem>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);
        }
        Destroy(this.GetComponent<SphereCollider>());
        Destroy(this.GetComponent<Rigidbody>());
    }

   
}
