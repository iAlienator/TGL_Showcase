using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Player player;
    private float horizontal;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
// In-Editor movement testing.
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.UpArrow))
            JumpTrigger();
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveLeftTrigger(true);
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            MoveLeftTrigger(false);
        if (Input.GetKey(KeyCode.RightArrow))
            MoveRightTrigger(true);
        if (Input.GetKeyUp(KeyCode.RightArrow))
            MoveRightTrigger(false);
#endif

        player.MoveHorizontally(horizontal);
    }

    public void MoveLeftTrigger(bool held)
    {
        horizontal = held? -1 : 0;
    }

    public void MoveRightTrigger(bool held)
    {
        horizontal = held ? 1 : 0;
    }

    public void JumpTrigger()
    {
        player.Jump();
    }
}
