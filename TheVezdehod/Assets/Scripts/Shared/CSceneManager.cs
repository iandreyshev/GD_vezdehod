using UnityEngine.SceneManagement;

public class CSceneController
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
