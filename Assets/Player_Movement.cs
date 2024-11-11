using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class Player_Movement : MonoBehaviour
{
    public float Gravity;
    public float Jump_Speed;
    public float Speed;
    public float Speed_Air;
    public float Drag;

    public bool Is_Jumping;

    BoxCollider Col;
    Ground_Check GC;

    public LayerMask Ground_Layers;

    Rigidbody Rb;
    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Col = GetComponent<BoxCollider>();
        GC = GetComponent<Ground_Check>();
    }
    void Start()
    {
        Rb.velocity = Vector3.zero;
        Rb.drag = Drag;
    }
    public void Jump_Try(InputAction.CallbackContext c)
    {
        //Debug.Log("Tried jumping");
        if (Is_Grounded() && !Is_Jumping)
        {
            Is_Jumping = true;
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        Rb.AddForce(Vector3.up * Jump_Speed * 100);

        while (!Is_Grounded())
        {
            yield return new WaitForSeconds(0.01f);
        }
        Is_Jumping = false;
        yield return null;
    }
    void Movement_Ground(float h, float v)
    {
        Vector3 dir = new Vector3(
            Camera.main.transform.forward.x * v + Camera.main.transform.right.x * h,
            0,
            Camera.main.transform.forward.z * v + Camera.main.transform.right.z * h);

        

        Vector3 full = (dir * Speed * Time.deltaTime * 100);

        Rb.velocity = new Vector3(full.x, Rb.velocity.y , full.z);
    }
    void Movement_Air(float h, float v)
    {
        //Rb.drag = Drag_Air;

        Vector3 dir = new Vector3(
            Camera.main.transform.forward.x * v + Camera.main.transform.right.x * h,
            0,
            Camera.main.transform.forward.z * v + Camera.main.transform.right.z * h);

        Vector3 full = (dir * Speed_Air * Time.deltaTime * 100);
        Rb.velocity = new Vector3(full.x, Rb.velocity.y - Gravity * Time.deltaTime , full.z);
    }
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Is_Grounded())
        {
            Movement_Ground(h, v);
        }
        else
        {
            Movement_Air(h,v);
        }
    }
    bool Is_Grounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, Col.size.y / 2 + 1, Ground_Layers) || GC.Is_Touching();

    }
}
