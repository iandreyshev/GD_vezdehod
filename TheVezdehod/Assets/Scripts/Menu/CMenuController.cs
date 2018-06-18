using Shared;
using UnityEngine;

namespace MenuScene
{
	public class CMenuController : MonoBehaviour
	{
		[SerializeField]
		private CStarsView m_levelStars0;
		[SerializeField]
		private CStarsView m_levelStars1;
		[SerializeField]
		private CGame m_game;

		public void StartLevel1()
		{
			m_game.Garage(Level._1);
		}

		public void StartLevel2()
		{
			m_game.Garage(Level._2);
		}

		private void Start()
		{
			m_levelStars0.SetStars(CDataManager.GetLevelStars(0));
			m_levelStars1.SetStars(CDataManager.GetLevelStars(1));
		}
	}
}
