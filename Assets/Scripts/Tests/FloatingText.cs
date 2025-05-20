
using UnityEngine;
using TMPro; // If you're using TextMeshPro

public class FloatingText : MonoBehaviour
{
    public float lifetime = 1f;
    public float floatSpeed = 1f;
    public TextMeshProUGUI text;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // Move upward
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Fade out
        float alpha = Mathf.Lerp(1f, 0f, timer / lifetime);
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        // Destroy after lifetime
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string message)
    {
        Debug.Log(message);
        text.text = message;
    }
}
