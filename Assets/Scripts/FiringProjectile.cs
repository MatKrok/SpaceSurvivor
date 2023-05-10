using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringProjectile : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Zwróæ pocisk w kierunku jego prêdkoœci
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Zniszcz pocisk po trafieniu w wroga
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
