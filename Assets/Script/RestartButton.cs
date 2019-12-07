using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Application.LoadLevel("SampleScene");
    }
}
