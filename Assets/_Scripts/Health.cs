using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamage
{
    [SerializeField] float hp;
    public void TakeDamage(int value) {
        hp -= value;
        if (hp <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

}
