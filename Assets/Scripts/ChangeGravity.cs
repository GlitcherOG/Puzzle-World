using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public bool active;
    private void OnTriggerEnter(Collider other)
    {
        ToggleGravity();
    }

    void ToggleGravity()
    {
        if (active)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
        }
        active = !active;
    }
}
