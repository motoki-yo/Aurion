using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notaFinalSimulado : MonoBehaviour
{
    private int idSimulado;
    public TMPro.TMP_Text txtNota;
    public TMPro.TMP_Text txtInfoTema;
    private int notaF, acertos, questoes;
    SQLite banco;
    Usuario usuario;

    // Start is called before the first frame update
    void Start()
    {
        
        idSimulado = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinal" + idSimulado.ToString());
        acertos = PlayerPrefs.GetInt("acertos" + idSimulado.ToString());

        questoes = PlayerPrefs.GetInt("questoes" + idSimulado.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de " + questoes.ToString() + " perguntas";

        banco.GanharPontos(notaF, usuario.getId());
        banco.LancarAcertos(idSimulado, usuario.getId(), acertos, true);
        
    }

    public void jogarNovamente()
    {
        Application.LoadLevel("Simulado" + idSimulado);
    }


}
