using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFinishCollider : MonoBehaviour
{
	[SerializeField]
	private CGame m_game;

	private void OnTriggerEnter2D(Collider2D other)
	{
		m_game.FinishGame();
	}
}
