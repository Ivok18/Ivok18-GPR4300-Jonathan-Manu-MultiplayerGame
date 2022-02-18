using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBehavior : MonoBehaviour
{
    private Gun[] guns;
    private float aimAngle;
    private Rigidbody2D rb;
    private bool canShoot;
    private bool reloading;
    [SerializeField] private float reloadTime;
    [SerializeField] private float timeUntilEndOfReload;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        guns = GetComponentsInChildren<Gun>();
        timeUntilEndOfReload = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        //gun rotation logic
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

         //shoot logic
        if(Input.GetKeyDown(KeyCode.Space) && !reloading)
        {
            canShoot = true;
        }
        if(canShoot)
        {
            canShoot = false;
            foreach (var gun in guns)
            {
                gun.Shoot();
            }
            timeUntilEndOfReload = reloadTime;
            reloading = true;
        }


        //reload logic
        if (timeUntilEndOfReload <= 0)
        {
            reloading = false;
           
        }
        else
        {
            timeUntilEndOfReload -= Time.deltaTime;
            reloading = true;
        }
    
        
       
    }

    private void FixedUpdate()
    {
        rb.rotation = aimAngle;
    }
}
