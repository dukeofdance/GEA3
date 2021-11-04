using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;



public class Tutorial : MonoBehaviour
{
    private String wasd = "Move around by using WASD";
    private String fire = "Shoot using SPACE";
    private String foe = "Dodge or destory enemy ships and asteroids";
    
    public TextMeshProUGUI TopText;
    private bool w = false, a = false, s = false, d = false, shoot = false;
    public float spawnTimer = 20;
    private float timer;
    public Canvas play;

    int count=1;
    // Start is called before the first frame update
    void Start()
    {
        play.enabled = false;
        timer = 0;
        TopText.text = wasd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckInput();
        if (w == true && a == true && s == true && d == true)
        {
            TopText.text = fire;
        }
        if (shoot == true)
        {
            TopText.text = foe;
            Invoke("SpawnEnemies", spawnTimer);
            timer += Time.deltaTime;
        }
        if (timer == 20)
        {
            play.enabled = true;
        }
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            w = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            s = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            a = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            d = true;
        }

        if (w == true && a == true && s == true && d == true) {
            if (Input.GetKey(KeyCode.Space))
            {
                shoot = true;
            }
        }
    }

    public void CreateEnemy()
    {
        //Instantiate(enemyPrefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));

    }
    public void Skip()
    {
        SceneManager.LoadScene("Game");
    }

    void SpawnEnemies()
    {

        Vector3 spawnLocation = transform.position;

        if (count < 5)
        {
            if (UnityEngine.Random.Range(0, 2) > 0)
            {

                Projectile asteroid = AsteroidPool.Instance.GetFromPool();//Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);
                asteroid.transform.position = spawnLocation;
                Invoke("SpawnEnemies", spawnTimer);
                Debug.Log("astroid here " + count);
            }
            else
            {
                var nme = BasicPool.Instance.GetFromPool();
                nme.transform.position = spawnLocation;
                //Instantiate(enemyPrefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));
                Invoke("SpawnEnemies", spawnTimer);
                Debug.Log("dude here " + count);

            }
            count++;
        }
    }
}
