using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    //Usuario usuario;
    public TMPro.TMP_Text pont;
    public GameObject back;
    public Button rstart;
    public void Reiniciar()
    {
       // if(usuario.getPontos() >= 0)
        //{
          //  DontDestroyOnLoad(usuario);
            Application.LoadLevel("Main_Arkanoid");
        //}
        //else
        /*{

            back.gameObject.SetActive(true);
            rstart.gameObject.SetActive(false);
            pont.text = "VOCÊ NÃO TEM PONTOS O SUFICIENTE!";
        }*/

        
    }
}
