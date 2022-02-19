using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            return;
        }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            return;
        }
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
      
    }
}
