using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Projectile bulletPrefab;
    public Transform bulletLocation;
    public Rigidbody rb;

    public float speed, maxVelocity;
    public int lives; 

    protected float sqrMaxVelocity;
    protected bool canShoot = true;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    protected void Shoot()
        {
        if (!(canShoot = true))
            {
            return;
            }
        Projectile projectile = BulletPool.Instance.GetFromPool();//Instantiate(this.bulletPrefab, bulletLocation.transform.position, quat);
        //projectile.destroyed += LaserDestroyed;
        Debug.Log("NOTE COME BACK HERE");
        //canShoot = false;
        }

    public void LaserDestroyed()
        {
        canShoot = true;
        }

    }
