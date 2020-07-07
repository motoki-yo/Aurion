using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class temaJogo : MonoBehaviour
{
   
    
    public Text txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10, txt11;
    public TMPro.TMP_Text acertos1, acertos2, acertos3, acertos4, acertos5, acertos6, 
    acertos7, acertos8, acertos9, acertos10, acertos11;

    public string[] nomeTema;

    private int numeroQuestoes;

    private int idTema;

    Usuario usuario;
    SQLite banco;
    // Start is called before the first frame update
    void Start()
    {
        idTema = 0;
        txt1.text = nomeTema[1];
        //acertos1.text = banco.AcertosPorQuestao(usuario.getId(),1).ToString()+"/15";
        txt2.text = nomeTema[2];
        //acertos2.text = banco.AcertosPorQuestao(usuario.getId(),2).ToString()+"/15";
        txt3.text = nomeTema[3];
        //acertos3.text = banco.AcertosPorQuestao(usuario.getId(),3).ToString()+"/15";
        txt4.text = nomeTema[4];
        //acertos4.text = banco.AcertosPorQuestao(usuario.getId(),4).ToString()+"/15";
        txt5.text = nomeTema[5];
        //acertos5.text = banco.AcertosPorQuestao(usuario.getId(),5).ToString()+"/15";
        txt6.text = nomeTema[6];
        //acertos6.text = banco.AcertosPorQuestao(usuario.getId(),6).ToString()+"/15";
        txt7.text = nomeTema[7];
        //acertos7.text = banco.AcertosPorQuestao(usuario.getId(),7).ToString()+"/15";
        txt8.text = nomeTema[8];
        //acertos8.text = banco.AcertosPorQuestao(usuario.getId(),8).ToString()+"/15";
        txt9.text = nomeTema[9];
        //acertos9.text = banco.AcertosPorQuestao(usuario.getId(),9).ToString()+"/15";
        txt10.text = nomeTema[10];
        //acertos10.text = banco.AcertosPorQuestao(usuario.getId(),10).ToString()+"/15";
        txt11.text = nomeTema[11];
        //acertos11.text = banco.AcertosPorQuestao(usuario.getId(),11).ToString()+"/15";
    }

    public void selecioneTema(int i)
    {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
    }

    public void jogar()
    {
        Application.LoadLevel("T" + idTema);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
