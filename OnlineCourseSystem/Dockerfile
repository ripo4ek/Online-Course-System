FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["OnlineCourseSystem/OnlineCourseSystem.csproj", "OnlineCourseSystem/"]
COPY ["OnlineCourseSystem.Domain/OnlineCourseSystem.Domain.csproj", "OnlineCourseSystem.Domain/"]
COPY ["OnlineCourseSystem.DAL/OnlineCourseSystem.DAL.csproj", "OnlineCourseSystem.DAL/"]
RUN dotnet restore "OnlineCourseSystem/OnlineCourseSystem.csproj"
COPY . .
WORKDIR "/src/OnlineCourseSystem"
RUN dotnet build "OnlineCourseSystem.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OnlineCourseSystem.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OnlineCourseSystem.dll"]