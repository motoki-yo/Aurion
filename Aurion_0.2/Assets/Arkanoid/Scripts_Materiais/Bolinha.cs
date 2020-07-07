using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    public static Vector2 Speed;
    public static Rigidbody2D rigido;
    public GameObject bolao;
    void Start()
    {
        Speed.x = Random.Range(15,25);
        Speed.y = Random.Range(15,25);
        Debug.Log(Speed.x);
        Debug.Log(Speed.y);
        rigido = GetComponent<Rigidbody2D>();
        //LINHA ORIGEM rigido.AddForce(new Vector2(10, 10); ////adiciona força em um vetor2 x e y
        rigido.AddForce(Speed);//adicionará somente o vetor e pelo unity regularemos a força, manualmente
        /*if(Bloco.qtde_blocos <=35)
        {
            Speed.x = 20;
            Speed.y = 20;
            rigido.AddForce(Speed);
            Debug.Log(Speed);
            Debug.Log(Bloco.qtde_blocos);
        }
        if (Bloco.qtde_blocos <= 25)
        {
            Speed.x = 25;
            Speed.y = 25;
            rigido.AddForce(Speed);
        }*/
    }
    public void movLeft()
    {
        for (int i = 0; i < 3; i++)
            bolao.transform.position = new Vector2(-i,0);
    }
    
}
