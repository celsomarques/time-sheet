namespace TimeSheet

open System
// open Npgsql.FSharp

module Postgres =

    let getConnection() =
        Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STR")
        //|> Sql.connect