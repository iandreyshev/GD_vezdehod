using UnityEngine.SceneManagement;

namespace Shared
{
	public class CSceneSwitcher
	{
		public static void Menu()
		{
			SceneManager.LoadScene("Scenes/MenuScene");
		}

		public static void Garage()
		{
			SceneManager.LoadScene("Scenes/GarageScene");
		}

		public static void Road()
		{
			SceneManager.LoadScene("Scenes/RoadScene");
		}
	}
}
