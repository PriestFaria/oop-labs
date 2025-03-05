using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create table accounts
        (
            account_id bigint primary key,
            balance bigint not null
        );

        create table operations
        (
            operation_id bigint primary key generated always as identity,  
            account_id bigint not null references accounts(account_id),  
            amount double precision not null,
            operation_date timestamp default now()                         
        );
        
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table operations;
        drop table accounts;
        """;
}