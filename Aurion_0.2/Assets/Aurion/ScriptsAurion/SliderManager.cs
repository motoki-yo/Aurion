using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform popup, editarperfil, excluirperfil, menu, tp1, tp2, tp3, infoq, infoj, infol;
    public Button closePopup, closeEP, closeMenu, closeExluirPerfil;
    public Button xiq, xij, xil;
    public Button gotoPnl2, gotoPnl3, retoPnl1, retoPnl2, endTutorial;
    public Image _popupIcon;
    public TMPro.TMP_Text popupText;
    void Start()
    {
        Button btnPopup = closePopup.GetComponent<Button>();
        closePopup.onClick.AddListener(ClosePopup);
        popup.DOAnchorPos(new Vector2(-450,2000),0.01f);

        Button btnEP = closeEP.GetComponent<Button>();
        closeEP.onClick.AddListener(CloseEditarPerfil);
        editarperfil.DOAnchorPos(new Vector2(-2000,200),0.025f);

        Button btnMenu = closeMenu.GetComponent<Button>();
        closeMenu.onClick.AddListener(CloseMenu);
        menu.DOAnchorPos(new Vector2(2000,200),0.025f);

        Button btnpnl2 = gotoPnl2.GetComponent<Button>(); // abre a segunda tela do tutorial
            gotoPnl2.onClick.AddListener(OpenPnl2);

        Button btnpnl3 = gotoPnl3.GetComponent<Button>(); // abre a terceira tela do tutorial
            gotoPnl3.onClick.AddListener(OpenPnl3);
        
         Button btnpnl1 = retoPnl1.GetComponent<Button>(); // volta pra primeira tela do tutorial
            retoPnl1.onClick.AddListener(OpenPnl1);

        Button btnpnl32 = gotoPnl2.GetComponent<Button>(); // volta pra segunda tela do tutorial
            retoPnl2.onClick.AddListener(OpenPnl2);

        Button btnend = endTutorial.GetComponent<Button>(); // finaliza o tutorial
            endTutorial.onClick.AddListener(ClosePnl3);

        Button cInfoq = xiq.GetComponent<Button>();
            xiq.onClick.AddListener(CloseInfoQ);
        
        Button cInfoj = xij.GetComponent<Button>();
            xij.onClick.AddListener(CloseInfoJ);

        Button cInfol = xil.GetComponent<Button>();
            xil.onClick.AddListener(CloseInfoL);

        Button xperfil = closeExluirPerfil.GetComponent<Button>();
            closeExluirPerfil.onClick.AddListener(CloseExcluir);

        
    }

    // Update is called once per frame
    public void CallPopup(string txt)
    {
        //Sprite myIcon = Resources.Load<Sprite>("Assets/Lomenu UI/Textures/Hexart Layout/Icons/"+img);
        //popupIcon.sprite = myIcon;
        popupText.text = txt;
        popup.DOAnchorPos(new Vector2(-450,50),0.35f);
    }
    public void ClosePopup(){popup.DOAnchorPos(new Vector2(-450,2000),0.35f);}

    public void CallEditarPerfil(){editarperfil.DOAnchorPos(new Vector2(-465,40),0.035f);}
    public void CloseEditarPerfil(){editarperfil.DOAnchorPos(new Vector2(-2000,200),0.035f);}
    public void CallMenu(){menu.DOAnchorPos(new Vector2(-595,15),0.065f);}
    public void CloseMenu(){menu.DOAnchorPos(new Vector2(-1497,15),0.065f);}
    public void OpenPnl1()
    {
        tp2.DOAnchorPos(new Vector2(-4031,15),0.065f);
        tp1.DOAnchorPos(new Vector2(-458,15),0.065f); 
    }
    public void OpenPnl2()
    {
        tp3.DOAnchorPos(new Vector2(-2879,15),0.065f);
        tp1.DOAnchorPos(new Vector2(-5168,15),0.065f); 
        tp2.DOAnchorPos(new Vector2(-458,15),0.065f);
    }
    public void OpenPnl3()
    {
        tp2.DOAnchorPos(new Vector2(-4031,15),0.065f);
        tp3.DOAnchorPos(new Vector2(-458,15),0.065f);
    }
    public void ClosePnl3(){tp3.DOAnchorPos(new Vector2(-2879,15),0.065f);}

    public void Info(string i)
    {
        switch(i)
        {
            case "q":
                infoq.DOAnchorPos(new Vector2(-458,15),0.065f);
                break;
            case "j":
                infoj.DOAnchorPos(new Vector2(-458,15),0.065f);
                break;
            case "l":
                infol.DOAnchorPos(new Vector2(-458,15),0.065f);
                break;
        }
    }
    public void CloseInfoJ(){infoj.DOAnchorPos(new Vector2(-458,3912),0.065f);}
    public void CloseInfoQ(){infoq.DOAnchorPos(new Vector2(-458,5197),0.065f);}
    public void CloseInfoL(){infol.DOAnchorPos(new Vector2(-458,2757),0.065f);}

    public void OpenExcluir(){excluirperfil.DOAnchorPos(new Vector2(-454,133),0.065f);}
    public void CloseExcluir(){excluirperfil.DOAnchorPos(new Vector2(1764,133),0.065f);}



}
