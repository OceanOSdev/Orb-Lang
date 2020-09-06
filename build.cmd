@echo off

dotnet build .\src\orb.sln
dotnet test .\src\Orb.Tests\Orb.Tests.csproj