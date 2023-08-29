namespace EasyDoc;

using NUnit.Framework;

public class CLInteractorTest {
	[SetUp]
	public void Setup() {

	}

	[Test]
	public void GetInput_WhenInputProvided_ShouldReturnInput() {
		var input = "TestInput";
		var stringReader = new StringReader(input);
		Console.SetIn(stringReader);

		var result = CLInteractor.GetInput("Prompt:");

		Assert.That(input, Is.EqualTo(result));
	}

	[Test]
	public void GetInput_WhenNoInputProvided_ShouldReturnEmptyString() {
		var stringReader = new StringReader("");
		Console.SetIn(stringReader);

		var result = CLInteractor.GetInput("Prompt:");
		var expected = "";
		Assert.That(expected, Is.EqualTo(result));
	}


}

