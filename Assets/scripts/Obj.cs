using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public GameObject Panel;
    
    void Update()
    {
        if(Input.GetKeyDown("1") && Panel != null)
        {

            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);

        }
    }
}
