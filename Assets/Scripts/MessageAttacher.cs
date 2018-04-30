using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAttacher : MonoBehaviour
{
    public GameObject MessagePrefab;
    public string Text;

    public void ShowMessage()
    {
        MessagePrefab.GetComponent<TextMesh>().text = Text;
        Instantiate(MessagePrefab, transform);
    }
}
