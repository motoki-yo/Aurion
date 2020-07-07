using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenSceneByString : MonoBehaviour
{
    [Header("OBJECTS")]
    public Button myButton;
    public string NameOfScene;


    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        SceneManager.LoadScene(NameOfScene);
    }
}
