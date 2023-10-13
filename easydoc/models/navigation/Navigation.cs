namespace EasyDoc;

using System.Runtime.InteropServices;

public class Navigation {
	public static Way MapToWay(string tInput) {
		switch (tInput.ToLower().Split(" ")[0]) {
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

	private static void ShowHelp(Config config) {
		var animation = config.Animation;
		var sleeptTime = 0;
		if (animation) {
			sleeptTime = 10;
		}
		CLInteractor.Clear();
		CLInteractor.WriteAnimatedLine("Help page", sleeptTime);
		CLInteractor.DrawLine("-".ToCharArray()[0], 9, animation, sleeptTime);
		CLInteractor.WriteAnimatedLine("help				Shows the help page.", sleeptTime);
		CLInteractor.WriteAnimatedLine("quit				Quits the application.", sleeptTime);
		CLInteractor.WriteLine("");
		CLInteractor.WriteAnimatedLine("settings			Shows the current settings.", sleeptTime);
		CLInteractor.WriteAnimatedLine("settings help			Shwos the help page for settings.", sleeptTime);
		CLInteractor.WriteLine("");
		CLInteractor.WriteAnimatedLine("docs help			Shows the help page for docs.", sleeptTime);
		CLInteractor.WriteLine("");
		CLInteractor.WriteLine("");
	}

	public static bool Go(Way way, Config config, string tInput) {
		switch (way) {
			case Way.quit:
				return false;
			case Way.help:
				ShowHelp(config);
				break;
			case Way.doc:
				if (config.Files != null) {
					var docF = new Docs(config, tInput, config.Files);
					docF.navigate();
					break;
				}
				var doc = new Docs(config, tInput);
				doc.navigate();

				break;
			case Way.unkown:
				CLInteractor.WriteLine("Unkown command");
				break;
		}
		return true;
	}

}
