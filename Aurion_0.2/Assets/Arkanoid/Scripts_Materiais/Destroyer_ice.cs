using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Destroyer_ice : MonoBehaviour
{
    public AssetBundle assetPong;
    private string[] scenePaths;
    public TMPro.TMP_Text pont;
    public Image back;
    public Button rstart;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        
        Debug.Log("BOLINHA FOI PRO BREJO");
        Debug.Log("Quit");
        Debug.Log("PONTUAÇÃO:" + Bloco.pontos);

        back.gameObject.SetActive(true);
        rstart.gameObject.SetActive(false);
        if (Bloco.pontos > 271)
        {
            pont.text = "PARABÉNS!\nPONTUAÇÃO MÁXIMA: " + Bloco.pontos;
        }
        else
        {
            pont.text = "FIM DE JOGO!\nPONTUAÇÃO: " + Bloco.pontos;
        }
        //Show_point.MostraPontos(Bloco.pontos);
        GameObject.Destroy(collider);
        //SceneManager.LoadScene("scene");
        // Application.Quit();
        /*if(morte)
        {
            LoadPongLevel();
        }*/
        /*assetPong = AssetBundle.LoadFromFile("C:/Biosys/Aureon/AurionNew/Arkanoid/Arkanoid/Pong/Assets");
        scenePaths = assetPong.GetAllScenePaths();
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);*/
    }
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.Destroy(collider.gameObject);
    }
    /*void LoadPongLevel()
    {
        SceneManager.LoadScene("scene");
    }*/
}
