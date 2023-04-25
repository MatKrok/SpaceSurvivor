using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;

        Debug.Log("dir"+direction);
        Debug.Log("velo"+rgdbd2d.velocity);
    }
}
