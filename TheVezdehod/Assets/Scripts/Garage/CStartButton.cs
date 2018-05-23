using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CStartButton : MonoBehaviour
	{
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

			CDataManager.Serialize(car);
			CSceneSwitcher.Road();
		}
	}
}
