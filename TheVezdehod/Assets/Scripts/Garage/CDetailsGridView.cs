using UnityEngine;

namespace GarageScene
{
	public class CDetailsGridView : MonoBehaviour
	{
		public void OnDetailClick(CDetail detail)
		{
			Debug.Log("Detail " + detail.ToString());
		}
	}
}
