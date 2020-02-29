FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY src/Mailbox.Cleaner.Web/Mailbox.Cleaner.Web.csproj src/Mailbox.Cleaner.Web/
COPY src/Mailbox.Cleaner.Domain/Mailbox.Cleaner.Domain.csproj src/Mailbox.Cleaner.Domain/
RUN dotnet restore "src/Mailbox.Cleaner.Web/Mailbox.Cleaner.Web.csproj"
COPY . .
WORKDIR "/src/src/Mailbox.Cleaner.Web"
RUN dotnet build "Mailbox.Cleaner.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mailbox.Cleaner.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mailbox.Cleaner.Web.dll"]
