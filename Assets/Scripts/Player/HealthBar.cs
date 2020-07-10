using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foregroundImage = null;
    [SerializeField] private float updateSpeedInSeconds = 0.5f;

    public void Awake()
    {
        GetComponentInParent<PlayerHealth>().OnHealthValueChanged += HandleHealthChanged;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    private void HandleHealthChanged(float percentage)
    {
        StartCoroutine(ChangeToPercentage(percentage));
    }

    private IEnumerator ChangeToPercentage(float percentage)
    {
        percentage /= 100;//TO DO : fillamount 0-1 arası ama health değişiyor 100,200, vs.
        float preChangedPercentage = foregroundImage.fillAmount ; 
        float elapsedTime = 0f;

        while (elapsedTime < updateSpeedInSeconds)
        {
            elapsedTime += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangedPercentage, percentage, elapsedTime / updateSpeedInSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = percentage;
    }
}
