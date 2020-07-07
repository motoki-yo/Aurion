using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class csv : MonoBehaviour
{
    public string caminho;
    private StreamWriter salva;
    // Start is called before the first frame update
    void Start()
    {
        caminho = Application.dataPath + "/biosys.csv";
        Debug.Log(caminho);

        salva = new StreamWriter(caminho, true);

        salva.WriteLine("felipe,200");
        salva.Flush();
        salva.Close();

        string ler = File.ReadAllText(caminho);

        string[] linhas = ler.Split("\n"[0]);
        for (var i = 0; i < linhas.Length; i++)
        {
            string[] partes = linhas[i].Split(","[0]);

            Debug.Log("Nome:" + partes[0] + "\n Dinheiro:" + partes[1]);
        }
    }
}
