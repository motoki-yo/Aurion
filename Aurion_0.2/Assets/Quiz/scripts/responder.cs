using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class responder : MonoBehaviour
{
    public int idTema;
    public TMPro.TMP_Text pergunta;
    public TMPro.TMP_Text respostaA;
    public TMPro.TMP_Text respostaB;
    public TMPro.TMP_Text respostaC;
    public TMPro.TMP_Text respostaD;
    public TMPro.TMP_Text respostaE;
    public TMPro.TMP_Text infoResp;

    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] alternativaE;

    public string[] corretas;

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        respostaE.text = alternativaE[idPergunta];
        infoResp.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";
        

    }

    public void resposta(string alternativa)
    {
        if(alternativa=="A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp a
        }

        if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp b
        }

        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp c
        }

        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp d
        }

        else if (alternativa == "E")
        {
            if (alternativaE[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp e
        }
        proximaPergunta();
    }

   void proximaPergunta()
    {
        idPergunta += 1;

        if (idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];
            respostaE.text = alternativaE[idPergunta];
            infoResp.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas ";
        }

        else
        {
            media = (acertos / questoes) * 10;
            notaFinal = Mathf.RoundToInt(media);// arredonda para o proximo inteiro
             
            if(notaFinal>PlayerPrefs.GetInt("notaFinal"+idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);
                PlayerPrefs.SetInt("questoes" + idTema.ToString(), (int)questoes);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            PlayerPrefs.SetInt("questoesTemp" + idTema.ToString(), (int)questoes);

            Application.LoadLevel("notaFinal");
          // o que fazer se terminar as perguntas
        }


    }

}
