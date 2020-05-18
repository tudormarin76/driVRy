using System.Collections.Generic;
using UnityEngine;

public static class ItemSaveIO
{
	private static readonly string baseSavePath;

	static ItemSaveIO()
	{
		baseSavePath = Application.persistentDataPath;
	}

	public static void SaveItems(List<MyConfiguration> item, string path)
	{
		FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", item);
	}

	public static List<MyConfiguration> LoadItems(string path)
	{
		string filePath = baseSavePath + "/" + path + ".dat";

		if (System.IO.File.Exists(filePath))
		{
			return FileReadWrite.ReadFromBinaryFile<List<MyConfiguration>>(filePath);
		}
		return null;
	}
}
