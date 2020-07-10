using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum HealthType
{
    Damage = 0,
    Heal = 1
}

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public static float maxHealth { get; private set; } = 100f;
    public static float currentHealth { get; private set; }
    private Animator animator;
    private GameObject[] bottleHealths;
    public bool isDead = false;

    public event Action<float> OnHealthValueChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        bottleHealths = GameObject.FindGameObjectsWithTag("BottleHealth");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "BottleHealth")
        {
            ModifyHealth(20, HealthType.Heal);
            Destroy(collider.gameObject);
            Debug.Log("pot");
        }
    }

    public void ModifyHealth(float damage, HealthType healthType)
    {
        if (!isDead)
        {
            if (healthType == HealthType.Damage)
            {
                Debug.Log(damage + " hasar aldı");
                currentHealth -= damage;
                if (currentHealth <= 0f)
                {
                    isDead = true;
                    animator.SetBool("IsDead", true);
                }
            }
            else
            {
                currentHealth += 20;
            }

            OnHealthValueChanged(currentHealth);
        }
    }
}
