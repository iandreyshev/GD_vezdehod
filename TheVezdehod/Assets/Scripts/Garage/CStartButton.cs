using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CStartButton : MonoBehaviour
	{
		public CGridModel GridModel { get; set; };

		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		private void OnClick()
		{
			var car = new CCar();

			m_grid.

			CDataManager.Serialize();
		}
	}
}
