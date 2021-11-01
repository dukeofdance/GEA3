using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AsteroidFactory : ObjectFactory
	{

	[SerializeField]
	private Asteroid asteroid;

	private float _speed, _rotation, _scale, _lives, _spawnLocation;
	private Vector3 _direction;

	private GameObject _gameObject;


	public AsteroidFactory(float r, float s, float sc, float l, float sp, Vector3 d, GameObject t)
		{
		_rotation = r;
		_speed = s;
		_scale = sc;
		_direction = d;
		_lives = l;
		_spawnLocation = sp;
		_gameObject = t;
		}

	public override Object GetObject()
		{
		asteroid = new Asteroid(_speed, _rotation, _lives, _direction, _scale, _spawnLocation, _gameObject);
		return asteroid;
		}
	}