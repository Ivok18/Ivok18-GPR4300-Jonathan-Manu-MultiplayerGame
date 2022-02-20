using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;
    

    //[PunRPC]
    public void Shoot()
    {
        GameObject bulletGo = Instantiate(bullet.gameObject, transform.position, transform.parent.rotation);
        bulletGo.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse); 
    }
}
