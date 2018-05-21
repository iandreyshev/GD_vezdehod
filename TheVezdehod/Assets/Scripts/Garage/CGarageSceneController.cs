using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
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
			CSceneSwitcher.Menu();
		}
	}
}
