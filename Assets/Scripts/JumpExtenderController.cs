using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpExtenderController : MonoBehaviour
{
    public float ResetTime;
    public bool CanBeUsed { get; private set; }
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CanBeUsed = true;
    }

    public void Use()
    {
        GetComponent<MessageAttacher>().ShowMessage();
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        spriteRenderer.enabled = CanBeUsed = false;
        // Continues the execution of the IEnumerator after the ResetTime duration.
        yield return new WaitForSeconds(ResetTime);
        spriteRenderer.enabled = CanBeUsed = true;
        yield return null;
    }
}
