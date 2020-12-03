using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 8;
    public float runSpeed = 12;
    private float verticalDirection;
    private float horizontalDirection;
    public Rigidbody rigid;
    public GameObject cam;
    public GameObject Pickup;
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            verticalDirection = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
            horizontalDirection = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            rigid.transform.Translate(horizontalDirection, 0, verticalDirection);
        }
        else
        {
            verticalDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            horizontalDirection = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            rigid.transform.Translate(horizontalDirection, 0, verticalDirection);
        }
        RaycastHit hit;
        if (Input.GetKeyDown("e"))
        {
            if (Object != null)
            {
                Object.transform.parent = null;
                Object.GetComponent<Rigidbody>().useGravity = true;
                Object = null;
            }
            else
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 3f))
            {
                if (hit.transform.tag == "Object")
                {
                    Object = hit.transform.gameObject;
                    Object.GetComponent<Rigidbody>().useGravity = false;
                    //Object.transform.parent = Pickup.transform;
                }
            }
        }
        if (Object != null)
        {
            var direction = Vector3.zero;
            if (Vector3.Distance(Object.transform.position, Pickup.transform.position) > 0.01f)
            {
                direction = Pickup.transform.position - Object.transform.position;
                Object.GetComponent<Rigidbody>().velocity = direction * 5f;
            }
            else
            {
                Object.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            Object.transform.rotation = Pickup.transform.rotation;
        }
    }
}
