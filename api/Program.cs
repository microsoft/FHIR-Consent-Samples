using System;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.AspNetCore;

namespace consent_api
{
    public class Program
    {
        private static string GetKeyVaultEndpoint() => "https://<YourKeyVaultName>.vault.azure.net";

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((ctx, builder) =>
              {
                  var keyVaultEndpoint = GetKeyVaultEndpoint();
                  if (!string.IsNullOrEmpty(keyVaultEndpoint))
                  {
                      builder.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential(), new KeyVaultSecretManager());
                  }
              }
           ).UseStartup<Startup>()
            .Build();
    }

}
