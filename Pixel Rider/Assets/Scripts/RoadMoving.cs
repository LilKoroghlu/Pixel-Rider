using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoving : MonoBehaviour
{

    private GameObject player;
    Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (rb.bodyType != RigidbodyType2D.Static)
        {
            Vector2 pos = transform.position;
            float dirX = Input.GetAxisRaw("Horizontal");
            if (dirX > 0f) pos.x = pos.x - 12 * Time.deltaTime;
            else if (dirX < 0f) pos.x = pos.x - 8 * Time.deltaTime;
            else pos.x = pos.x - 10 * Time.deltaTime;
            if (pos.x <= -50) pos.x = 0;
            transform.position = pos;
        }
    }
}
