using System;
using System.IO;
using NUnit.Framework;

namespace EasyDoc;

public class MdBuilder {
	private const string newLine = "\n";
	private const string line = "---";
	private const string contentHead = "Content";
	private const string classHead = "Classes";
	private const string functionHead = "Functions";
	private const string topFolder = "documentation";
	private const string srcFolder = topFolder + "/src";
	private const string classFoler = srcFolder + "/classes";
	private const string functionFolder = srcFolder + "/functions";
	private const string topFile = topFolder + "/docs.md";
	private const string classFile = classFoler + "/class.md";
	private const string funcFile = functionFolder + "/func.md";

	public Config Configuration { get; set; }

	private void setFolders() {
		try {
			Directory.CreateDirectory(topFolder);
			Directory.CreateDirectory(srcFolder);
			Directory.CreateDirectory(classFoler);
			Directory.CreateDirectory(functionFolder);
		} catch (System.Exception ex) {
			CLInteractor.Clear();
			CLInteractor.WriteAnimatedLine(ex.Message, this.Configuration.AnimationTime);
		}
	}

	private string asMdHeader(string tMessage, int tLevel) {
		var prefix = "";
		for (var i = 0; i < tLevel; i++) {
			prefix += "#";
		}
		return prefix + " " + tMessage;
	}
	private void setTopFile() {
		var topHead = this.asMdHeader(this.Configuration.ProjectTitle, 1);
		File.WriteAllText(topFile, topHead);
		File.AppendAllText(topFile, newLine);
	}

	private string asLink(string tMessage, string tPath) {
		return "- [" + tMessage + "](" + tPath + ")";
	}

	private void setTopFileContent() {
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, "Developer documentation for " + this.Configuration.ProjectTitle + ".");
		var head = this.asMdHeader(contentHead, 2);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, head);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, this.asLink(classHead, classFile));
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, this.asLink(functionHead, funcFile));
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, line);
		File.AppendAllText(topFile, newLine);
		File.AppendAllText(topFile, line);
		File.AppendAllText(topFile, newLine);
	}

	private void setClassFile() {
		File.WriteAllText(classFile, classHead);
		File.AppendAllText(classFile, newLine);
	}

	private void setFuncFile() {
		File.WriteAllText(funcFile, functionHead);
		File.AppendAllText(funcFile, newLine);
	}

	public void build() {
		this.setFolders();
		this.setTopFile();
		this.setClassFile();
		this.setFuncFile();
		this.setTopFileContent();
		if (this.Configuration.Files != null) {
			Console.WriteLine("Classes:");
			var cfinder = new ClassFinder(this.Configuration.Files);
			var classes = cfinder.GetAllClasses();
			foreach (var item in classes) {
				Console.WriteLine(item.Item1);
			}

		}
	}

	public MdBuilder(Config tConfig) {
		this.Configuration = tConfig;
	}


}
