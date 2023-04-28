using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        speed = -5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
            rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

}
