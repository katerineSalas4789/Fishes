FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /app

# copy sln and csproj files into the image
COPY *.sln .
COPY MainSolution/*.csproj ./MainSolution/
COPY AlgorithmsTests/*.csproj ./AlgorithmsTests/

# restore package dependencies for the solution
RUN dotnet restore

# copy full solution over
COPY . .
RUN dotnet build

# run the component tests
FROM build AS testrunner
WORKDIR /app/AlgorithmsTests
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
# set the directory to be within the unit test project
WORKDIR /app/AlgorithmsTests/
# run the unit tests
RUN dotnet test --logger:trx