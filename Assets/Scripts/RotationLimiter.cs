using TMPro;
using UnityEngine;

public class RotationLimiter : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.forward;
    [SerializeField] private float minAngle = -35f;
    [SerializeField] private float maxAngle = 35f;
    public TextMeshProUGUI messageText;
    private Quaternion initialRotation;
    private bool isActive = false;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (!isActive) return;
        Quaternion currentRotation = transform.rotation;
        float angleZ = currentRotation.eulerAngles.z;
        if (angleZ > 180f)
        {
            angleZ -= 360f;
        }
        messageText.text = angleZ.ToString("F0") + "°";
        Quaternion delta = Quaternion.Inverse(initialRotation) * currentRotation;

        delta.ToAngleAxis(out float angle, out Vector3 axis);
        if (Vector3.Dot(axis, rotationAxis) < 0)
        {
            angle = -angle;
        }

        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        transform.rotation = initialRotation * Quaternion.AngleAxis(angle, rotationAxis);
    }

    public void StartManipulation()
    {
        isActive = true;
    }

    public void StopManipulation()
    {
        isActive = false;
    }
}
