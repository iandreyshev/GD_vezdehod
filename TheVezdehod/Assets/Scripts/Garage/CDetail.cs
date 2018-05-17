using UnityEditor;
using UnityEngine;

namespace GarageScene
{
	[System.Serializable]
	public struct DetailData
	{
		public string title;
		public string spritePath;
		public DetailType type;
		public int width;
		public int height;
		public float mass;
		public float speed;
		public float fuelCap;
		public float fuelCons;
	}

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
		public float fuelCap;
		public float fuelCons;

		public CDetail()
		{
		}

		public CDetail(DetailData data)
		{
			title = data.title;
			sprite = Resources.Load<Sprite>(data.spritePath);
			type = data.type;
			width = data.width;
			height = data.height;
			mass = data.mass;
			speed = data.speed;
			fuelCap = data.fuelCap;
			fuelCons = data.fuelCons;
		}

		public DetailData ToDataType()
		{
			return new DetailData
			{
				title = title,
				spritePath = AssetDatabase.GetAssetPath(sprite),
				type = type,
				width = width,
				height = height,
				mass = mass,
				speed = speed,
				fuelCap = fuelCap,
				fuelCons = fuelCons
			};
		}
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
