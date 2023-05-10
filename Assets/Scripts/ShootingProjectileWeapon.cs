using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProjectileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject enemyToTarget;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate;

    private Transform target;

    private void Start()
    {
        // ZnajdŸ wrogów w scenie i wybierz najbli¿szego jako cel
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }

        InvokeRepeating("Shoot", 0f, 1f / fireRate); // Wywo³aj funkcjê Shoot z okreœlon¹ szybkostrzelnoœci¹
    }

    private void Shoot()
    {
        if (target == null)
        {
            return;
        }

        // Wystrzel pocisk w kierunku celu
        Vector2 direction = (target.position - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }
}