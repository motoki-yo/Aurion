using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {

            // Se o pássaro acertar o colisor de gatilho entre as colunas,

            // diz ao controle do jogo que o pássaro marcou.
            GameControl.instance.BirdScored();
        }
    }
}
