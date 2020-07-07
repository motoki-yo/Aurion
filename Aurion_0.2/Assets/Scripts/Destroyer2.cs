using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer2 : MonoBehaviour
{
    private GameObject bot;
    private float tempo, pontuacao = 0f;
    public Bot_Racket buti;
    public GameObject painel;
    public ativapainel conect;
    ///
    void OnCollisionEnter2D(Collision2D collision)
    {
        ativapainel conect = new ativapainel();
       // ativar();
        painel.gameObject.SetActive(true);
        bot = GameObject.FindGameObjectWithTag("Bot");
        Destroy(bot);
        GameObject collider = collision.collider.gameObject;
        GameObject.Destroy(collider);
        Debug.Log("Game Over");
        Debug.Log(tempo);
        conect.ativar();
        
       
    }
    private void Start()
    {
       painel.gameObject.SetActive(false);
    }
    public void Voltar()
    {
        SceneManager.LoadScene("UserInterface");
    }

    public void Reiniciar()
    {
        Debug.Log("clicou");
        SceneManager.LoadScene("Pong");
    }

    private void ativar()
    {
       // painel.gameObject.SetActive(true);
    }
}
