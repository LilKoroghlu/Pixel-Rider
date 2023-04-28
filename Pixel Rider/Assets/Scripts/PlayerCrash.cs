using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car") && this.anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Riding_Still")
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("crash");
        }

    }
}
