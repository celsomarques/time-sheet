using System;
using System.Collections;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Migrations
{
    public static class Runner
    {

        public static void Run()
        {
            var serviceProvider = CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices()
        {

            string CONNECTION_STR = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STR");

            return new ServiceCollection().
                AddFluentMigratorCore().
                ConfigureRunner(rb => rb.
                    AddPostgres().
                    WithGlobalConnectionString(CONNECTION_STR).
                    ScanIn(
                        typeof(CreateProjectTable).Assembly
                    ).For.Migrations()).
                AddLogging(lb => lb.AddFluentMigratorConsole()).
                BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            serviceProvider.
                GetRequiredService<IMigrationRunner>().
                MigrateUp();
        }
    }
}
