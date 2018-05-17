using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CDataManager
{
	readonly static string PATH = Application.dataPath + "/Resources/Cars/car.txt";

	public static void Serialize(CCar car)
	{
		BinaryFormatter bFormatter = new BinaryFormatter();
		FileStream stream = new FileStream(PATH, FileMode.Create);

		bFormatter.Serialize(stream, car);
		stream.Close();
	}

	public static CCar Deserialize()
	{
		CCar car = null;
		BinaryFormatter bFormatter = new BinaryFormatter();
		FileStream stream = new FileStream(PATH, FileMode.Open);

		car = bFormatter.Deserialize(stream) as CCar;
		stream.Close();

		return car;
	}
}
