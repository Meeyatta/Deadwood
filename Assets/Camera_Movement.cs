using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Offset;
    public float Distance;
    public float SensitivityX;
    public float SensitivityY;
    void Awake()
    {
        Player = FindObjectOfType<Player_Movement>().gameObject;
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
        gameObject.transform.position = center;

        var rot = gameObject.transform.rotation;
        rot = Quaternion.Euler(
            rot.eulerAngles.x - Input.GetAxis("Mouse Y") * SensitivityX,
            rot.eulerAngles.y + Input.GetAxis("Mouse X") * SensitivityY,
            rot.eulerAngles.z);

        gameObject.transform.rotation = rot;
        
    }
}
