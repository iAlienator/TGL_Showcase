using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public Player Player;
    public UIController UIController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Player.IsDead && UIController.GUICanvas.enabled)
        {
            UIController.GUICanvas.enabled = false;
            UIController.YouDiedCanvas.enabled = true;
        }

        if (!Player.IsDead && UIController.YouDiedCanvas.enabled)
        {
            UIController.GUICanvas.enabled = true;
            UIController.YouDiedCanvas.enabled = false;
        }

        if (Player.IsDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Restart();
            }
        }
    }

    public void Restart()
    {
        UIController.SetDeathCount(Player.DeathCount);
        Player.MoveToCheckpoint();
    }
}
