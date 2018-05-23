using UnityEngine;

namespace RoadScene
{
	public class CRoadCamera : MonoBehaviour
	{
		[SerializeField]
		private Transform m_carTransform;
		[SerializeField]
		private float m_xOffset = 0;
		[SerializeField]
		private float m_yOffset = 0;
		[SerializeField]
		private float m_rotationAmplitude = 15;

		void Update()
		{
			transform.position = new Vector3(
				m_carTransform.position.x + m_xOffset,
				m_carTransform.position.y + m_yOffset,
				-10);
		}
	}
}
