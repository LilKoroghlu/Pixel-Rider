using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 screenBounds;
    // Start is called before the first frame update
    [SerializeField]
    Transform top, bottom, middleTop, middleBottom;
    int positionIndex = 0;
    void Start()
    {
        gameObject.transform.position = bottom.position;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (positionIndex == 0)
            {
                positionIndex++;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, middleBottom.position.y, gameObject.transform.position.z);
            }
            else if (positionIndex == 1)
            {
                positionIndex++;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, middleTop.position.y, gameObject.transform.position.z);
            }
            else if (positionIndex == 2)
            {
                positionIndex++;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, top.position.y, gameObject.transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (positionIndex == 1)
            {
                positionIndex--;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, bottom.position.y, gameObject.transform.position.z);
            }
            else if (positionIndex == 2)
            {
                positionIndex--;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, middleBottom.position.y, gameObject.transform.position.z);
            }
            else if (positionIndex == 3)
            {
                positionIndex--;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, middleTop.position.y, gameObject.transform.position.z);
            }
        }
        float dirX = Input.GetAxisRaw("Horizontal");
        if (rb.bodyType != RigidbodyType2D.Static)
            rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);
    }
    private void OnTriggerEnter(Collider other)
    {

    }

}
