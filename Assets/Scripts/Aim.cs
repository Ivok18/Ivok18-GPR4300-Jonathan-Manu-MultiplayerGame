using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private float aimAngle;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = true;
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (!GetComponent<PhotonView>().IsMine)
        {
            return;
        }*/

        //gun rotation logic
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }

    private void FixedUpdate()
    {
       /* if (!GetComponent<PhotonView>().IsMine)
        {
            return;
        }*/
        rb.rotation = aimAngle;
    }
}
