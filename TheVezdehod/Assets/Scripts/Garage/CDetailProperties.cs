using UnityEngine;

namespace GarageScene
{
	public class CDetailProperties : MonoBehaviour
	{
		void Start()
		{
			CloseView();
		}

		public void Set(CDetail detail)
		{
			if (detail == null)
			{
				CloseView();
				return;
			}

			ShowDetailProperties(detail);
		}

		private void ShowDetailProperties(CDetail detail)
		{
			// TODO: Show properties
		}

		private void CloseView()
		{
			// TODO: Close view with properties
		}
	}
}
