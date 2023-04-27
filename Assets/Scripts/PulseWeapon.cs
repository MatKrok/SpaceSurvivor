using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseWeapon : MonoBehaviour
{
    float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject frontPulseObject;
    [SerializeField] GameObject backPulseObject;
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
        Debug.Log("Attack");
        timer = timeToAttack;

        frontPulseObject.SetActive(true);
        backPulseObject.SetActive(true);
    }
}
