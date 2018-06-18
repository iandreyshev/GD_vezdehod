using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CViewScript : MonoBehaviour
{
	[SerializeField]
	private Camera m_camera;

	private bool m_isLeft = false;
	private bool m_isRight = false;

	public void Left(bool isLeft)
	{
		m_isLeft = isLeft;
	}

	public void Right(bool isRight)
	{
		m_isRight = isRight;
	}

	private void FixedUpdate()
	{
		if (m_isLeft)
		{
			m_camera.transform.Translate(new Vector3(-0.7f, 0));
		}
		else if (m_isRight)
		{
			m_camera.transform.Translate(new Vector3(0.7f, 0));
		}
	}
}
