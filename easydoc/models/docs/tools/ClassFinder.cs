using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace EasyDoc;

public class ClassFinder {

	public List<InFile> Files { get; set; }
	public ClassFinder(List<InFile> tFiles) {
		this.Files = tFiles;
	}

	private string[] GetFileContent(string filePath) {
		return File.ReadAllLines(filePath);
	}

	public List<Tuple<string, string>> GetAllClasses() {
		var classSections = new List<Tuple<string, string>>();


		foreach (var file in this.Files) {
			var lines = this.GetFileContent(file.path);
			var currentClass = new StringBuilder();
			var inClass = false;

			foreach (var line in lines) {
				if (line.Trim().StartsWith("class ")) {


					currentClass = new StringBuilder(line);
					inClass = true;
				} else if (line.StartsWith("\t") && inClass) {
					currentClass.AppendLine(line);

				} else if (inClass) {
					inClass = false;
					classSections.Add(Tuple.Create(currentClass.ToString(), file.path));

				}
			}
		}

		return classSections;
	}

}
