using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Panel;
    
    void Update()
    {
        if(Input.GetKeyDown("0") && Panel != null)
        {

            bool IsActive = Panel.activeSelf;

            Panel.SetActive(!IsActive);

        }
    }
}
