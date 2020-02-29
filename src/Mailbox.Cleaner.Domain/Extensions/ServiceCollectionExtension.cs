﻿using System.Reflection;
using AutoMapper;
using FluentValidation;
using Mailbox.Cleaner.Domain.Data.Repository;
using Mailbox.Cleaner.Domain.Services;
using Mailbox.Cleaner.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Mailbox.Cleaner.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        private const string MongoSectionName = "Mongo";

        public static IServiceCollection AddMailboxCleaner(this IServiceCollection serviceCollection, IConfigurationSection configuration)
        {
            return serviceCollection
                .AddAutoMapper(Assembly.GetAssembly(typeof(ServiceCollectionExtension)))
                .AddValidatorsFromAssemblyContaining(typeof(ServiceCollectionExtension))
                .AddOptions()
                .Configure<MongoSettings>(configuration.GetSection(MongoSectionName))
                .AddSingleton(ConfigureMongoClient(configuration))
                .AddTransient<IEmailRepository, EmailRepository>()
                .AddTransient<IImportReportRepository, ImportReportRepository>()
                .AddTransient<IReportRepository, ReportRepository>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IReportService, ReportService>();
        }

        private static IMongoClient ConfigureMongoClient(IConfigurationSection configuration)
        {
            return new MongoClient(configuration.GetSection(MongoSectionName).GetValue<string>("ConnectionString"));
        }
    }
}
