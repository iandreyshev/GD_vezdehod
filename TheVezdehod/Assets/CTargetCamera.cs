using UnityEngine;

public class CTargetCamera : MonoBehaviour
{
	[SerializeField]
	private Transform m_targer;
	private Vector3 m_offset;

	private void Start()
	{
		m_offset = transform.position - m_targer.position;
	}

	private void LateUpdate()
	{
		transform.position = m_targer.position + m_offset;
	}
}
