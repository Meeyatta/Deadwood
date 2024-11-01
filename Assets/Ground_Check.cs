using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public List<string> Tags = new List<string>();

    public GameObject Contact_Current;

    Player_Movement pm;
    
    void Awake()
    {
        pm = transform.parent.GetComponent<Player_Movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (Tags.Contains( other.gameObject.tag))
        {
            Contact_Current = other.gameObject;
            pm.Is_Grounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (Contact_Current == other.gameObject)
        {
            Contact_Current = null;
            pm.Is_Grounded = false;
        }
    }
}
