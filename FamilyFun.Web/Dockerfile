FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["FamilyFun.Web/FamilyFun.Web.csproj", "FamilyFun.Web/"]
COPY ["FamilyFun.Persistance/FamilyFun.Persistence.csproj", "FamilyFun.Persistance/"]
COPY ["FamilyFun.Helpers/FamilyFun.Helpers.csproj", "FamilyFun.Helpers/"]
RUN dotnet restore "FamilyFun.Web/FamilyFun.Web.csproj"
COPY . .
WORKDIR "/src/FamilyFun.Web"
RUN dotnet build "FamilyFun.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyFun.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamilyFun.Web.dll"]