using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 screenBounds;
    [SerializeField]
    AudioSource still;
    [SerializeField]
    AudioSource brake;
    [SerializeField]
    AudioSource gas;

    [SerializeField]
    Transform top, bottom, middle, middleTop, middleBottom;

    List<Transform> ways = new List<Transform>();
    int positionIndex = 2;

    void Start()
    {
        ways.Add(bottom);
        ways.Add(middleBottom);
        ways.Add(middle);
        ways.Add(middleTop);
        ways.Add(top);
        gameObject.transform.position = middle.position;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //  Horizontal Boundary
        if (transform.position.x <= screenBounds.x * -1)
        {
            transform.position = new Vector2(screenBounds.x * -1, transform.position.y);
        }
        else if (transform.position.x >= screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        //  Player Movement
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && rb.bodyType != RigidbodyType2D.Static && positionIndex != ways.Count - 1)
        {
            positionIndex++;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, ways[positionIndex].position.y, gameObject.transform.position.z);
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && rb.bodyType != RigidbodyType2D.Static && positionIndex != 0)
        {
            positionIndex--;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, ways[positionIndex].position.y, gameObject.transform.position.z);
        }

        float dirX = Input.GetAxisRaw("Horizontal");

        // Sounds
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            still.Stop();
            gas.Stop();
            brake.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            still.Stop();
            brake.Stop();
            gas.Play();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            brake.Stop();
            gas.Stop();
            still.Play();
        }

        if (rb.bodyType != RigidbodyType2D.Static) rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);
    }

}
