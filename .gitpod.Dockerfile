FROM gitpod/workspace-dotnet

USER gitpod

RUN curl https://cli-assets.heroku.com/install.sh | sh
RUN curl https://get.docker.com/ | sh
RUN npm install -g --silent @angular/cli
RUN dotnet tool install --global dotnet-ef

