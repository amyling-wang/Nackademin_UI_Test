#!/bin/bash
dotnet test NackademinUITest.csproj --filter "TestCategory=Smoke" -- TestRunParameters.Parameter\(name=\"browser\",value=\"Chrome\"\)
