using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
	{

	public float minVelocity;

	private float timer;
	public void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 5)
		{
			Shoot();
			timer = 0;
		}

	}
	void Awake()
	{
		float temp = Random.Range(minVelocity, maxVelocity);
		rb.velocity = new Vector3(0.0f, -temp, 0.0f);
	}

    public void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.CompareTag("TopBoundary"))
			{ return; }
		if (other.gameObject.CompareTag("Boundary") || (other.gameObject.CompareTag("Player")))
			{
			//Destroy(this.gameObject);
			BasicPool.Instance.AddToPool(gameObject);
			}
		if (other.gameObject.CompareTag("PlayerBullet"))
			{
			if (lives == 0) 
			{
				BasicPool.Instance.AddToPool(gameObject);
				//Destroy(this.gameObject);
			}
			else {
				lives -= 1;
			}
		}

	}

}
