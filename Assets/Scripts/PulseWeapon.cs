using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject frontPulseObject;
    [SerializeField] GameObject backPulseObject;
    [SerializeField] Vector2 pulseAttackSize = new Vector2(4f,2f);
    [SerializeField] int pulseDamage = 1;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        frontPulseObject.SetActive(true);
        //backPulseObject.SetActive(true);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(frontPulseObject.transform.position, pulseAttackSize, 0f);
        ApplyDamage(colliders);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i=0;i<colliders.Length;i++)
        {
            Debug.Log(colliders[i].gameObject.name);
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null)
            {
                e.TakeDamage(pulseDamage);
            }
            
        }
    }
}
