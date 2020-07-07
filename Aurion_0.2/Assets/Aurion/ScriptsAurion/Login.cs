using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Button MyButton;
    public GameObject newPanel;
    public GameObject oldPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = MyButton.GetComponent<Button>();
        MyButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        oldPanel.SetActive(false);
        newPanel.SetActive(true);
    }
}
