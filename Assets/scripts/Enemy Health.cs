using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 3f;
    public float currentHealth;

    //public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    /*  void OnMouseDown()
      {
          currentHealth -= Random.Range(0.5f, 1.5f);
          if (currentHealth <= 0)
          {
              Destroy(gameObject);
          }
          else
          {
              healthBar.UpdateHealthBar(maxHealth, currentHealth);
          }

      }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }
        /*else
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }*/

    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        //healthBar.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
