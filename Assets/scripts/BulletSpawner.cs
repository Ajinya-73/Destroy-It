using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * bulletSpeed;
        }
    }
}
