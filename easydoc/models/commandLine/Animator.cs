namespace EasyDoc;

using System.Threading;

public static class Animator {

	public static void DrawLine(int tLineLen, char tLine, int tSleepTime = 0) {
		for (var i = 0; i < tLineLen; i++) {
			System.Console.Write(tLine);
			Thread.Sleep(tSleepTime);
		}
		System.Console.WriteLine();
	}

	public static void AnimateLine(string tText, int tSleepTime = 0) {
		foreach (var item in tText.ToCharArray()) {
			System.Console.Write(item);
			Thread.Sleep(tSleepTime);
		}
		System.Console.WriteLine();
	}

}
