using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notaFinal : MonoBehaviour
{
    private int idTema;
    public TMPro.TMP_Text txtNota;
    public TMPro.TMP_Text txtInfoTema;
    private int notaF, acertos,questoes;
    SQLite banco;
    Usuario usuario;

    // Start is called before the first frame update
    void Start()
    {
        
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinalTemp"+idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
        questoes = PlayerPrefs.GetInt("questoesTemp" + idTema.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de "+ questoes.ToString() + " perguntas";
        
        banco.LancarAcertos(idTema, usuario.getId(), acertos, false);
        banco.GanharPontos(notaF, usuario.getId());
        
    }

    public void jogarNovamente()
    {
        Application.LoadLevel("T" + idTema);
    }

    
}
