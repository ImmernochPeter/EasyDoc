namespace EasyDoc;
using System;

public static class CLInteractor {
    public static string GetInput(string tPromt) {
        System.Console.Write(tPromt + " ");
        var input = System.Console.ReadLine();
        if (input == null) {
            return "";
        }
        return input;
    }

    public static void Clear() {
        System.Console.Clear();
    }

    public static void WriteLine(string tMessage) {
        System.Console.WriteLine(tMessage);
    }

    public static void WriteAnimatedLine(string tMessage, int tSleepTime) {
        Animator.AnimateLine(tMessage, tSleepTime);
    }

    public static void DrawLine(char tLine, int tLen, bool tAnimate, int tSleepTime) {
        if (tAnimate) {
            Animator.DrawLine(tLen, tLine, tSleepTime);
            return;
        }
        Animator.DrawLine(tLen, tLine);
    }
}

