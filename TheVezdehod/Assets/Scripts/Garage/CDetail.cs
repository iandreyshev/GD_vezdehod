using UnityEditor;
using UnityEngine;

namespace GarageScene
{
	[System.Serializable]
	public class DetailData
	{
		public string title;
		public Sprite sprite;
		public DetailType type;
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
		public DetailType type = DetailType.Block;

		public float mass;
		public float speed;
		public float fuelCap;
		public float fuelCons;

		public DetailData Data
		{
			get
			{
				return new DetailData
				{
					title = title,
					sprite = sprite,
					type = type,
					mass = mass,
					speed = speed,
					fuelCap = fuelCap,
					fuelCons = fuelCons
				};
			}
		}

		public CDetail()
		{
		}

		public CDetail(DetailData data)
		{
			title = data.title;
			sprite = data.sprite;
			type = data.type;
			mass = data.mass;
			speed = data.speed;
			fuelCap = data.fuelCap;
			fuelCons = data.fuelCons;
		}
	}

	public enum DetailType
	{
		Block,
		Engine,
		Wheel,
		FuelBank,
		Artifact
	}
}
