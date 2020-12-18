using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aroundLeft;
    public GameObject aroundRight;
    public GameObject perfect;
    public Color perfectColor;
    public Color aroundColor;
    public void SetColor(string colliderPosition){
        switch(colliderPosition){
            case "perfect":perfect.GetComponent<SpriteRenderer>().color = perfectColor;
            break;
            case "aroundLeft":aroundLeft.GetComponent<SpriteRenderer>().color = aroundColor;
            break;
            case "aroundRight":aroundRight.GetComponent<SpriteRenderer>().color = aroundColor;
            break;
        }
    }
}
