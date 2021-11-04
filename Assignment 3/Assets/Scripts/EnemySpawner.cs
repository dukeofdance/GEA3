using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class EnemySpawner : MonoBehaviour
	{
	public float min__X = -1056f, max__X = 1056;
	public static int min_Size = 10, max_Size = 30;

	public Projectile asteroidPrefab;
	public GameObject enemyPrefab;
	public string sceneName;

	public TextMeshProUGUI WaveText;
	public float spawnTimer; 
	public float waveTimer;
	public int wave = 1;

	[SerializeField]
	public static int enemyLimit=1, waveTotal=1;
	private int enemyCount = 0;

	public static Vector3 v;

	public Canvas menu;
	public TextMeshProUGUI enemyText;
	public TextMeshProUGUI waveCountText;

	private System.String wasd = "Move around by using WASD";
	private System.String fire = "Shoot using SPACE";
	private System.String foe = "Dodge or destory enemy ships and asteroids";

	public TextMeshProUGUI TopText;
	private bool w = false, a = false, s = false, d = false, shoot = false;

	[DllImport("A2Plugin")]
	private static extern int randomScale(float i1, float i2);

	// Start is called before the first frame update
	void Start()		{

		menu.enabled = true;
		enemyLimit = 1;
		waveTotal = 1;
		TopText.text = wasd;
		while (CommandInvoker.commandHistory.Count > CommandInvoker.counter)
		{
			CommandInvoker.commandHistory.RemoveAt(CommandInvoker.counter);
		}
		CommandInvoker.counter = 0;

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

		if (w == true && a == true && s == true && d == true)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				shoot = true;
			}
		}
	}
	private void Update()
    {
		if (menu.enabled == true)
        {
			enemyText.text = "Enemy Count: " + enemyLimit;
			waveCountText.text = "Total Waves: " + waveTotal;

			CheckInput();
			if (w == true && a == true && s == true && d == true)
			{
				TopText.text = fire;
			}
			if (shoot == true)
			{
				TopText.text = foe;
			}
		}

	}

    public void StartGame()
    {
		menu.enabled = false;
		Invoke("SpawnEnemies", spawnTimer);
		Invoke("nextWave", waveTimer);

	}

	void nextWave()
		{

		if (wave < waveTotal)
			{
			wave += 1;
			WaveText.text = "Wave " + wave+"/"+waveTotal;
			Debug.Log("WT: " + waveTotal);
			enemyCount = 1;
			enemyLimit++;
			waveTimer = 10;
			Invoke("SpawnEnemies", spawnTimer);
			Invoke("nextWave", waveTimer);
			}
		else
			{SceneManager.LoadScene("YouWon");}
		}


	public void FoeUP()
    {
		if (menu.enabled == true)
		{
			ICommand foePlus = new EnemyUp();
			CommandInvoker.AddCommand(foePlus);
			Debug.Log("Foe Up: "+enemyLimit);
		}
	}
	//public void FoeDown()
	//{
	//	CommandInvoker.UndoCommand();

	//}
	public void WaveUP()
	{
		if (menu.enabled == true)
		{
			ICommand wavePlus = new WavesUp();
			CommandInvoker.AddCommand(wavePlus);
			Debug.Log("Wave Up: " +waveTotal);
		}
	}

	public void ButtonPressed()
    {
		Debug.Log("Button Pressed");
    }
	//public void WaveDown()
	//{
	//	CommandInvoker.UndoCommand();

	//}
	void SpawnEnemies()
	{

		float pos__X = Random.Range(min__X, max__X);
		Vector3 spawnLocation = transform.position;
		v = spawnLocation;

		spawnLocation.x = pos__X;
		if (enemyCount < enemyLimit)
		{
			if (Random.Range(0, 2) > 0)
			{

				Projectile asteroid = AsteroidPool.Instance.GetFromPool();//Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);
				int rand = randomScale(min_Size, max_Size); // Random.Range(min_Size, max_Size);
				asteroid.transform.localScale = new Vector3(rand, rand, rand);
				asteroid.transform.position = spawnLocation;
				Invoke("SpawnEnemies", spawnTimer);
				//Debug.Log("astroid here " + enemyCount);		
			}
			else
			{
				var nme =BasicPool.Instance.GetFromPool();
				nme.transform.position = spawnLocation;
				//Instantiate(enemyPrefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));
				Invoke("SpawnEnemies", spawnTimer);
				//Debug.Log("dude here "+ enemyCount);

			}
			//Debug.Log("there are :" + enemyCount);
			enemyCount++;
		}
	}
}

