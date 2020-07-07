using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jogador : MonoBehaviour
{
    public static float Velocidade =10.0f;
    public float HorizontalAxis;
    public new Rigidbody2D rigidbody;
    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 posicao;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalAxis = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(Velocidade * HorizontalAxis, 0);
        //////////////////////////////////////////////////////////
        //Versão touch mobile abaixo//
        /*if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (toque.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = toque.position;

                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = toque.position - startPos;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends

                    break;

            }
        }*/
    }
    public void addDireita()
    {
        if(Input.touchCount > 0)
        {
            rigidbody.velocity = new Vector2(Velocidade, 0);
        }
    }
    public void addEsquerda()
    {
        if (Input.touchCount > 0)
        {
            rigidbody.velocity = new Vector2(-Velocidade, 0);
        }
    }
    private void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            Int32 aux = Convert.ToInt32(Velocidade);           
        }
    }





}
