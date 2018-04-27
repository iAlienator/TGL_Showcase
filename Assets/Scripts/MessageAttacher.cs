using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAttacher : MonoBehaviour
{
    public GameObject MessagePrefab;
    public string Text;
    //public Sprite MessageSprite;

    public void ShowMessage()
    {
        MessagePrefab.GetComponent<TextMesh>().text = Text;
        //MessagePrefab.GetComponent<SpriteRenderer>().sprite = MessageSprite;
        Instantiate(MessagePrefab, transform);
    }
}
