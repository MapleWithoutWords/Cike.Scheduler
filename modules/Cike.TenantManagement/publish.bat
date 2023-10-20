dotnet build -c Release
dotnet pack ./src/Cike.TenantManagement.Domain.Shared/Cike.TenantManagement.Domain.Shared.csproj -c Release -o ../../packages/Cike.TenantManagement.Domain.Shared
dotnet pack ./src/Cike.TenantManagement.Domain/Cike.TenantManagement.Domain.csproj -c Release -o ../../packages/Cike.TenantManagement.Domain
dotnet pack ./src/Cike.TenantManagement.EntityFrameworkCore/Cike.TenantManagement.EntityFrameworkCore.csproj -c Release -o ../../packages/Cike.TenantManagement.EntityFrameworkCore

dotnet pack ./src/Cike.TenantManagement.Application.Contracts/Cike.TenantManagement.Application.Contracts.csproj -c Release -o ../../packages/Cike.TenantManagement.Application.Contracts
dotnet pack ./src/Cike.TenantManagement.Application/Cike.TenantManagement.Application.csproj -c Release -o ../../packages/Cike.TenantManagement.Application
dotnet pack ./src/Cike.TenantManagement.HttpApi.Client/Cike.TenantManagement.HttpApi.Client.csproj -c Release -o ../../packages/Cike.TenantManagement.HttpApi.Client
