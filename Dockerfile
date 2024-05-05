FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR NackademinUITest
COPY . .
RUN apt-get update && apt-get install -y wget
RUN wget -q https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
RUN apt-get install -y ./google-chrome-stable_current_amd64.deb
RUN dotnet restore
RUN dotnet build
CMD chromedriver --whitelisted-ips="" && dotnet test