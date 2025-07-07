using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class PointEffect : MonoBehaviour
{
    public float floatSpeed = 1;
    public float fadeTime = 1;

    private TextMeshProUGUI textMesh;
    private Color originalColor;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalColor = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Move upwards
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Fade out
        float alpha = Mathf.Lerp(originalColor.a, 0, timer / fadeTime);
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        timer += Time.deltaTime;

        if (timer >= fadeTime)
        {
            Destroy(gameObject);
        }
    }
}
