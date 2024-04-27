using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BankAccount.Api.Extesions
{
    public static class BankAccountExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Account

            builder.Services.AddTransient<
                BankAccount.Core.UseCases.Shared.Contract.IRepository,
                BankAccount.Infra.Repositories.AccountRepository>();

            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
    {
        #region CreateAccount

        app.MapPost("api/v1/create-account", async (
            BankAccount.Core.UseCases.CreateAccount.Request request,
            IRequestHandler<
                BankAccount.Core.UseCases.CreateAccount.Request,
                BankAccount.Core.UseCases.CreateAccount.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return  Results.Json(result, statusCode: result.Status);
        });

        #endregion

        #region CreateTransaction

        app.MapPost("api/v1/create-transaction", async (
            BankAccount.Core.UseCases.CreateTransaction.Request request,
            IRequestHandler<
                BankAccount.Core.UseCases.CreateTransaction.Request,
                BankAccount.Core.UseCases.CreateTransaction.Response> handler) =>
        {
            Console.WriteLine($"Endpoint {request.Amount} - {request.Type} - {request.AccountId}");

            var result = await handler.Handle(request, new CancellationToken());
            return Results.Json(result, statusCode: result.Status);
        });

        #endregion
    }
    }
}