using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ShowMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public void Show(string message)
    {
        messageText.text = message;
    }
}
