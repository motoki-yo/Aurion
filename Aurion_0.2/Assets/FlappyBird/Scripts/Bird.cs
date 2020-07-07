using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float upForce;                  // Força para cima da "aba".
    private bool isDead = false;           // O jogador colidiu com uma parede?

    private Animator anim;                  // Referência ao componente Animator.
    private Rigidbody2D rb2d;               // Mantém uma referência ao componente Rigidbody2D do pássaro.

    void Start()
    {

        // Obtenha referência ao componente Animator anexado a este GameObject.
        anim = GetComponent<Animator>();

        // Obtenha e armazene uma referência ao Rigidbody2D anexado a este GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        upForce = 105f;

        // Não permita o controle se o pássaro morreu.
        if (isDead == false)
        {
            // Procura por entrada para acionar uma "aba".
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {

                //..Torne o animador sobre isso e então ...
                anim.SetTrigger("Flap");
                GetComponent<AudioSource>().Play();

                //...zero a velocidade atual das aves antes de ...
                rb2d.velocity = Vector2.zero;

                // new Vector2 (rb2d.velocity.x, 0);
                //..dando ao pássaro alguma força para cima.
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
         
        // Zerar a velocidade do pássaro
        rb2d.velocity = Vector2.zero;

        // Se o pássaro colidir com algo, ele está morto ...
        isDead = true;

        //..Tell o Animator sobre isso ...
        anim.SetTrigger("Die");
        //... e diga ao controle do jogo sobre isso.
        GameControl.instance.BirdDied();
    }
    public void voltarScene()
    {
        Application.LoadLevel("UserInterface");
    }
    public void continuar()
    {
        // Reinicializa a cena.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
