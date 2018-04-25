using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public delegate void ChecpointChangedHandler(object sender, GameObject gameObject);
    public static event ChecpointChangedHandler OnCheckpointChanged = delegate { };

    private SpriteRenderer spriteRenderer;

    public bool IsCurrent { get; private set; }
    public float CurrentAlpha;
    public float NonCurrentAlpha;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnCheckpointChanged += CheckpointController_OnCheckpointChanged;
        SetAlpha(NonCurrentAlpha);
    }

    private void CheckpointController_OnCheckpointChanged(object sender, GameObject gameObject)
    {
        if (gameObject == this.gameObject)
        {
            SetAlpha(CurrentAlpha);
            IsCurrent = true;
        }
        else
        {
            SetAlpha(NonCurrentAlpha);
            IsCurrent = false;
        }
    }

    public void SetAsCurrentCheckpoint()
    {
        OnCheckpointChanged(this, gameObject);
    }

    private void SetAlpha(float value)
    {
        var color = spriteRenderer.color;
        color.a = value;
        spriteRenderer.color = color;
    }
}
