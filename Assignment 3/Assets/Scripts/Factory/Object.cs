using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Object
{

    public Rigidbody rb { get; }
    public float Speed { get; set; }
    public float Rotation { get; set; }
    public float Lives { get; set; }
    public float Scale { get; set; }
    public float SpawnLocation { get; set; }
    public Vector3 Direction { get; set; }
    public GameObject GameObject { get; set; }
    public void Move();
	public void Create();
	public void OnTriggerEnter(Collider other);
	public void Start();

	}
