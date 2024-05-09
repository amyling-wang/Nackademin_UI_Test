FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /NackademinUITests

# Install dependencies
RUN apt-get update && apt-get install -y wget gnupg curl unzip libxcb1 libnss3 libglib2.0-bin
RUN wget -qO- https://aka.ms/install-artifacts-credprovider.sh | bash

# Install Chrome and ChromeDriver
ENV CHROME_VERSION="114.0.5735.45"
ENV CHROME_DRIVER_VERSION="114.0.5735.90"
RUN wget -q -O /tmp/chromedriver.zip "https://chromedriver.storage.googleapis.com/$CHROME_DRIVER_VERSION/chromedriver_linux64.zip" && \
    unzip /tmp/chromedriver.zip -d /usr/bin && \
    chmod +x /usr/bin/chromedriver

# Install Chrome from the specific URL
RUN wget https://example.com/path/to/google-chrome-stable_$CHROME_VERSION_amd64.deb -O /tmp/google-chrome-stable.deb && \
    dpkg -i /tmp/google-chrome-stable.deb || apt-get -f install -y

COPY . .

RUN dotnet restore
RUN dotnet build
CMD dotnet test **/*.csproj -- TestRunParameters.Parameter\(name=\"browser\",value=\"Chrome\"\)



