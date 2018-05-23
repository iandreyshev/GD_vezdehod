using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CPropertyBar : MonoBehaviour
	{
		[SerializeField]
		private RectTransform m_line;
		[SerializeField]
		private RectTransform m_lineBackground;
		[SerializeField]
		private Color m_minColor = Color.green;
		[SerializeField]
		private Color m_maxColor = Color.red;

		private float m_max;
		private float m_value = 0;

		public float Max
		{
			get { return m_max; }
			set
			{
				m_max = value;
				Value = Value;
			}
		}
		public float Value
		{
			get { return m_value; }
			set
			{
				m_value = value;

				float part = Mathf.Clamp01(Value / Max);
				float newWidth = m_lineBackground.rect.size.x * part;
				m_line.sizeDelta = new Vector2(newWidth, m_line.sizeDelta.y);
				m_line.GetComponent<Image>().color = Color.Lerp(m_minColor, m_maxColor, part);
			}
		}
	}
}
