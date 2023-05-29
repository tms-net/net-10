using System;

namespace CSVSerializer
{
	public static class FileManager
	{
		public static string SaveString(string fileName, string dataToSave)
		{
			fileName += ".csv";
			string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + Path.DirectorySeparatorChar + fileName;

            File.WriteAllText(path, dataToSave);

			return path;
        }

		public static string ReadFile(string path)
		{
			string fileData = File.ReadAllText(path);

			return fileData;
		}
    }
}

