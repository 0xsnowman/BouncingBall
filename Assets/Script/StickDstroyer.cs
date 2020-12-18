using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickDstroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backgroundImage;
    public GameObject RestartButton;
    public GameObject perfectEffect;
    public GameObject deadParticle;
    public GameObject gameManager;
    private int particleVelocity = 8;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "magic_stick" || other.tag == "diamond")
            Destroy(other.gameObject);
        else if (other.tag == "Player")
        {
            PlayerDead();
            Destroy(other.gameObject);
            var newParticle = Instantiate(deadParticle, other.gameObject.transform.position, gameManager.transform.rotation) as GameObject;
            gameManager.SendMessage("OnDead");
            Destroy(newParticle, 2.0f);
        }
    }

    public void PlayerDead()
    {
        backgroundImage.SetActive(true);
        RestartButton.SetActive(true);
        perfectEffect.SendMessage("BallIsDestroyed");

    }
}
