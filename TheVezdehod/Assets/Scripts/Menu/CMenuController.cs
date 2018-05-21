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

		public void StartLevel(int levelNumber)
		{
			Debug.Log(levelNumber);
			CDataManager.SetLevel(levelNumber);
			CSceneSwitcher.Garage();
		}

		private void Start()
		{
			m_levelStars0.SetStars(CDataManager.GetLevelStars(0));
			m_levelStars1.SetStars(CDataManager.GetLevelStars(1));
		}
	}
}
