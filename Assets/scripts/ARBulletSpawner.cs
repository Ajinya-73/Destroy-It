using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBulletSpawn : MonoBehaviour
{
    public Transform ARbulletSpawner;
    public GameObject ARbulletPrefab;
    public float ARbulletSpeed = 20f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var bullet = Instantiate(ARbulletPrefab, ARbulletSpawner.position, ARbulletSpawner.rotation);
            bullet.GetComponent<Rigidbody>().velocity = ARbulletSpawner.forward * ARbulletSpeed;
        }
    }
}