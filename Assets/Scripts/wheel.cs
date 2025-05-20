using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class wheel : MonoBehaviour
{
    private bool isActive = false;
    public TextMeshProUGUI messageText;
    void Start()
    {
        
    }
    void Update()
    {
        if (!isActive) return;

        Quaternion currentRotation = transform.rotation;
        float angleY = currentRotation.y * 360f;
        messageText.text = angleY.ToString("F0") + "°";
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
