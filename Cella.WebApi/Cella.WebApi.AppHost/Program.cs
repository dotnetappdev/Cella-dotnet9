var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Cella_WebApi_ApiService>("apiservice");

builder.AddProject<Projects.Cella_WebApi_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
