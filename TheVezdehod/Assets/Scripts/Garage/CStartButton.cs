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

			foreach (GridItem item in GridModel.GetInstalledItems())
			{
				car.Insert(item.detail, (int)item.col, (int)item.row);
			}

			CDataManager.Serialize(car);
		}
	}
}
