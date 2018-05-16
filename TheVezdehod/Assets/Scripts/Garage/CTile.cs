using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CTile : MonoBehaviour
	{
		public Vector2Int Position { get; set; }
		public Button Button { get { return GetComponent<Button>(); } }
	}
}
