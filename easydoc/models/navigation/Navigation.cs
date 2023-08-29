namespace EasyDoc;

public class Navigation {
	public static Way MapToWay(string tInput) {
		switch (tInput.ToLower()) {
			case "quit":
				return Way.quit;
			case "doc":
				return Way.doc;
			case "settings":
				return Way.settings;
			case "help":
				return Way.help;
			default:
				return Way.unkown;
		}
	}

	public static bool Go(Way way) {
		switch (way) {
			case Way.quit:
				return false;
			case Way.unkown:
				CLInteractor.WriteLine("Unkown command");
				break;
		}
		return true;
	}

}
