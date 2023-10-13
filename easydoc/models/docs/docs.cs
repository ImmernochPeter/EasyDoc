namespace EasyDoc;

public class Docs {

	private const string helpText = "";
	private readonly Config config;
	public List<InFile> Files { get; set; }
	public List<string> Command { get; set; }

	public Docs(Config tConfig, string tCommand, List<InFile> tFiles) {
		this.Files = tFiles;
		this.config = tConfig;
		this.Command = tCommand.Split(" ").ToList();
	}
	public Docs(Config tConfig, string tCommand) {
		this.config = tConfig;
		this.Files = new List<InFile> { };
		this.Command = tCommand.Split(" ").ToList();
	}

	public void appendFiles(InFile tFile) {
		this.Files.Add(tFile);
	}

	public void appendFiles(List<InFile> tFiles) {
		foreach (var item in tFiles) {
			this.Files.Add(item);
		}
	}

	private void show_all_files() {
		CLInteractor.Clear();
		CLInteractor.WriteAnimatedLine("Currently staged files:", this.config.AnimationTime);
		CLInteractor.DrawLine("-".ToCharArray()[0], 30, true, this.config.AnimationTime);
		foreach (var item in this.Files) {
			CLInteractor.WriteAnimatedLine(item.path, this.config.AnimationTime);
		}
	}

	public void navigate() {
		if (this.Command.Count == 2 && this.Command[1] == "files") {
			this.show_all_files();
		}
	}

}
