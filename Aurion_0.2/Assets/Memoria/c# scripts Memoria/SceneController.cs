using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Colunas x linhas
    public const int gridRows = 5;
    public const int gridCols = 2;

    //posição das cartas
    public const float offsetX = 4.3f;
    public const float offsetY = 3f;

    int tentativas = 5;

    //gameobjects
    [SerializeField] public GameObject bg;
    [SerializeField] public MainCard conect;
    [SerializeField] public MainCard originalCard;
    [SerializeField] public Sprite[] images;
    [SerializeField] public GameObject vida2;
    [SerializeField] public GameObject vida3;
    [SerializeField] public GameObject vida4;
    [SerializeField] public GameObject vida5;
    [SerializeField] public GameObject vida1;

    [SerializeField] private GameObject recomecar;

    public void btnRestart_click()
    {
        SceneManager.LoadScene("Memoria");
        //novo jogo
    }

    private void clonar(bool ativado)
    {
        //trabalha com o posicionamento das cartas
        recomecar.SetActive(false);
        Vector2 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };//vetor de animais ( 4 animais)

        numbers = shuffleArray(numbers);//embaralhar
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];

                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;

                card.transform.position = new Vector2(posX, posY);
                card.transform.gameObject.SetActive(ativado);

                

            }
        }
    }

    public void Start()
    {
        clonar(true);//clonar as cartas
    }
 

    private int[] shuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i<newArray.Length; i++ )
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);//sorteio
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }

        return newArray;
    }

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int score = 0;
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField] private TextMesh Tentativas;

    public bool canReveal
    {
        get { return _secondRevealed == null;  }
    }

    public void cardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
           
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()//Cuida das vidas do jogador
    {
        if(_firstRevealed.id == _secondRevealed.id)//Se as cartas baterem
        {
            score++;
            scoreLabel.text = "Pontuação: " + score;
           // tentativas++;
            //Tentativas.text = "Tentativas: " + tentativas;
            if(tentativas > 5)
            {
                tentativas = 5;
                
            }
            if(tentativas == 5)
            {
                vida5.SetActive(true);
            }
            if (tentativas == 4)
            {
                vida4.SetActive(true);
                vida5.SetActive(false);
            }
            if (tentativas == 3)
            {
                vida3.SetActive(true);
                vida4.SetActive(false);
            }
            if (tentativas == 2)
            {
                vida2.SetActive(true);
                vida3.SetActive(false);
            }
            if (tentativas == 1)
            {
                vida1.SetActive(true);
                vida2.SetActive(false);
            }

            if(score == 5)
            {
                vida1.SetActive(false);
                vida2.SetActive(false);
                vida3.SetActive(false);
                vida4.SetActive(false);
                vida5.SetActive(false);

                bg.transform.position = new Vector2(-0.05f, 0);
                recomecar.SetActive(true);
                var clones = GameObject.FindGameObjectsWithTag("carta");
                foreach (var clone in clones)
                {
                    Destroy(clone);


                    //sair
                }
            }

        }
        else//se as cartas não baterem
        {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();

            tentativas--;
            if (tentativas <= 0)
            {

                bg.transform.position = new Vector2(-0.05f, 0);

                vida1.SetActive(false);
                recomecar.SetActive(true);
                var clones = GameObject.FindGameObjectsWithTag("carta");
                foreach (var clone in clones)
                {
                    Destroy(clone);


                    //sair
                }
            }
            if(tentativas == 4)
            {
                vida4.SetActive(true);
                vida5.SetActive(false);
            }
            if (tentativas == 3)
            {
                vida3.SetActive(true);
                vida4.SetActive(false);
            }
            if (tentativas == 2)
            {
                vida2.SetActive(true);
                vida3.SetActive(false);
            }
            if (tentativas == 1)
            {
                vida1.SetActive(true);
                vida2.SetActive(false);
            }
            // else
            //{
            //Tentativas.text = "Tentativas: " + tentativas;
            // }

        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void voltar()
    {
        SceneManager.LoadScene("UserInterface");
    }
    
}
