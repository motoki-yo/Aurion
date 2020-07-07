using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public Button myButton;
    public string sceneName, returnPanel;
    public Usuario usuario;
    public SQLite banco;
    GameObject active, inactive;
    int id_animal;
    void Start()
    {
        id_animal = 0;
        Button btn = myButton.GetComponent<Button>();
        active = GameObject.Find(returnPanel);
        if(myButton.name == "Button")
            myButton.onClick.AddListener(ReturnToUI);
        else
        {
            if(myButton.name == "btnAnt")
                id_animal = 1;
            if(myButton.name == "btnBear")
                id_animal = 2;
            if(myButton.name == "btnBee")
                id_animal = 3;
            if(myButton.name == "btnButterfly")
                id_animal = 4;
            if(myButton.name == "btnFrog")
                id_animal = 5;
            if(myButton.name == "btnScorpione")
                id_animal = 6;
            if(myButton.name == "btnSnail")
                id_animal = 7;
            if(myButton.name == "btnWolf")
                id_animal = 8;
            
            myButton.onClick.AddListener(openSceneAR);
        }
            
    }

    // Update is called once per frame
    public void openSceneAR()
    {
        banco.UsuarioAnimal(usuario.getId(), id_animal);
        banco.Comprar(3,usuario.getId());
        DontDestroyOnLoad(this.usuario);
        DontDestroyOnLoad(this.banco);
        Application.LoadLevel(sceneName);
        
    }
    public void ReturnToUI()
    {
        //banco.Login(usuario.getNick(), usuario.getSenha());
        Application.LoadLevel(sceneName);
        //active.SetActive(true);
    }
}
