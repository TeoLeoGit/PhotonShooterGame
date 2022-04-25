using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class HealthSystem : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] int maxHealth = 100;
    int currentHealth;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject ui;
    public PhotonView view;
    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (view.IsMine)
        {
            healthBar.SetHealth(maxHealth);
            healthBar.SetMaxHealth(maxHealth);
        }
        else
            Destroy(ui);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        //Debug.Log("Take damge: " + damage);
        view.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(int damage)
    {
        if (!view.IsMine)
            return;

        Debug.Log("Take damge: " + damage);
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        GetComponent<MovementStateManager>().enabled = false;
    }

    public void SetHealthBar(HealthBar healthBar)
    {
        this.healthBar = healthBar;
    }
}
