#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
#WORKDIR NackademinUITest
#COPY . .
#RUN apt-get install -y wget
#RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \ 
 #   && echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list
#RUN apt-get update && apt-get -y install google-chrome-stable

##RUN apt-get update && apt-get install -y wget
##RUN wget -q https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
##RUN apt-get install -y ./google-chrome-stable_current_amd64.deb
#RUN dotnet restore
#RUN dotnet build
#CMD chromedriver --whitelisted-ips="" && dotnet test

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR NackademinUITest

ENV CHROME_VERSION="114"
ENV CHROME_DRIVER_VERSION="114"
#RUN apt-get update && apt-get install -y wget gnupg curl unzip
RUN CHROME_DRIVER_VERSION=$(curl -sS https://chromedriver.storage.googleapis.com/LATEST_RELEASE) && \
    wget -q -O /tmp/chromedriver.zip "https://chromedriver.storage.googleapis.com/$CHROME_DRIVER_VERSION/chromedriver_linux64.zip" && \
    unzip /tmp/chromedriver.zip -d /usr/bin && \
    chmod +x /usr/bin/chromedriver && \
    echo $CHROME_DRIVER_VERSION > /tmp/chromedriver_version.txt

RUN CHROME_VERSION=$(echo $CHROME_DRIVER_VERSION | cut -d'.' -f1) && \
    wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google-chrome.list && \
    apt-get update && \
    apt-get install -y google-chrome-stable=$CHROME_VERSION*

#RUN wget -q -O /tmp/chromedriver.zip "https://chromedriver.storage.googleapis.com/$CHROME_DRIVER_VERSION/chromedriver_linux64.zip" && \
   # unzip /tmp/chromedriver.zip -d /usr/bin && \
   # chmod +x /usr/bin/chromedriver

COPY . .
RUN dotnet restore

RUN dotnet build

CMD ["dotnet", "test"]

