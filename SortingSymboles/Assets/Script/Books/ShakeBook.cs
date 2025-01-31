using UnityEngine;
using System.Collections;

public class ShakeBook : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float magnitude = 0.1f;

    private RectTransform rectTransform;
    private Vector3 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; // Store UI's original position
    }

    public IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            rectTransform.anchoredPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = originalPosition; // Reset position
    }

    public void StartShake()
    {
        StartCoroutine( Shake() );
    }

}
