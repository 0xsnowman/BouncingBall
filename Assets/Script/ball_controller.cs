using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ball_controller : MonoBehaviour
{
    public GameObject gameManager;
    private Rigidbody2D ball_rb;
    private Transform ball_tr;
    public CircleCollider2D ball_col;
    private int continuePerfect;
    private int score;
    private int bonus;
    private int diamondNum;
    private int continue_bonus;
    public Text perfectText;
    public Text scoreText;
    public Text diamondNumText;
    public GameObject perfectEffect;
    public GameObject perfectParticle;
    public GameObject aroundParticle;
    public GameObject deadParticle;
    public GameObject stickDestroyer;
    private int particleVelocity;
    public GameObject startTapStop;

    void Start()
    {
        ball_rb = gameObject.GetComponent<Rigidbody2D>();
        ball_rb.gravityScale = 0;
        ball_tr = transform;
        score = 0;
        bonus = 0;
        continuePerfect = 0;
        diamondNum = 0;
        particleVelocity = 8;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ball_rb.gravityScale = 8;
            startTapStop.SetActive(false);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        ball_rb.gravityScale = 1;
        ball_rb.velocity = Vector3.zero;
        if (other.gameObject.tag == "magic_stick")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * 8 + Vector3.up * -5;
            ball_tr.position = new Vector3(0, other.gameObject.transform.position.y + 3.7f, 0);

            if (Mathf.Abs(other.gameObject.transform.position.x) < other.gameObject.transform.localScale.x * 0.33)
            {
                BouncyPerfect();

                other.gameObject.SendMessage("SetColor", "perfect");
                gameManager.SendMessage("SetStickColor");
                var newParticle = Instantiate(perfectParticle, transform.position - new Vector3(0, 0.4f, 0), gameManager.transform.rotation) as GameObject;
                newParticle.GetComponent<Rigidbody>().velocity = Vector3.left * particleVelocity;
                Destroy(newParticle, 1.0f);
            }
            else
            {
                BouncyAround();
                var newParticle = Instantiate(aroundParticle, transform.position - new Vector3(0, 0.4f, 0), gameManager.transform.rotation) as GameObject;
                newParticle.GetComponent<Rigidbody>().velocity = Vector3.left * particleVelocity;
                Destroy(newParticle, 1.0f);
                if (other.gameObject.transform.position.x > 0)
                    other.gameObject.SendMessage("SetColor", "aroundLeft");
                else
                    other.gameObject.SendMessage("SetColor", "aroundRight");
            }
            scoreText.text = "Score : " + score.ToString();
        }
        else if (other.gameObject.tag == "brumble")
        {
            GetBramble();
        }
    }
    public void BouncyPerfect()
    {
        ball_rb.AddForce(Vector3.up * 450);
        bonus += 20;
        score += bonus;
        continuePerfect++;
        perfectEffect.SendMessage("UpdateEffect", continuePerfect);
    }
    public void BouncyAround()
    {
        ball_rb.AddForce(Vector3.up * 300);
        bonus = 0;
        score += 10;
        continuePerfect = 0;
    }
    public void GetBramble()
    {
        var newParticle = Instantiate(deadParticle, transform.position, gameManager.transform.rotation) as GameObject;
        Destroy(newParticle, 2.0f);
        stickDestroyer.SendMessage("PlayerDead");
        gameManager.SendMessage("OnDead");
        Destroy(this.gameObject);
    }

    public void GetDiamond()
    {
        diamondNum++;
        diamondNumText.text = diamondNum.ToString();
    }
}
