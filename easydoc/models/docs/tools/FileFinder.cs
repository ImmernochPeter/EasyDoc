namespace EasyDoc;

public static class FileFinder {

	public static List<InFile> getFiles(string tDir) {
		var inFileList = new List<InFile>();
		var filePaths = Directory.GetFiles(tDir, "*.py", SearchOption.AllDirectories);
		foreach (var filePath in filePaths) {
			var inFile = new InFile(filePath);
			inFileList.Add(inFile);
		}
		return inFileList;
	}

}
