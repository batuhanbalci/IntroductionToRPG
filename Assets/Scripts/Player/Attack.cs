using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private GameObject orc;
    private OrcAI orcAI;
    private ParticleSystem shieldParticle;
    private CameraController cameraController;

    void Start()
    {
        animator = GetComponent<Animator>();
        orc = GameObject.FindGameObjectWithTag("Orc");
        orcAI = orc.GetComponent<OrcAI>();
        shieldParticle = GetComponentInChildren<ParticleSystem>();
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        
    }

    private void HitToEnemy()
    {
        float distance = Vector3.Distance(orc.transform.position, transform.position);
        StartCoroutine(cameraController.Shake(0.4f, 0.6f));
        if (distance < 3f)
        {
            orcAI.GetHit();
        }

        shieldParticle.Play();
    }
}
