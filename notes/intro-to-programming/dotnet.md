### C# #
- naming conventions
	- PascalCase - assembly names, namespace, public things (classes, method, properties, etc.)
	- camelCase- private/internal fields, method parameters, local variables
- ==**do not** rename `Program.cs`==- code will not work
- to create an API, you must first create a builder using 
- if you have a function in curly brackets, you need a `return` keyword, but you don't need curly brackets if it is only doing one thing
### .NET
- the command `dotnet new list` will show all the available projects you can create from the CLI
- **to create a new project from the CLI**: `dotnet new console --name <project-name>` 
- timeline
	- before 2002- mostly used visual basic and C++; both powerful languages that required expertise
		- there was a lot you couldn't do with VB
		- 
	- 1995- Sun Microsystems creates Java; introduced object-oriented programming
		- at this point, VBScript as being used to make Active Server Pages
		- Scott Guthrie- created XSP (ASPX)
		- creating a new version of Windows had to be done slowly to avoid breaking anything; one solution to this was creating a fake OS on top of Win32 for developers to work on- this became known as the common language runtime (CLR), which is a program that has to be installed on the machine for your .NET application to run
	- eventually the simple object access protocol (SOAP) is created
	- 2002- .NET is created by Microsoft; XML web service 1.0 is launched
	- 
.NET support
- LTS (long term support) - existed for 3 years; even-numbered versions; currently on version 6.0 (in September 2023, 8 comes out)
- STS (standard term support)- existed for 18 months; odd-numbered versions
- testing
	- unit testing- testing individual components
	- integration testing- checking how the code works within the system (Does it break anything?)
	- to run test: using dotnet CLI- `dotnet test` | in Visual Studio- `Ctrl + R, A`
		- the first argument in an assert statement is what you expected the returned value to be, the second is the variable your are testing
	- you can also have one test with multiple inputs by defining parameters and Inline Data under a Theory tag
**example** 
```csharp
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(10, 5, 15)]
        [InlineData(2, 8, 10)]
        public void CanAddAnyTwoIntegers(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }
```

- in .NET we create "types"
	- there are only 2 "kinds" of types in .NET- 
		- references: live on the heap, created with classes and records 
		- values: live on a stack; includes numbers (int, single, double, float, etc.), DateTime, Struct
- when reference a file in another project in the same solution, you need to add a reference to the second project in project dependencies- Add `using <project_name>;` >> Go into Dependence of the project you're currently in >> Add project reference >> Select project
- when writing test that require certain objects/classes you can create a dummy class or ==mock class== 
```csharp
    public class DummyBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {
        public decimal CalculateBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    
```
- can also use a package to creates Mocks

- when creating a mock class, it creates an instance of an object in memory and methods will return a default value
- however, because the mock class returns a default value, you must specify what value you want returned in some cases (which is called ==stubbing==)
```csharp
// EXAMPLE
    public class DepositUseTheBonusCalculator
    {
        [Fact]
        public void BonusCalculatorIsUsedAndBonusAppliedToBalance()
        {
            // given
            var stubbedBonusCalculator = new Mock<ICanCalculateBonusesForBankAccountDeposits>();
            var account = new BankAccount(stubbedBonusCalculator.Object);

            var openingBalance = account.GetBalance();
            var amountToDeposit = 112.23M;
            var amountOfBonusToReturn = 69.23M;

            stubbedBonusCalculator.Setup(x => x.CalculateBonusForDeposit(openingBalance, amountToDeposit)).Returns(amountOfBonusToReturn);

            //when
            account.Deposit(amountToDeposit);

            //then
            Assert.Equal(openingBalance + amountOfBonusToReturn + amountToDeposit, account.GetBalance());

        }
    }

```
- 
#### creating an API
- use the ASP.NET core web API project in visual studio
- enable Swagger to generate documentation for the API
- *a `record` create a read-only class* 
- *.NET APIs are concurrent*- they can handle many simultaneous requests at the time
- the `Program.cs` folder in the API
```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//everything above this line is configuring "Services" in the application
var app = builder.Build();
/*
 this is configuring the moddleware- this code will
 see the incoming HTTP request and make a response
 */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //this is OpenAPI (Swagger)- it generates the API documentation in a JSON file
    app.UseSwaggerUI(); //adds middleware that lets you interact with the documentation
}

app.UseAuthorization();

app.MapControllers(); //during startup, the API looks through our controllers folder, reads those attributes, and creates a "route table"

app.Run(); //start teh Kestrel web server and listen for requests
```

making a controller
```csharp
    public class TodoListController : ControllerBase
    {
        [HttpGet("/todo-list")]
        public async Task<ActionResult> GetTodoList()
        {
            return Ok();
        }
    }
```
making a model
```csharp
    public enum TodoItemStatus { Later, Now, Waiting, Completed}
    public record TodoListItemResponseModel(Guid Id, string Description, TodoItemStatus Status);
```
