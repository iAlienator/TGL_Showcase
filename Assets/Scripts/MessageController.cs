using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public float FadeTime;

    private float fade;
    private TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0.04f);

        fade += Time.deltaTime;

        SetAlpha(1 - fade / FadeTime);

        if (fade >= FadeTime)
            Destroy(gameObject);
    }

    private void SetAlpha(float value)
    {
        var color = textMesh.color;
        color.a = value;
        textMesh.color = color;
    }
}
