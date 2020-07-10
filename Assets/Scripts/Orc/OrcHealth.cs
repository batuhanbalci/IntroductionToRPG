using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    public float currentHealth { get; private set; }
    private OrcAI orcAI;
    private Drop drop;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        drop = GetComponent<Drop>();
    }

    void Start()
    {
        orcAI = GetComponent<OrcAI>();
    }

    public void ModifyHealth(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            drop.DropItem();
            orcAI.SetState(OrcStates.Dead);
        }
    }
}
