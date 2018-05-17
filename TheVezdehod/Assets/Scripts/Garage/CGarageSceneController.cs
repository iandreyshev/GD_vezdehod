using UnityEngine;
using UnityEngine.UI;

public class CGarageSceneController : MonoBehaviour
{
	[SerializeField]
	private Button m_backButton;

	private void Awake()
	{
		m_backButton.onClick.AddListener(OnBackButtonClick);
	}

	private void OnBackButtonClick()
	{
		CSceneController.Menu();
	}
}
