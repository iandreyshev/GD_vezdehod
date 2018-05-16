﻿using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	[CreateAssetMenu(menuName = "Detail")]
	public class CDetail : ScriptableObject
	{
		public string m_name;
		public Sprite m_icon;
		public DetailType m_type;

		public int width;
		public int height;

		public float m_mass;
		public float m_speed;
		public float m_fuelCapasity;
		public float m_fuelPerSec;
	}

	public enum DetailType
	{
		BLOCK,
		ENGINE,
		WHEELS,
		FUEL_BANK,
		ARTIFACT
	}
}
