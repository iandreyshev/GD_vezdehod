using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	[CreateAssetMenu(menuName = "Detail")]
	public class CDetail : ScriptableObject
	{
		public string title;
		public Sprite sprite;
		public DetailType type = DetailType.BLOCK;

		public int width = 1;
		public int height = 1;

		public float mass;
		public float speed;
		public float fuelCapasity;
		public float fuelPerSec;
	}

	public enum DetailType
	{
		SKELETON,
		BLOCK,
		ENGINE,
		WHEEL,
		FUEL_BANK,
		ARTIFACT
	}
}
