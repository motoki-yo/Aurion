using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;


    // Use isso para inicialização
    void Start()
    {

        // Obtenha e armazene uma referência ao Rigidbody2D anexado a este GameObject.
        rb2d = GetComponent<Rigidbody2D>();


        // Inicie o objeto em movimento.
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    void Update()
    {

        // Se o jogo acabar, pare de rolar.
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
