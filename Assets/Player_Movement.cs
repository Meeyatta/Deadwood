using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float Drag_Ground;
    public float Drag_Air;
    public float Gravity;

    public float Vertical_Force;

    float curGravity;
    public bool Is_Grounded;

    Rigidbody Rb;
    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Rb.velocity = Vector3.zero;
    }
    public void Jump_Try(InputAction.CallbackContext c)
    {
        //Debug.Log("Tried jumping");
        if (Is_Grounded)
        {
        }
    }
    
    void Movement_Ground(float h, float v)
    {
        curGravity = 0;
        Rb.drag = Drag_Ground;
        Vector3 dir = new Vector3(
            Camera.main.transform.forward.x * v + Camera.main.transform.right.x * h,
            0,
            Camera.main.transform.forward.z * v + Camera.main.transform.right.z * h);

        Vertical_Force = Mathf.Clamp(Vertical_Force, -3 * Gravity, Mathf.Infinity);
        Vector3 full = (dir * Speed * Time.deltaTime * 100);
        Rb.velocity = new Vector3(full.x, Vertical_Force, full.z);
    }
    void Movement_Air(float h, float v)
    {
        Rb.drag = Drag_Air;
        curGravity += Gravity;

        Vector3 dir = new Vector3(
            Camera.main.transform.forward.x * v + Camera.main.transform.right.x * h,
            0,
            Camera.main.transform.forward.z * v + Camera.main.transform.right.z * h);

        Vertical_Force = Mathf.MoveTowards(Vertical_Force, -10 * Gravity, -1 * curGravity * Time.deltaTime * 100);
        Vector3 grav = new Vector3(0, Vertical_Force, 0);

        Vector3 full = (dir * Speed * Time.deltaTime * 100) + grav;
        Rb.velocity = full;
    }
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Is_Grounded)
        {
            Movement_Ground(h, v);
        }
        else
        {
            Movement_Air(h,v);
        }
    }
    
}
