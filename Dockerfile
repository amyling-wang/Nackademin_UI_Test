FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR NackademinUITest
COPY . .
RUN dotnet restore
RUN dotnet build
CMD dotnet test