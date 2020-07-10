using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GameObject.Find("UIButton_Stats").GetComponent<Button>();
        button.onClick.AddListener(() => ViewToggle());
        transform.gameObject.SetActive(false);
    }

    public void ViewToggle()
    {
        if (transform.gameObject.activeInHierarchy == true)
        {        
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(true);
        }
    }
}
