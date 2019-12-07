using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfect_effect : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] spriteImage = new Sprite[6];
    public Transform ball;
    private float alpha = 0;
    private bool ballIsDestroyed = false;
    void UpdateEffect(int perfectNum)
    {
        if (perfectNum > 3 && perfectNum < 9)
        {
            alpha = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteImage[perfectNum - 4];
        }
        if (perfectNum > 8)
        {
            alpha = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteImage[5];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ballIsDestroyed == false)
            transform.position = ball.position + Vector3.up * 1f;
        if (alpha > 0)
        {
            alpha -= 0.02f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        }
    }

    public void BallIsDestroyed()
    {
        ballIsDestroyed = true;
    }
}
