using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativapainel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject painel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ativar()
    {
        painel.gameObject.SetActive(true);
    }
}
