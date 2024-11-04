using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public List<GameObject> Touching;
    Player_Movement pm;
    void Awake()
    {
        pm = GetComponent<Player_Movement>();
    }


    public bool Is_Touching()
    {
        return Touching.Count > 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((pm.Ground_Layers & (1<< collision.gameObject.layer)) != 0)
        {
            Touching.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (Touching.Contains(collision.gameObject))
        {
            Touching.Remove(collision.gameObject);
        }
    }
}
