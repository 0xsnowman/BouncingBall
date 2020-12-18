using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private int stick_count = 6;
    public GameObject[] stick = new GameObject[4];
    private GameObject diamond;
    public Rigidbody2D[] alredy_stick_rb = new Rigidbody2D[5];
    public Transform stick_spawn;
    public Transform diamond_spawn;

    private GameObject stickPrefab;
    public GameObject diamondPrefab;

    private float difficulty = 0;
    private int time = 0;
    private int newTime = 20;
    private int minTime = 20;
    private int maxTime = 25;
    private bool isStart;
    private float diamond_rand;
    private float stickVelocity = 8f;
    private int colorNum;
    private int randNum;
    public Color[] stickColor = new Color[5];

    void Start()
    {
        Screen.SetResolution(500, 700, false);
        isStart = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStart)
            time++;

        if (time == newTime)
        {
            RandomSelectStickPrefab();
            var newStick = Instantiate(stickPrefab, stick_spawn.position, Quaternion.identity) as GameObject;
            if (difficulty <= 5)
            {
                difficulty += 0.1f;
                if (randNum == 0)
                    newStick.transform.localScale = newStick.transform.localScale - new Vector3(newStick.transform.localScale.x * difficulty / 10, 0, 0);
            }
            else
                difficulty = 4.9f;
            newStick.GetComponent<Rigidbody2D>().velocity = Vector3.left * stickVelocity;
            diamond_rand = Random.Range(0, 10f);
            if (diamond_rand > 8)
            {
                diamond = Instantiate(diamondPrefab, diamond_spawn.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Rigidbody2D>().velocity = Vector3.left * stickVelocity;
            }
            time = 0;
            newTime = Random.Range(minTime, maxTime);
        }
    }

    void RandomSelectStickPrefab()
    {
        float rand = Random.Range(0, 10f);
        randNum = 0;
        if (difficulty < 1)
        {
            randNum = 0;
        }
        else
        {
            if (rand < 7)
                randNum = 0;
            else if (rand < 8)
                randNum = 1;
            else if (rand < 9)
                randNum = 2;
            else
                randNum = 3;
        }
        stickPrefab = stick[randNum];
    }

    void AlreadyStickMove()
    {
        for (int j = 0; j < 5; j++)
        {
            alredy_stick_rb[j].velocity = Vector3.left * stickVelocity;
        }
    }

    public void SetStart()
    {
        AlreadyStickMove();
        isStart = true;
    }

    public void SetStickColor()
    {
        colorNum++;
        for (int j = 0; j < 4; j++)
        {
            stick[j].GetComponent<SpriteRenderer>().color = stickColor[colorNum];
        }
        GameObject[] sticksOfScene = GameObject.FindGameObjectsWithTag("magic_stick");
        foreach (GameObject stickOfScene in sticksOfScene)
        {
            stickOfScene.GetComponent<SpriteRenderer>().color = stickColor[colorNum];
        }

        if (colorNum == 4)
            colorNum = -1;
    }

    public void OnDead(){
        isStart = false;
        GameObject[] sticksOfScene = GameObject.FindGameObjectsWithTag("magic_stick");
        foreach (GameObject stickOfScene in sticksOfScene)
        {
            stickOfScene.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        GameObject[] diamondsOfScene = GameObject.FindGameObjectsWithTag("diamond");
        foreach (GameObject diamondOfScene in diamondsOfScene)
        {
            diamondOfScene.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
