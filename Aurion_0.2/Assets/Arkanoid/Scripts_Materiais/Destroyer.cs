using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collider = col.collider.gameObject;
        GameObject.Destroy(collider);
        Debug.Log("BOLINHA FOI PRO BREJO");
    }
}
