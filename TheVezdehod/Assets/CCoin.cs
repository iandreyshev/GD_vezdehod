using UnityEngine;

public class CCoin : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		CMoneyView.IncrementValue();
		Destroy(gameObject);
	}
}
