using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : Button
{
    private void OnTriggerEnter(Collider other)
    {
        Active = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        Active = false;
    }
}
