using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, Object

	{

	private Rigidbody _Rb;
	private float _Speed, _Rotation, _Lives, _Scale, _SpawnLocation;
	private Vector3 _Direction;
	private GameObject _GameObject;

	public Asteroid(float s, float r, float l, Vector3 d, float sc, float sp, GameObject g)
		{
		_Speed = s;
		_Rotation = r;
		_Lives = l;
		_Rb = rb;
		_Direction = d;
		_Scale = sc;
		_SpawnLocation = sp;
		_GameObject = g;
		}
	public Rigidbody rb
		{

		get { return _Rb; }

		}

	public GameObject GameObject
		{

		get { return _GameObject; }
		set { _GameObject = value; }

		}

	public float Speed
		{

		get { return _Speed; }
		set { _Speed = value; }

		}

	public float Rotation
		{

		get { return _Rotation; }
		set { _Rotation = value; }

		}

	public float Lives
		{

		get { return _Lives; }
		set { _Lives = value; }
		}

	public float Scale
		{

		get { return _Scale; }
		set { _Scale = value; }
		}

	public float SpawnLocation
		{

		get { return _SpawnLocation; }
		set { _SpawnLocation = value; }

		}


	public Vector3 Direction
		{

		get { return _Direction; }
		set { _Direction = value; }
		}

	public void Move()
		{
		rb.MovePosition(GameObject.transform.position + (_Direction * _Speed * Time.deltaTime));
		GameObject.transform.Rotate(GameObject.transform.rotation.x + _Rotation, GameObject.transform.rotation.y, GameObject.transform.rotation.z);
		}


	public void OnTriggerEnter(Collider other)
		{
		_Lives--;
		if (other.gameObject.CompareTag("Asteroid") || other.gameObject.CompareTag("TopBoundary")) { return; }
		if (_Lives == 0)
			{
			Destroy(this.gameObject);
			}
		}

	public void Start()
		{
		Create();
		GameObject.transform.localScale = new Vector3(Scale, Scale, Scale);
		_Rb = GameObject.GetComponent<Rigidbody>();
		}

	public void Create()
		{
		Vector3 v = new Vector3(SpawnLocation, GameObject.transform.position.y, GameObject.transform.position.z);
		Instantiate(GameObject, v, Quaternion.Euler(0f, -90f, 90f));
		}


	public void Update()
		{
		Move();
		}


	}