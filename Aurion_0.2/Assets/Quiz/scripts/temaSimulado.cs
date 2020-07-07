using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temaSimulado : MonoBehaviour
{
    string idSimulado = "";
    public Usuario usuario;
    public SQLite banco;

    // Start is called before the first frame update
    void Start()
    {

        
        int valorInteiro = Random.Range(1, 5);

         idSimulado = valorInteiro.ToString();


    }

    public void jogar()
    {
        DontDestroyOnLoad(usuario);
        DontDestroyOnLoad(banco);
        Application.LoadLevel("Simulado" + idSimulado);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
