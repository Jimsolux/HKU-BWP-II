using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float maxHealth = 1000;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ResetHealth() { health = maxHealth; }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Dead");
            //Destroy(gameObject);
        }
    }


}
