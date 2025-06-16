using UnityEngine;
using MixedReality.Toolkit;
using TMPro;
using UnityEngine.UI;


public class SwitchRotation : MonoBehaviour
{
    public Transform levier;
    private StatefulInteractable interactable;
    public TextMeshPro messageText;
    public Image image;
    public Sprite spriteOn;
    public Sprite spriteOff;

    private bool isOn = false;
    private float animationDuration = 0.1f;

    void Start()
    {
        interactable = GetComponent<StatefulInteractable>();
        interactable.OnClicked.AddListener(ToggleSwitch);
    }

    void ToggleSwitch()
    {
        if (isOn)
        {
            isOn = false;
            StopAllCoroutines();
            StartCoroutine(AnimateRotation(Quaternion.Euler(0, 0, -10)));
            messageText.text = "Switch: OFF";
            image.sprite = spriteOff;
        }
        else
        {
            isOn = true;
            StopAllCoroutines();
            StartCoroutine(AnimateRotation(Quaternion.Euler(0, 0, 10)));
            messageText.text = "Switch: ON";
            image.sprite = spriteOn;
        }
    }

    System.Collections.IEnumerator AnimateRotation(Quaternion targetRotation)
    {
        Quaternion initialRotation = levier.localRotation;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            levier.localRotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        levier.localRotation = targetRotation;
    }
}
