using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float rotationLimit = 70f;
    [SerializeField] private float mouseSensivity = 100f;
    [SerializeField] private float cameraDistance = 3f;
    private PlayerHealth playerHealth;

    private float xAxisClamp = 0.0f;

    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime * 4f;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > rotationLimit)
        {
            xAxisClamp = rotationLimit;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(360f - rotationLimit);
        }
        else if (xAxisClamp < -rotationLimit)
        {
            xAxisClamp = -rotationLimit;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(rotationLimit);
        }

        Vector3 dir = new Vector3(0, 3f, -cameraDistance);
        transform.Rotate(Vector3.left * mouseY); //stable
        transform.localPosition = transform.localRotation * dir;
        
        if (playerHealth.isDead)
        {
            transform.Rotate(Vector3.up * mouseX);
        }
        else
        {
            playerBody.Rotate(Vector3.up * mouseX); //stable
        }
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.localPosition;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.localPosition = new Vector3(x, transform.localPosition.y + y, originalCamPos.z);

            yield return null;
        }

        transform.localPosition = originalCamPos;
    }
}
