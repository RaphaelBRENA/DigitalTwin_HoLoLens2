using UnityEngine;
using MixedReality.Toolkit;

public class SwitchRotation : MonoBehaviour
{
    public Transform levier;
    private StatefulInteractable interactable;

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
        }
        else
        {
            isOn = true;
            StopAllCoroutines();
            StartCoroutine(AnimateRotation(Quaternion.Euler(0, 0, 10)));
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
