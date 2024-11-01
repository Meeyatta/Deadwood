using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public bool Is_Grounded;

    Rigidbody Rb;
    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }
    void Movement_Ground()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(
            Camera.main.transform.forward.x * v + Camera.main.transform.right.x * h,
            0,
            Camera.main.transform.forward.z * v + Camera.main.transform.right.z * h);

        Rb.velocity = (dir * Speed * Time.deltaTime * 100);
    }
    void Update()
    {
        Movement_Ground();
    }
}
