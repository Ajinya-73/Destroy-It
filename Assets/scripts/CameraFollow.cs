using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerTank;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTank.transform.position + new Vector3(-1.5f, 6, 5);
    }
}