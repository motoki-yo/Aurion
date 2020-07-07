using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;       // Isso armazena uma referência ao colisor anexado ao solo.
    private float groundHorizontalLength;
    public float aux;// Um float para armazenar o comprimento do eixo x do collider2D anexado ao Ground GameObject.

    // Awake é chamado antes de Start.
    private void Awake()
    {

        // Obtenha e armazene uma referência ao collider2D anexado ao Ground.
        groundCollider = GetComponent<BoxCollider2D>();

        // Armazena o tamanho do colisor ao longo do eixo x (seu comprimento em unidades).
        groundHorizontalLength = groundCollider.size.x;
    }


    // Atualiza as execuções uma vez por quadro
    private void Update()
    {

        // Verifique se a diferença ao longo do eixo x entre a câmera principal e a posição do objeto ao qual esta conectada é maior que groundHorizontalLength.
        if (transform.position.x < -groundHorizontalLength)
        {

            // Se true, isso significa que esse objeto não está mais visível e podemos movê-lo para a frente com segurança para ser reutilizado.
            RepositionBackground(aux);
        }
    }



    // Move o objeto ao qual este script está anexado para criar nosso efeito de fundo de looping.
    private void RepositionBackground(float aux)
    {

        // Isto é o quão longe para a direita moveremos nosso objeto de fundo, neste caso, o dobro de seu comprimento. Isso irá posicioná-lo diretamente à direita do objeto de plano de fundo atualmente visível.
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);


        // Mover este objeto de sua posição fora da tela, atrás do jogador, para a nova posição fora da câmera na frente do jogador.
        transform.position = (Vector2)transform.position + groundOffSet;
    }


}