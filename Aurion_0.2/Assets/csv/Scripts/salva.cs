using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class salva : MonoBehaviour
{
    public TMPro.TMP_InputField txtnome;
    public TMPro.TMP_InputField txtsenha;
    public TMPro.TMP_Text lblvertudo;

    private string caminho;
    private StreamWriter salvar;

    // Start is called before the first frame update
    void Start()
    {
        caminho = Application.persistentDataPath + "/csv/biosys.csv";
    }
        
    public void SalvaCSV()
    {
        salvar = new StreamWriter(caminho, true);
        string dados = txtnome.text + "," + txtsenha.text + ", 0";
        Debug.Log(dados);
        salvar.WriteLine(dados);
        salvar.Flush();
        salvar.Close();

       
    }
    public void LerCSV()
    {
        string ler = File.ReadAllText(caminho);

        string[] linhas = ler.Split("\n"[0]);
        //for (var i = 0; i < linhas.Length; i++)
       // {
            string[] partes = linhas[0].Split(","[0]);

            lblvertudo.text += "Nome:" + partes[0] + " - Dinheiro:" + partes[1] + "\n";

            Debug.Log("Nome:" + partes[0] + "\n Dinheiro:" + partes[1]);
        //}
    }
}
