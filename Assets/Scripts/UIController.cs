using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player Player;
    public Text DeathCountText;
    public Canvas GUICanvas;
    public Canvas YouDiedCanvas;

    private void Awake()
    {
        GUICanvas.enabled = true;
        YouDiedCanvas.enabled = false;
    }

    public void Update()
    {
        // In-editor button press simulation
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        if (Input.GetKey(KeyCode.LeftArrow))
            LeftHeld();
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            LeftReleased();
        if (Input.GetKey(KeyCode.RightArrow))
            RightHeld();
        if (Input.GetKeyUp(KeyCode.RightArrow))
            RightReleased();
#endif
        //YouDiedImage.enabled = Player.IsDead;

        //if(Player.IsDead)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        GameManager.Instance.Restart();
        //    }
        //}
    }

    public void SetDeathCount(int value)
    {
        DeathCountText.text = "Deaths: " + value;
    }

    public void Jump()
    {
        Player.Jump();
    }

    public void LeftHeld()
    {
        Player.SetHorizontalInput(-1);
    }

    public void LeftReleased()
    {
        Player.SetHorizontalInput(0);
    }

    public void RightHeld()
    {
        Player.SetHorizontalInput(1);
    }

    public void RightReleased()
    {
        Player.SetHorizontalInput(0);
    }
}
