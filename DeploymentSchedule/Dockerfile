FROM microsoft/aspnet:4.7.1-windowsservercore-1709
ARG source
WORKDIR /inetpub/wwwroot
EXPOSE 32587
COPY ${source:-obj/Docker/publish} .
