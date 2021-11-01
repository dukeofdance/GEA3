using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
	{

	public Vector3 direction;
	public Rigidbody rb;
	public float speed_min, speed_max;
	public float rotation_min, rotation_max;

	public System.Action destroyed;

	private float speed, rotation;

	void Start()
		{
		rb = GetComponent<Rigidbody>();
		rotation = Random.Range(rotation_min, rotation_max);
		speed = Random.Range(speed_min, speed_max);
		}
	// Update is called once per frame
	void Update()
		{
		if (this.gameObject.CompareTag("Asteroid"))
			{
			rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
			transform.Rotate(transform.rotation.x + rotation, transform.rotation.y, transform.rotation.z);
			}
		else
			{
			rb.AddForce(direction * speed, ForceMode.Impulse);
			}
		}

	private void OnTriggerEnter(Collider other)
		{
		if (this.gameObject.CompareTag("Asteroid") && other.gameObject.CompareTag("Asteroid")|| other.gameObject.CompareTag("TopBoundary") && this.gameObject.CompareTag("Asteroid")|| other.gameObject.CompareTag("TopBoundary") && this.gameObject.CompareTag("Enemy")) { return; }
		if (this.gameObject.CompareTag("PlayerBullet"))
			{
			this.destroyed.Invoke();
			}
		Destroy(this.gameObject);
		}
	}

//Debug.Log("I was destroyed by "+other.gameObject.tag);