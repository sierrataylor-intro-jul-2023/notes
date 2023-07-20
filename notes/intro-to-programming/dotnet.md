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