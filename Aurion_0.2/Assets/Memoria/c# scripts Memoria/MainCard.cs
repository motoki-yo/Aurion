using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject verso;//Controle do verso das cartas

   public void OnMouseDown()
    {

      
            if ((verso.activeSelf && controller.canReveal))
            {
                verso.SetActive(false);
                controller.cardRevealed(this);
                
            }
        
    }

   

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)//gerar clones com cartas diferentes
    {
        this._id = id;
        GetComponent<SpriteRenderer>().sprite = image;//para selecionar e mudar as propriedades do sprite

    }

    public void Unreveal()//esconde a carta
    {
        verso.SetActive(true);
    }

}
