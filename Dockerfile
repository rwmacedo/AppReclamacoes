# Use uma imagem base do .NET SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos de projeto corretos
COPY ./AppReclamacoes.API/AppReclamacoes.API/AppReclamacoes.API.API.csproj ./AppReclamacoes.API.API/AppReclamacoes.API.API/
COPY ./AppReclamacoes.Application/AppReclamacoes.Application/AppReclamacoes.Application.csproj ./AppReclamacoes.Application/AppReclamacoes.Application/
COPY ./AppReclamacoes.Domain/AppReclamacoes.Domain/AppReclamacoes.Domain.csproj ./AppReclamacoes.Domain/AppReclamacoes.Domain/
COPY ./AppReclamacoes.Infra.Data/AppReclamacoes.Infra.Data/AppReclamacoes.Infra.Data.csproj ./AppReclamacoes.Infra.Data/AppReclamacoes.Infra.Data/
COPY ./AppReclamacoes.Infra.IoC/AppReclamacoes.Infra.IoC/AppReclamacoes.Infra.IoC.csproj ./AppReclamacoes.Infra.IoC/AppReclamacoes.Infra.IoC/


# Restaure as dependências
RUN dotnet restore ./AppReclamacoes.API/AppReclamacoes.API/AppReclamacoes.API.csproj

# Copie o restante dos arquivos de código
COPY . .

# Compile e publique o aplicativo
RUN dotnet publish ./AppReclamacoes.API/AppReclamacoes.API/AppReclamacoes.API.csproj -c Release -o /out

# Use uma imagem base mais leve para o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /out .

ENV ASPNETCORE_URLS=http://*:$PORT

# Exponha a porta 80
EXPOSE 80

# Comando de entrada para rodar o aplicativo
ENTRYPOINT ["dotnet", "AppReclamacoes.API.dll"]
#CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ProgramaOficios.API.dll
