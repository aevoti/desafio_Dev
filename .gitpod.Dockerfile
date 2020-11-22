FROM gitpod/workspace-dotnet

USER gitpod

RUN curl https://cli-assets.heroku.com/install.sh | sh
RUN curl -sSL https://get.docker.com/rootless | sh
RUN npm install -g --silent @angular/cli
RUN dotnet tool install --global dotnet-ef

