using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public GameObject Point;
    public PlayerCharacter Main;
    // Update is called once per frame
    public void start()
    {
        Vector3 temp = Point.transform.position - transform.position;
        if(temp.x >= 0.1f)
        {
            Physics.gravity = new Vector3(9.81f, 0, 0);
            Main.transform.rotation = new Quaternion(0, 0, 0.707106829f, 0.707106829f);
        }
        if (temp.x <= -0.1f)
        {
            Physics.gravity = new Vector3(-9.81f, 0, 0);
            Main.transform.rotation = new Quaternion(0, 0, -0.707106829f, 0.707106829f);
        }
        if (temp.y >= 0.1f)
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
           Main.transform.rotation = new Quaternion(-180, 0, 0, 0);
        }
        if (temp.y <= -0.1f)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            Main.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (temp.z >= 0.1f)
        {
            Physics.gravity = new Vector3(0, 0, 9.81f);
            Main.transform.rotation = new Quaternion(-0.707106829f, 0, 0, 0.707106829f);
            //Main.transform.localEulerAngles = new Vector3(-90, Main.transform.localEulerAngles.y, Main.transform.localEulerAngles.z);
        }
        if (temp.z <= -0.1f)
        {
            Physics.gravity = new Vector3(0, 0, -9.81f);
            Main.transform.rotation = new Quaternion(0.707106829f, 0, 0, 0.707106829f);
            //Main.transform.localEulerAngles = new Vector3(90, Main.transform.localEulerAngles.y, Main.transform.localEulerAngles.z);
        }
        Destroy(this.gameObject);
    }
}
