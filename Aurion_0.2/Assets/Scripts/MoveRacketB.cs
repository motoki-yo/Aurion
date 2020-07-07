using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacketB : MonoBehaviour
{
    public static float speed = 30.0f;
    public string axis;

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }

}
