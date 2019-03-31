namespace TimeSheet

open Npgsql.FSharp

module BaseRepository =

    let FindAll query mapRowFunc =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.executeTable
        |> Sql.mapEachRow mapRowFunc

    let FindBy query mapRowFunc parameters =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.parameters parameters
        |> Sql.executeTable
        |> Sql.mapEachRow mapRowFunc

    let Save query parameters =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.parameters parameters
        |> Sql.executeNonQuery

    let Delete query parameters =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.parameters parameters
        |> Sql.executeNonQuery