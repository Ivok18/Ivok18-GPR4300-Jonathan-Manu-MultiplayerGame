using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviourPun
{

    [SerializeField] private float maxHealth;
    private float currentHealth;
    private SpriteRenderer healthDisplayBody;
    private SpriteRenderer healthDisplayGun;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplayBody = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        healthDisplayGun = transform.Find("Gun").Find("Sprite").GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        healthDisplayBody.color = new Color(healthDisplayBody.color.r, healthDisplayBody.color.g, healthDisplayBody.color.b, currentHealth / maxHealth);
        healthDisplayGun.color = healthDisplayBody.color;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }    
    }

    [PunRPC]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Bullet"))
        {
            GetComponent<PhotonView>().RPC("GetDamage", RpcTarget.AllBuffered, 10f);
            Destroy(collision.gameObject);
        }
    }


}
