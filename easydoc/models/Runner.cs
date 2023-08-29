namespace EasyDoc;

public class Runner {
    public Runner() {

    }

    public void Run() {
        var goOn = true;
        var config = new Config("config.json");
        CLInteractor.DrawLine("#".ToArray()[0], 30, true, 10);
        CLInteractor.WriteLine("Welcome to EasyDocs!");
        CLInteractor.DrawLine("#".ToArray()[0], 30, true, 10);
        while (goOn) {
            var input = CLInteractor.GetInput("(EasyDoc)#");
        }
    }
}
