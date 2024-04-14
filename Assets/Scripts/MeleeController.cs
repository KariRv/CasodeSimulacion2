using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    float damage;

    [SerializeField]
    LayerMask whatIsEnemy;

    [SerializeField]
    Transform attackPoint;

    public void OnAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.4F, whatIsEnemy);
        foreach (var collider in colliders)
        {
            HealthController healthController = collider.GetComponent< HealthController>();
            healthController.TakeDamage(damage);
        }

    }
}
