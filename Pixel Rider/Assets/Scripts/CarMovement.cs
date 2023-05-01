using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        if (rb.bodyType != RigidbodyType2D.Static && dirX > 0f) rb.velocity = new Vector2(-17f, rb.velocity.y);
        else if (rb.bodyType != RigidbodyType2D.Static && dirX < 0f) rb.velocity = new Vector2(-15f, rb.velocity.y);
        else if (rb.bodyType != RigidbodyType2D.Static && dirX == 0f) rb.velocity = new Vector2(-15f, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

}
