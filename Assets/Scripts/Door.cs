using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button active;
    public bool temp;


    void Update()
    {
        if (temp != active.Active)
        {
            temp = active.Active;
            Toggle(temp);
        }
    }

    void Toggle(bool mode)
    {
        this.GetComponent<MeshRenderer>().enabled = !mode;
        this.GetComponent<Collider>().enabled = !mode;
    }
}
