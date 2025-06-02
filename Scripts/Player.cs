using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnJump();
    }
    private void OnMove()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h != 0)
        {
            GetComponent<SpriteRenderer>().flipX = h < 0;
        }


        rb.velocity = new Vector3(h * speed * Time.deltaTime, rb.velocity.y, 0);
    }

    private void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
