using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWait : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.SendMessage("SetStart");
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * 8 + Vector3.up * -5;
    }
}
