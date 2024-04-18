using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3f;
    private void Awake()
    {
        Destroy(gameObject, life);

    }

   private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.gameObject.CompareTag(""))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

    }
}
