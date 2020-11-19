FROM gitpod/workspace-dotnet

USER gitpod

RUN npm install -g --silent @angular/cli
RUN dotnet tool install --global dotnet-ef
RUN curl https://cli-assets.heroku.com/install.sh | sh
