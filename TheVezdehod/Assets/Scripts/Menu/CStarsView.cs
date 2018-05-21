using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
	public class CStarsView : MonoBehaviour
	{
		private readonly Color ENABLED = Color.white;
		private readonly Color DISABLED = new Color(1, 1, 1, 0.25f);

		private Image[] m_stars;

		public void SetStars(int count)
		{
			foreach (Image star in m_stars)
			{
				star.color = (count > 0) ? ENABLED : DISABLED;
				--count;
			}
		}

		private void Awake()
		{
			m_stars = GetComponentsInChildren<Image>();
		}
	}
}
