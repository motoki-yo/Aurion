using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LUI_UIAnimManager : MonoBehaviour {

	/*[Header("ANIMATORS")]
	public Animator oldAnimator;
	public Animator newAnimator;*/

	[Header("OBJECTS")]
	public Button animButton;
	public GameObject newPanel;
    public GameObject oldPanel;
	public TMPro.TMP_Text lblpontuacao;
	public TMPro.TMP_Text lblmain;

	/*[Header("ANIM NAMES")]
	public string oldAnimText;
	public string newAnimText;*/

	void Start ()
	{
        //oldAnimator.GetComponent<Animator>();
        //newAnimator.GetComponent<Animator>();
        Button btn = animButton.GetComponent<Button>();
        animButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
        oldPanel.SetActive(false);
		newPanel.SetActive(true);
		lblpontuacao.text = lblmain.text;
		/*oldAnimator.Play(oldAnimText);
		newAnimator.Play(newAnimText);*/
	}
}