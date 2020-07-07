using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public static int id_usuario = 0;
  

    [Header("OBJECTS")]
	public Button myButton;
    public GameObject MainCamera;
    public TMPro.TMP_InputField txtnome;
    public TMPro.TMP_InputField txtsenha;
    public TMPro.TMP_Text txtaviso;
    public TMPro.TMP_Text lblnome;
    public TMPro.TMP_Text lblsenha;
    public TMPro.TMP_Text lblpontuacao;
    public TMPro.TMP_Text lblresp;
     public TMPro.TMP_Text txtArkanoid, txtPong, txtFlappyBird, txtMemoria;
    public GameObject newPanel;
    public GameObject oldPanel;

    public SQLite banco;
    public SliderManager sliderManager;
    public AudioSource asrcAcessDenied;
    public AudioSource asrcLogin;
    public AudioSource asrcReturn;
    public AudioSource asrcSelect;
    public Usuario usuario;

    void Start()
    {
        
        Button btn = myButton.GetComponent<Button>();
        
        if(myButton.name =="btnLogin")
            myButton.onClick.AddListener(Login);
        if(myButton.name =="btnCadastrar")
            myButton.onClick.AddListener(Cadastrar);
        if(myButton.name =="btnPerfil")
            myButton.onClick.AddListener(MostrarPerfil);
        if(myButton.name =="btnConfirmarAlteracao")
            myButton.onClick.AddListener(Alterar);
        if(myButton.name =="btnExit")
            myButton.onClick.AddListener(Sair);
        if(myButton.name == "btnEditarPerfil")
            myButton.onClick.AddListener(MostrarAlterarPerfil);
        if(myButton.name == "ModoLivre")
            myButton.onClick.AddListener(LoadQuiz);
        if(myButton.name == "btnFlappyBird")
            myButton.onClick.AddListener(LoadFB);
        if(myButton.name == "btnArkanoid")
            myButton.onClick.AddListener(LoadArk);
        if(myButton.name == "btnPong")
            myButton.onClick.AddListener(LoadPong);
        if(myButton.name == "btnMemoria")
            myButton.onClick.AddListener(LoadMemo);
        if(myButton.name == "btnReturn")
            myButton.onClick.AddListener(BackToTitle);
        if(myButton.name == "btnMenu")
            myButton.onClick.AddListener(ShowMenu);
        if(myButton.name == "btnCloseMenu")
            myButton.onClick.AddListener(CloseShowMenu);
        if(myButton.name == "btnTutorial")
            myButton.onClick.AddListener(Tutorial);
        if(myButton.name == "btnInfoQ")
            myButton.onClick.AddListener(CallInfoQ);
        if(myButton.name == "btnInfoJ")
            myButton.onClick.AddListener(CallInfoJ);
        if(myButton.name == "btnInfoL")
            myButton.onClick.AddListener(CallInfoL);
        if(myButton.name == "btnAboutUs")
            myButton.onClick.AddListener(AboutUs);
        if(myButton.name == "btnExcluirPerfil")
            myButton.onClick.AddListener(MostrarExcluirPerfil);
        if(myButton.name == "btnConfirmarExclusão")
            myButton.onClick.AddListener(Excluir);
        if(myButton.name == "btnEstatisticas")
            myButton.onClick.AddListener(ShowEstatisticas);
    }

    // Update is called once per frame
    void Login()
    {
        if(txtnome.text != "Username" && txtsenha.text != "Senha" && txtnome.text != null && txtsenha.text != null)
            id_usuario = banco.Login(txtnome.text, txtsenha.text);

        if(id_usuario > 0)
        {
            asrcLogin.Play();
            newPanel.SetActive(true);
            oldPanel.SetActive(false);
            lblpontuacao.text = banco.MostrarPerfil(id_usuario, 2);

        }
        else
        {
            asrcAcessDenied.Play();
            sliderManager.CallPopup("Os dados inseridos são inválidos. Por favor, verifique.");
            
            Debug.Log("Erro no login, ButtonController");
        }
        txtnome.text = "Username";
        txtsenha.text = "Senha";
    }
    void Cadastrar()
    {
        if(!banco.UsuarioExiste(txtnome.text.ToString()) && txtnome.text != null && txtsenha.text != null && txtnome.text != "Username" && txtsenha.text != "Senha" && txtnome.text != "" && txtnome.text != "")
            id_usuario = banco.Inserir(txtnome, txtsenha);

        if(id_usuario > 0)
        {
            asrcLogin.Play();
            newPanel.SetActive(true);
            oldPanel.SetActive(false);
            sliderManager.OpenPnl1();
            lblpontuacao.text = banco.MostrarPerfil(id_usuario, 2);
        }
        else
        {
            asrcAcessDenied.Play();
            if(banco.UsuarioExiste(txtnome.text))
                sliderManager.CallPopup("Já existe um usuário com esse nickname. Por favor, insira outro valor.");
            else
                sliderManager.CallPopup("O cadastro não pôde ser efetivado.");
            
            Debug.Log("Erro no cadastro, ButtonController");
        }
    }

    void MostrarPerfil() // Função para ativada ao acessar o botão de perfil no menu principal
    {
        asrcSelect.Play();
        sliderManager.CloseMenu();
        newPanel.SetActive(true);
        oldPanel.SetActive(false);
        lblnome.text = banco.MostrarPerfil(id_usuario, 0);
        lblsenha.text = "Senha: " + banco.MostrarPerfil(id_usuario, 1);
        lblpontuacao.text = "Pontuação: " + banco.MostrarPerfil(id_usuario, 2);
        //lblresp.text = banco.MostrarPerfil(id_usuario, "respondidas");
        lblresp.text = "Respondeu " + usuario.getPontos() + " questões";
        
    }

    void Alterar()
    {
        asrcSelect.Play();
        if (txtnome.text != "" && txtsenha.text != "")
        {
            banco.AlterarUsuario(id_usuario, txtnome.text, txtsenha.text);
            sliderManager.CloseEditarPerfil();
            MostrarPerfil();
            
        }
            
        
    }

    void Sair()
    {
        asrcReturn.Play();
        id_usuario = 0;
       /*if (Input.GetKeyUp(KeyCode.Escape))
        {
             if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", true);
             }
             else
             {
                 Application.Quit();
             }
         }*/
         txtsenha.text = "Senha";
         txtsenha.inputType = TMPro.TMP_InputField.InputType.Standard;
         usuario.setNick("");
         usuario.setSenha("");
         usuario.setPontos(0);
         usuario.setExc('n');
         usuario.setId(0);
         
         newPanel.SetActive(true);
         oldPanel.SetActive(false);
         
    }
    void MostrarAlterarPerfil()
    {
        asrcSelect.Play();
        sliderManager.CallEditarPerfil();
        sliderManager.CloseMenu();
        txtnome.text = banco.MostrarPerfil(id_usuario, 0);
        txtsenha.text = banco.MostrarPerfil(id_usuario, 1);
        
    }

    /*void TrocarPaineis()
    {
        oldPanel.SetActive(false);
        
        newPanel.SetActive(true);
    } */
    public void LoadQuiz()
    {
        DontDestroyOnLoad(usuario);
        DontDestroyOnLoad(banco);
        Application.LoadLevel("titulo");
    }

    public void LoadFB() // id_jogo = 3
    {
        banco.UsuarioJogo(3,id_usuario);
        banco.Comprar(3,id_usuario);
        //DontDestroyOnLoad(usuario);
       // DontDestroyOnLoad(banco);
        Application.LoadLevel("FinalFlappyBird");
    }
    public void LoadArk() // id_jogo = 1
    {
        banco.UsuarioJogo(1,id_usuario);
        banco.Comprar(3,id_usuario);
        //DontDestroyOnLoad(usuario);
        //DontDestroyOnLoad(banco);
        Application.LoadLevel("Main_Arkanoid");
    }
    public void LoadMemo() // id_jogo = 4
    {
        banco.UsuarioJogo(4,id_usuario);
        banco.Comprar(3,id_usuario);
        //lblpontuacao.text = usuario.getPontos().ToString();
        //DontDestroyOnLoad(usuario);
        //DontDestroyOnLoad(banco);
        Application.LoadLevel("Memoria");
    }
    public void LoadPong() // id_jogo = 2
    {
        banco.UsuarioJogo(2,id_usuario);
        banco.Comprar(3,id_usuario);
       // DontDestroyOnLoad(usuario);
        //DontDestroyOnLoad(banco);
       Application.LoadLevel("Pong");
    }
    public void BackToTitle()
    {
        MainCamera.SetActive(false);
        Application.LoadLevel("UserInterface");
    }

    public void ShowMenu()
    {
        asrcSelect.Play();
        sliderManager.CallMenu();
        lblnome.text = banco.MostrarPerfil(id_usuario, 0);
        
    }
    public void CloseShowMenu()
    {
        asrcSelect.Play();
        sliderManager.CloseMenu();
    }
    public void Tutorial()
    {
        sliderManager.CloseMenu();
        sliderManager.OpenPnl1();
    }

    public void CallInfoQ(){sliderManager.Info("q");}
    public void CallInfoJ(){sliderManager.Info("j");}
    public void CallInfoL(){sliderManager.Info("l");}
    public void AboutUs()
    {
        asrcSelect.Play();
        sliderManager.CloseMenu();
        newPanel.SetActive(true);
        oldPanel.SetActive(false);
    }

    public void MostrarExcluirPerfil()
    {
        asrcSelect.Play();
        sliderManager.CloseMenu();
        sliderManager.OpenExcluir();
        txtsenha.text = "";
    }
    public void Excluir()
    {
        if(txtsenha.text == "" || txtsenha.text == "Senha" || txtsenha.text != usuario.getSenha())
        {
            txtaviso.text = "Senha inválida";
        }
            
        else
        {
            banco.Delete(usuario.getId());
            sliderManager.CloseExcluir();
            Sair();
        }
        
    }

    public void ShowEstatisticas()
    {
        sliderManager.CloseMenu();
        newPanel.SetActive(true);
        oldPanel.SetActive(false);  
        txtArkanoid.text = "Jogou Arkanoid "+ banco.VezesJogado(1,id_usuario).ToString() + " vezes";
        txtPong.text = "Jogou Pong "+ banco.VezesJogado(2,id_usuario).ToString() + " vezes";
        txtMemoria.text ="Jogou Memoria "+ banco.VezesJogado(4,id_usuario).ToString() + " vezes";
        txtFlappyBird.text ="Jogou FlappyBird "+ banco.VezesJogado(3,id_usuario).ToString() + " vezes";
        // colocar aqui para carregar os textos
        // das estatisticas 
    }

}
