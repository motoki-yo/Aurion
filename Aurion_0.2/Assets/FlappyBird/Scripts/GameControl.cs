using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;          // Uma referência ao nosso script de controle de jogo para que possamos acessá-lo estaticamente.
    public Text scoreText;                       // Uma referência ao componente de texto da interface do usuário que exibe a pontuação do jogador.
    public GameObject gameOvertext;             // Uma referência ao objeto que exibe o texto que aparece quando o jogador morre.
    public GameObject painel;
    public GameObject button;
    private int score = 0;                     // Pontuação do jogador.
    public bool gameOver = false;             // O jogo acabou?
    public float scrollSpeed = -1.5f;

    void Awake()
    {

        // Se não temos atualmente um controle de jogo ...
        if (instance == null)

            //...seta este para ser isso ...
            instance = this;

        //...de outra forma...
        else if (instance != this)


            // ... destrua este porque é um duplicado.
            Destroy(gameObject);
    }

    void Update()
    {

        // Se o jogo acabou e o jogador pressionou alguma entrada ...
        /*if (gameOver && Input.GetMouseButtonDown(0))
        {

            //...recarregue a cena atual.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }

    public void BirdScored()
    {

        // O pássaro não pode marcar se o jogo acabar.
        if (gameOver)
            return;

        // Se o jogo não acabar, aumenta a pontuação ..
        score++;

        //...e ajuste o texto da partitura
        scoreText.text = "Pontuação: " + score.ToString();
    }

    public void BirdDied()
    {
       
        // Ativar o jogo sobre o texto.
        //gameOvertext.SetActive(true);

        //painel.transform.position = new Vector2(0, 0);
         painel.SetActive(true);  // chamar o GameObject Painel
        //button.SetActive(true);

        // Defina o jogo para acabar.
        gameOver = true;
    }
}
