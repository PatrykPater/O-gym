FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["O-gym/O-gym.csproj", "O-gym/"]
COPY ["O-gym.Application/O-gym.Application.csproj", "O-gym.Application/"]
COPY ["O-gym.Domain/O-gym.Domain.csproj", "O-gym.Domain/"]
COPY ["O-gym.Infrastructure/O-gym.Infrastructure.csproj", "O-gym.Infrastructure/"]
COPY ["O-gym.Shared/O-gym.Shared.csproj", "O-gym.Shared/"]
COPY ["O-gym.Shared.Abstractions/O-gym.Shared.Abstractions.csproj", "O-gym.Shared.Abstractions/"]
COPY ["O-gym.Tests.Common/O-gym.Tests.Common.csproj", "O-gym.Tests.Common/"]
COPY ["O-gym.Domain.Tests/O-gym.Domain.Tests.csproj", "O-gym.Domain.Tests/"]
COPY ["O-gym.Application.Tests/O-gym.Application.Tests.csproj", "O-gym.Application.Tests/"]

RUN dotnet restore "O-gym/O-gym.csproj"
COPY . .

WORKDIR "/src/O-gym"
RUN dotnet build "O-gym.csproj" -c Release -o /app/build

FROM build AS test
LABEL test=true

WORKDIR "/src/O-gym.Tests.Common"
RUN dotnet test -c Release

WORKDIR "/src/O-gym.Domain.Tests"
RUN dotnet test -c Release

WORKDIR "/src/O-gym.Application.Tests"
RUN dotnet test -c Release

FROM build AS publish
RUN dotnet publish "O-gym.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O-gym.dll"]