using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Shared
{
	public class CDataManager
	{
		const string LEVEL_STARS_KEY = "LevelStars";

		const string LEVEL = "Level";
		const int DEFAULT_LEVEL = 0;

		readonly static string PATH = Application.dataPath + "/Resources/Cars/car.txt";

		public static void SetLevelStars(int level, int starsCount)
		{
			PlayerPrefs.SetInt(LEVEL_STARS_KEY + level.ToString(), starsCount);
		}

		public static int GetLevelStars(int level)
		{
			return PlayerPrefs.GetInt(LEVEL_STARS_KEY + level.ToString(), 0);
		}

		public static void SetLevel(int level)
		{
			PlayerPrefs.SetInt(LEVEL, level);
		}

		public static int GetLevel()
		{
			return PlayerPrefs.GetInt(LEVEL, DEFAULT_LEVEL);
		}

		public static void Serialize(CCar car)
		{
			BinaryFormatter bFormatter = new BinaryFormatter();
			FileStream stream = new FileStream(PATH, FileMode.Create);

			bFormatter.Serialize(stream, car);
			stream.Close();
		}

		public static CCar DeserializeCar()
		{
			CCar car = null;
			BinaryFormatter bFormatter = new BinaryFormatter();
			FileStream stream = new FileStream(PATH, FileMode.Open);

			car = bFormatter.Deserialize(stream) as CCar;
			stream.Close();

			return car;
		}
	}
}
