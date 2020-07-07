using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Racket : MonoBehaviour
{
    private Vector2 vetorBot;
    private float speedBot = 0f;
    private Rigidbody2D rigido;
    private Transform bot,bolls;
    private Component RacketLeft_Bot;
    public float auxBotY, auxBallY,tempo;
    public int dificuldade;


    private Ball bola;


    void Start()
    {        
        bola = new Ball();
        bot = GameObject.FindGameObjectWithTag("Bot").transform;
        bolls = GameObject.FindGameObjectWithTag("Ball").transform;
        //speedBot = bola.dir.y;
        vetorBot = new Vector2(-38,-13);
    }

    void Update()
    {
        tempo += (Time.deltaTime);
        mudaValor();
        //Debug.Log(tempo);
        /*if (tempo <= 10f)
            dificuldade+=1;
        else if (tempo <= 15f && tempo > 10f)////////////////////////////////////
        {
            dificuldade+=1;
            bola.speedBall += 10.0f;
        }
        else if (tempo <= 20f && tempo > 15f)
            dificuldade++;
        else if (tempo <= 25f && tempo > 20f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 30f && tempo > 25f)
            dificuldade++;
        else if (tempo <= 35f && tempo > 30f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 40f && tempo > 35f)
            dificuldade++;
        else if (tempo <= 45f && tempo > 40f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 50f && tempo > 45f)
            dificuldade++;
        else if (tempo <= 55f && tempo > 50f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 60f && tempo > 55f)
            dificuldade++;
        else if (tempo <= 65f && tempo > 60f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 70f && tempo > 65f)
            dificuldade++;
        else if (tempo <= 75f && tempo > 70f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 80f && tempo > 75f)
            dificuldade++;
        else if (tempo <= 85f && tempo > 80f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 90f && tempo > 85f)
            dificuldade++;
        else if (tempo <= 95f && tempo > 90f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 100f && tempo > 95f)
            dificuldade++;
        else if (tempo <= 105f && tempo > 100f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 110f && tempo > 105f)
            dificuldade++;
        else if (tempo <= 115f && tempo > 110f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 120f && tempo > 115f)
            dificuldade++;
        else if (tempo <= 125f && tempo > 120f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 130f && tempo > 125f)
            dificuldade++;
        else if (tempo <= 135f && tempo > 130f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 140f && tempo > 135f)
            dificuldade++;
        else if (tempo <= 145f && tempo > 140f)////////////////////////////////////
            dificuldade++;
        else if (tempo <= 150f && tempo > 145f)
            dificuldade++;*/
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        switch(dificuldade)
        {
            case 5:
                bola.speedBall += 2f;
                Debug.Log("1:"+dificuldade);
                Debug.Log("B:" + bola.speedBall);
                break;
            case 10:
                bola.speedBall += 2f;
                Debug.Log("2:" + dificuldade);
                break;
            case 15:
                bola.speedBall += 2f;
                Debug.Log("3:" + dificuldade);
                break;
            case 20:
                bola.speedBall += 2f;
                Debug.Log("4:" + dificuldade);
                break;
            case 25:
                bola.speedBall += 2f;
                Debug.Log("5:" + dificuldade);
                break;
            case 30:
                bola.speedBall += 2f;
                Debug.Log("6:" + dificuldade);
                break;
            case 35:
                bola.speedBall += 2f;
                Debug.Log("7:" + dificuldade);
                break;
            case 40:
                bola.speedBall += 2f;
                Debug.Log("8:" + dificuldade);
                break;
            case 45:
                bola.speedBall += 2f;
                Debug.Log("9:" + dificuldade);
                break;
            case 50:
                bola.speedBall += 2f;
                Debug.Log("10:" + dificuldade);
                break;
            case 55:
                bola.speedBall += 2f;
                Debug.Log("11:" + dificuldade);
                break;
            case 60:
                bola.speedBall += 2f;
                Debug.Log("12:" + dificuldade);
                break;
            case 65:
                bola.speedBall += 2f;
                Debug.Log("13:" + dificuldade);
                break;
            case 70:
                bola.speedBall += 2f;
                Debug.Log("14:" + dificuldade);
                break;
            

        }


        /*if(dificuldade == 5)
        {
            bola.speedBall += 2f;
        }
        else if(dificuldade == 10)
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == 15)
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == 20)
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == 25)
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall +=2f ;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }
        else if (dificuldade == )
        {
            bola.speedBall += 2f;
        }*/


    }
    private void mudaValor()
    {
        auxBotY = bolls.transform.position.y;
        bot.transform.position = new Vector2(-8.629999f, auxBotY);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        GameObject collider = collision.collider.gameObject;        
        Debug.Log("BateuRR");
        dificuldade++;
    }

}
