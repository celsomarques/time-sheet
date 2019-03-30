namespace TimeSheet.Project

open System
open Npgsql.FSharp
open TimeSheet

module Repository =

    let findAll() =
        Postgres.getConnection()
            |> Sql.query "SELECT id, name, description FROM projects"
            |> Sql.executeTable
            |> Sql.mapEachRow Model.mapRow

    let findById(id: Guid) =
        Postgres.getConnection()
            |> Sql.query "SELECT id, name, description FROM projects where id = @id"
            |> Sql.parameters [ "id", Sql.Value id ]
            |> Sql.executeTable
            |> Sql.mapEachRow Model.mapRow
            |> List.head