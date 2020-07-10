using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyList : MonoBehaviour
{
    private GameObject[] orcs;
    [SerializeField] private Text text;
    
    void OnEnable()
    {
        orcs = GameObject.FindGameObjectsWithTag("Orc");
        text = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        text = UpdateEnemyList();
    }

    private Text UpdateEnemyList()
    {
        text.text = "";
        foreach (var item in orcs)
        {
            text.text += (item.name + " " + item.GetComponent<OrcHealth>().currentHealth + "\n");
        }
        return text;
    }
}
