# Quick Start Guide

This is an exercise to develop a simple poker scoring application using functional techniques in c#.

Not 100% of all code is purely functional, but it's as close as makes sense for me for what's available in the language.

All primitives are record or record-style classes that have init and read only properties. In a team, this can help keep code functional for longer.

The [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) is for an immutable base class with control over deep equality. Unfortunately records don't allow overwriting the equality operator for handling nested classes (like a nested List or HashSet in this example).

This is a modification of the principles presented in [this](https://edcharbeneau.com/csharp-functional-workshop-instructions/#chapter0) walk-though.

# Prerequisites

1. Install [dotnet core](https://dotnet.microsoft.com/download/dotnet-core) cli
2. Restore packages `dotnet restore`

# Running the Project

Run project normally with `dotnet run`

## Run Tests

Run all tests with `dotnet test`
