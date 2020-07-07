using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class responderSimulado : MonoBehaviour
{
    //int countDownStartValue = 120; //2 minutos
   //public Text timerUI; //nome do objeto texto na interface 

    public int idSimulado;
    public TMPro.TMP_Text pergunta;
    public TMPro.TMP_Text respostaA;
    public TMPro.TMP_Text respostaB;
    public TMPro.TMP_Text respostaC;
    public TMPro.TMP_Text respostaD;
    public TMPro.TMP_Text respostaE;
    public TMPro.TMP_Text infoResp;
    public TMPro.TMP_Text tempo;

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
    public float targetTime = 120;
    // Start is called before the first frame update
    void Start()
    {
        idSimulado = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        respostaE.text = alternativaE[idPergunta];
        tempo.text = targetTime.ToString();
        infoResp.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";
        //countDownTimer();
        
        
    }

    public void resposta(string alternativa)
    {
        
        if (alternativa == "A")
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
        targetTime = 120;
    }
    private void Update()
    {
        TimeSpan timespan = TimeSpan.FromSeconds(targetTime);
        tempo.text = timespan.Minutes + ":" + timespan.Seconds;
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f )
        {
            proximaPergunta();
            targetTime = 120;
        }
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

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idSimulado.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idSimulado.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idSimulado.ToString(), (int)acertos);
                PlayerPrefs.SetInt("questoes" + idSimulado.ToString(), (int)questoes);
            }

            PlayerPrefs.SetInt("notaFinal" + idSimulado.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertos" + idSimulado.ToString(), (int)acertos);
            PlayerPrefs.SetInt("questoes" + idSimulado.ToString(), (int)questoes);

            Application.LoadLevel("notaFinalSimulado");
            // o que fazer se terminar as perguntas
        }


    }
}

