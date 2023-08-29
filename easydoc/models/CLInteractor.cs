namespace EasyDoc;
using System;

public static class CLInteractor {
    public static string GetInput(string promt) {
        System.Console.WriteLine(promt + " ");
        var input = System.Console.ReadLine();
        if (input == null) {
            return "";
        }
        return input;
    }
}

