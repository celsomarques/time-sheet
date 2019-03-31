namespace TimeSheet

open System
open Npgsql.FSharp

module BaseRepository =

    let private Query query parameters =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.parameters parameters

    let FindAll query mapRowFunc =
        Query query []
        |> Sql.executeTable
        |> Sql.mapEachRow mapRowFunc

    let FindBy query mapRowFunc parameters =
        Query query parameters
        |> Sql.executeTable
        |> Sql.mapEachRow mapRowFunc

    let FindById query (id: Guid) mapRowFunc =
        [ "id", Sql.Value id ]
        |> FindBy query mapRowFunc
        |> List.tryHead

    let Save query parameters =
        Query query parameters
        |> Sql.executeNonQuery

    let Delete query (id: Guid) =
        [ "id", Sql.Value id ]
        |> Query query
        |> Sql.executeNonQuery