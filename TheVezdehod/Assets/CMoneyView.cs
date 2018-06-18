using UnityEngine;
using UnityEngine.UI;

public class CMoneyView : MonoBehaviour
{
	private Text m_field;
	private static int m_value = 0;

	void Awake()
	{
		m_field = GetComponent<Text>();
	}

	private void FixedUpdate()
	{
		m_field.text = m_value.ToString();
	}

	void Set(int value)
	{
		m_value = value;
	}

	void Increment()
	{
		++m_value;
	}

	public static void IncrementValue()
	{
		++m_value;
	}
}
