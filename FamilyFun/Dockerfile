FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FamilyFun/FamilyFun.csproj", "FamilyFun/"]
RUN dotnet restore "FamilyFun/FamilyFun.csproj"
COPY . .
WORKDIR "/src/FamilyFun"
RUN dotnet build "FamilyFun.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FamilyFun.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FamilyFun.dll"]