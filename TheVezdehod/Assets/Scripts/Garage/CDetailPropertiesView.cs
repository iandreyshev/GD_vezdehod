using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CDetailPropertiesView : MonoBehaviour
	{
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Image m_icon;
		[SerializeField]
		private CPropertyBar m_mass;
		[SerializeField]
		private CPropertyBar m_speed;
		[SerializeField]
		private CPropertyBar m_nitro;
		[SerializeField]
		private GameObject m_notSelectedWrap;

		[SerializeField]
		private float m_max = 20;

		public void Set(CDetail detail)
		{
			m_notSelectedWrap.SetActive(false);
			m_title.text = detail.title;
			m_icon.sprite = detail.sprite;
			m_mass.Value = detail.mass;
			m_speed.Value = detail.speed;
			m_nitro.Value = detail.fuelCap;
		}

		public void Close()
		{
			m_notSelectedWrap.SetActive(true);
		}

		private void Awake()
		{
			m_mass.Max = m_max;
			m_speed.Max = m_max;
			m_nitro.Max = m_max;

			Close();
		}
	}
}
