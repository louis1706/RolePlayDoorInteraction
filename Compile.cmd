@echo off
dotnet build -c Release --property:OutputPath=%~dp0Compile
pause