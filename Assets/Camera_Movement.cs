using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject c;
    public GameObject Player;
    public Vector3 Offset;
    public float Distance;
    public float SensitivityX;
    public float SensitivityY;
    void Awake()
    {
        
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 center = Player.transform.position + Offset;
        c.transform.position = center;

        var rot = c.transform.rotation;
        rot = Quaternion.Euler(
            rot.eulerAngles.x - Input.GetAxis("Mouse Y") * SensitivityX,
            rot.eulerAngles.y + Input.GetAxis("Mouse X") * SensitivityY,
            rot.eulerAngles.z);

        c.transform.rotation = rot;
        
    }
}
