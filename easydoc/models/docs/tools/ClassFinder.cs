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
			var content = this.GetFileContent(file.path);
			var lines = content;
			var currentClass = new StringBuilder();
			var indentationLevel = 0;

			foreach (var line in lines) {
				if (line.Trim().StartsWith("class ") && indentationLevel == 0) {
					currentClass = new StringBuilder(line);
					indentationLevel = line.Length - line.TrimStart().Length;
				} else if (indentationLevel > 0) {
					currentClass.AppendLine(line);
					if (line.Length - line.TrimStart().Length <= indentationLevel) {
						classSections.Add(Tuple.Create(currentClass.ToString(), file.path));
						currentClass = new StringBuilder();
						indentationLevel = 0;
					}
				}
			}
		}

		return classSections;
	}

}
