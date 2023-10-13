namespace EasyDoc;

public enum FileTypes {
	py,
	cs
}

public class InFile {
	public readonly string path;
	private readonly FileTypes fileType;

	public InFile(string t_path) {
		this.path = t_path;
	}

}
