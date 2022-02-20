using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    private float currentHealth;
    private SpriteRenderer healthDisplayBody;
    private SpriteRenderer healthDisplayGun;
    private CircleCollider2D bc;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplayBody = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        healthDisplayGun = transform.Find("Gun").Find("Sprite").GetComponent<SpriteRenderer>();

        bc = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //GetDamage(0.009f);
    }

   // [PunRPC]
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        healthDisplayBody.color = new Color(healthDisplayBody.color.r, healthDisplayBody.color.g, healthDisplayBody.color.b, currentHealth / maxHealth);
        healthDisplayGun.color = healthDisplayBody.color;
        if (currentHealth <= 0 )//)&& photonView.IsMine)
        {
            Die();
            //photonView.RPC("Die", RpcTarget.AllBuffered);
        }    
    }

   // [PunRPC]
    public void Die()
    {
        
        bc.enabled = false;
        healthDisplayBody.enabled = false;
        healthDisplayGun.enabled = false;
        GetComponent<ShootAndReload>().reloadBar.gameObject.SetActive(false);
        GetComponent<ShootAndReload>().reloadBar.parent.Find("Background").gameObject.SetActive(false);

    }

  //  [PunRPC]
    public void Respawn()
    {
        bc.enabled = true;
        healthDisplayBody.enabled = true;
        healthDisplayGun.enabled = true;
        GetComponent<ShootAndReload>().reloadBar.gameObject.SetActive(true);
        GetComponent<ShootAndReload>().reloadBar.parent.Find("Background").gameObject.SetActive(true);
    }




  //  [PunRPC]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Bullet"))
        {
            //GetComponent<PhotonView>().RPC("GetDamage", RpcTarget.AllBuffered, 10f);
            GetDamage(10);
            Destroy(collision.gameObject);
        }
    }


}
