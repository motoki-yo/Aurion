using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [Header("PANELS")]
    public GameObject pnlLogin;
    public GameObject pnlCadastro;
    public GameObject pnlHome;
    public GameObject pnlSelecionarJogo;
    public GameObject pnlQuizTemas;
    public GameObject pnlHelp;
    public GameObject pnlOptions;
    public GameObject pnlPerfil;
    // Start is called before the first frame update
    void Start()
    {
        pnlPerfil.SetActive(false);
        pnlHome.SetActive(false);
        pnlCadastro.SetActive(false);
        pnlHelp.SetActive(false);
        pnlOptions.SetActive(false);
        pnlQuizTemas.SetActive(false);
        pnlSelecionarJogo.SetActive(false);
        pnlLogin.SetActive(true);
    }

    public void TrocarPainel(string desativar, string ativar)
    {
        GameObject.Find(desativar).SetActive(false);
        GameObject.Find(ativar).SetActive(true);
    }

}
