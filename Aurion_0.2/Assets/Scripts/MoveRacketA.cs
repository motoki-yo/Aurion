using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacketA : MonoBehaviour
{
    public static float speed = 30.0f;
    public string axis;
    
    void Update()
    {
        float v2 = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v2) * speed;
    }

}
