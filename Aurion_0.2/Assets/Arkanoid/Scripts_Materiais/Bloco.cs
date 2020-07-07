using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;

public class Bloco : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public BoxCollider2D collider;
    public static int pontos;
    public static int qtde_blocos = 40;
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.constraints = new RigidbodyConstraints2D();
        collider.isTrigger = true;
        pontos += 10;
        qtde_blocos--;

        if (qtde_blocos == 35)
        {
            Bolinha.Speed.x += 2;
            Bolinha.Speed.y += 2;
            Bolinha.rigido.AddForce(Bolinha.Speed);
            Jogador.Velocidade += 2;
        }
        if (qtde_blocos == 30)
        {
            Bolinha.Speed.x += 2;
            Bolinha.Speed.y += 2;
            Bolinha.rigido.AddForce(Bolinha.Speed);
            Jogador.Velocidade += 2;
        }
        if (qtde_blocos == 20)
        {
            Bolinha.Speed.x += 2;
            Bolinha.Speed.y += 2;
            Bolinha.rigido.AddForce(Bolinha.Speed);
            Jogador.Velocidade += 2;
        }
        if (qtde_blocos == 10)
        {
            Bolinha.Speed.x += 2;
            Bolinha.Speed.y += 2;
            Bolinha.rigido.AddForce(Bolinha.Speed);
            Jogador.Velocidade += 2;
        }


        if (qtde_blocos == 0)
        {
            Debug.Log("PONTUAÇÃO: "+pontos);
            //Show_point.MostraPontos(pontos);
            Application.Quit();
        }

        if(Bolinha.Speed.x > 20 && Bolinha.Speed.y > 20)
        {
            Bolinha.Speed.x = 20;
            Bolinha.Speed.y = 20;
        }
        
    }
    /*public static void AumentaSpeed(int qtde_blocos)
    {
        Rigidbody2D rigido = GetComponent<Rigidbody2D>();
        rigido.AddForce();
        if (qtde_blocos <= 35)
        {
            int aux = Convert.ToInt16(Bolinha.Speed);
            aux += 5;
        }
        if (qtde_blocos <= 30)
        {
            int aux = Convert.ToInt16(Bolinha.Speed);
            aux += 5;
        }
    }*/
}
