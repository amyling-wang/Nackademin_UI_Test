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
WORKDIR /NackademinUITests

# Install Chrome and ChromeDriver
ENV CHROME_VERSION="114.0.5735.45"
ENV CHROME_DRIVER_VERSION="114.0.5735.90"
RUN apt-get update && apt-get install -y wget gnupg curl unzip
RUN wget -q -O /tmp/chromedriver.zip "https://chromedriver.storage.googleapis.com/$CHROME_DRIVER_VERSION/chromedriver_linux64.zip" && \
    unzip /tmp/chromedriver.zip -d /usr/bin && \
    chmod +x /usr/bin/chromedriver

# Install Chrome from the specific URL
RUN wget https://example.com/path/to/google-chrome-stable_$CHROME_VERSION_amd64.deb -O /tmp/google-chrome-stable.deb && \
    dpkg -i /tmp/google-chrome-stable.deb || apt-get -f install -y

# Copy all project files and the script to the working directory
COPY . .

# Restore and build the project
RUN dotnet restore
RUN dotnet build

# Copy the test script and make it executable
COPY run_tests.sh /NackademinUITests/run_tests.sh
RUN chmod +x /NackademinUITests/run_tests.sh

# Execute the test script
CMD ["/NackademinUITests/run_tests.sh"]

