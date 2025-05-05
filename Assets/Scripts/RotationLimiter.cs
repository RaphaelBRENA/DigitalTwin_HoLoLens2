using UnityEngine;

public class RotationLimiter : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.forward;
    [SerializeField] private float minAngle = -35f;
    [SerializeField] private float maxAngle = 35f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion delta = Quaternion.Inverse(initialRotation) * currentRotation;

        delta.ToAngleAxis(out float angle, out Vector3 axis);
        if (Vector3.Dot(axis, rotationAxis) < 0)
        {
            angle = -angle;
        }

        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        transform.rotation = initialRotation * Quaternion.AngleAxis(angle, rotationAxis);
    }
}
