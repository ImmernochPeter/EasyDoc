namespace EasyDoc;

using System;
using System.IO;
using System.Text.Json;

public class Config {

	public int AnimationTime { get; set; }
	public List<InFile>? Files { get; set; }
	public string Path { get; set; }
	public bool Animation { get; set; }
	public Language Language { get; set; }
	public DocLanguage DocLanguage { get; set; }
	public View View { get; set; }
	public string? CustomFooter { get; set; }


	private static Language MapToLanguage(string? tLanguage) {
		if (tLanguage == null) {
			return Language.english;
		}
		switch (tLanguage.ToLower()) {
			case "english":
				return Language.english;
			case "german":
				return Language.german;
			default:
				return Language.english;
		}
	}

	private static DocLanguage MapToDocLanguage(string? tDocLanguage) {
		if (tDocLanguage == null) {
			return DocLanguage.markdown;
		}
		switch (tDocLanguage.ToLower()) {
			case "markdown":
				return DocLanguage.markdown;
			default:
				return DocLanguage.markdown;
		}
	}

	private static View MapToView(string? tView) {
		if (tView == null) {
			return View.splitted;
		}
		switch (tView.ToLower()) {
			case "single":
				return View.single;
			case "splitted":
				return View.splitted;
			default:
				return View.splitted;
		}
	}

	private static InFile MapToInFile(string tPath) {
		return new InFile(tPath);
	}

	private List<string> MapToStringList(string tString) {
		return tString.Split(",").ToList();
	}

	private void ReadFromJson(string filePath) {
		try {
			var json = File.ReadAllText(filePath);
			var jsonDocument = JsonDocument.Parse(json);

			var root = jsonDocument.RootElement;

			this.Language = MapToLanguage(root.GetProperty("language").GetString());
			this.Animation = root.GetProperty("animation").GetBoolean();
			var docSettings = root.GetProperty("doc-settings");
			this.DocLanguage = MapToDocLanguage(docSettings.GetProperty("doc-language").GetString());
			this.View = MapToView(docSettings.GetProperty("view").GetString());
			this.CustomFooter = docSettings.TryGetProperty("custom-footer", out var customFooterElement) ? customFooterElement.GetString() : null;
			var files = root.GetProperty("files").GetString();
			if (files != null) {
				var fileString = this.MapToStringList(files);
				this.Files = new List<InFile> { };
				foreach (var item in fileString) {
					this.Files.Add(MapToInFile(item));
				}
			}

		} catch (Exception ex) {
			Console.WriteLine("Critical ERROR: " + ex.Message);
		}
	}

	public Config(string tPath) {
		this.Path = tPath;
		this.ReadFromJson(this.Path);
	}

}
