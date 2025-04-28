using System.Collections;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void OnPress()
    {
        Debug.Log("Bouton pressé !");
        StartCoroutine(AnimatePress());
    }

    private IEnumerator AnimatePress()
    {
        transform.localPosition = originalPosition + new Vector3(0, -0.005f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.localPosition = originalPosition;
    }
}
