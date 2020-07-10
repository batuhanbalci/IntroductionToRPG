using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour
{
    [SerializeField] private Text text;

    void OnEnable()
    {
        
    }

    void FixedUpdate()
    {
        text.text = PlayerHealth.currentHealth.ToString() + " / " + PlayerHealth.maxHealth.ToString();
    }
}
