using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndReload : MonoBehaviour
{
    private Gun[] guns;
    private bool canShoot;
    private bool reloading;
    [SerializeField] private float reloadTime;
    [SerializeField] private float timeUntilEndOfReload;
    [SerializeField] private Transform reloadBar;

    // Start is called before the first frame update
    void Start()
    {
        guns = GetComponentsInChildren<Gun>();
        timeUntilEndOfReload = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        //reload logic
        reloadBar.localScale = new Vector3(reloadBar.localScale.x, timeUntilEndOfReload, reloadBar.localScale.y);
        if (timeUntilEndOfReload <= 0)
        {
            reloading = false;

        }
        else
        {
            timeUntilEndOfReload -= Time.deltaTime;
            reloading = true;
        }

        if (!GetComponent<PhotonView>().IsMine)
        {
            return;
        }

        //shoot logic
        if (Input.GetMouseButtonDown(0) && !reloading)
        {
            canShoot = true;
        }

        if (canShoot)
        {
            canShoot = false;
            foreach (var gun in guns)
            {
                //gun.GetComponent<PhotonView>().RPC("Shoot", RpcTarget.AllBuffered);
            }
            timeUntilEndOfReload = reloadTime;
            reloading = true;
        }


      



    }
}
