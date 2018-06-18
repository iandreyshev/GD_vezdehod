using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CStartButton : MonoBehaviour
	{
		[SerializeField]
		private CGame m_game;

		public CGridModel GridModel { get; set; }

		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		private void OnClick()
		{
			var car = new CCar();

			foreach (GridItem item in GridModel.GetInstalledBlocks())
			{
				car.Insert(item.detail, item.x, item.y);
			}

			m_game.Road(car);
		}
	}
}
