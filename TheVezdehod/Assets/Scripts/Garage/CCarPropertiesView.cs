using System.Collections.Generic;
using UnityEngine;

namespace GarageScene
{
	public class CCarPropertiesView : MonoBehaviour
	{
		[SerializeField]
		private CPropertyBar m_mass;
		[SerializeField]
		private CPropertyBar m_speed;
		[SerializeField]
		private CPropertyBar m_fuelCap;
		[SerializeField]
		private CPropertyBar m_fuelCons;

		[SerializeField]
		private float m_max = 100;

		public void Set(List<CDetail> carDetails)
		{
			float mass = 0;
			float speed = 0;
			float fuelCap = 0;
			float fuelCons = 0;

			foreach(CDetail detail in carDetails)
			{
				mass += detail.mass;
				speed += detail.speed;
				fuelCap += detail.fuelCap;
				fuelCons += detail.fuelCons;
			}

			m_mass.Value = mass;
			m_speed.Value = speed;
			m_fuelCap.Value = fuelCap;
			m_fuelCons.Value = fuelCons;
		}

		private void Awake()
		{
			m_mass.Max = m_max;
			m_speed.Max = m_max;
			m_fuelCap.Max = m_max;
			m_fuelCons.Max = m_max;
		}
	}
}
	