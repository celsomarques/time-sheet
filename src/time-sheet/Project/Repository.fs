namespace TimeSheet.Project

open System
open Npgsql.FSharp
open TimeSheet

module Repository =

    let FIND_ALL_QUERY = "SELECT id, name, description FROM projects"

    let FIND_BY_ID = "SELECT id, name, description FROM projects where id = @id"

    let UPSERT_QUERY =
        [
            "INSERT INTO projects (id, name, description) values"
            "(@id, @name, @description) ON CONFLICT (id)"
            "DO UPDATE SET name = @name, description = @description"
        ]
        |> String.concat " "

    let DELETE_QUERY = "DELETE FROM projects WHERE id = @id"

    let private GetHead(rows: Model list): Model =
        match rows with
        | [] -> Model()
        | _ -> rows.Head

    let FindAll() =
        Postgres.getConnection()
            |> Sql.query FIND_ALL_QUERY
            |> Sql.executeTable
            |> Sql.mapEachRow Model.mapRow

    let FindById(id: Guid) =
        Postgres.getConnection()
            |> Sql.query FIND_BY_ID
            |> Sql.parameters [ "id", Sql.Value id ]
            |> Sql.executeTable
            |> Sql.mapEachRow Model.mapRow
            |> GetHead

    let Save(id: Guid, model: Model) =
        Postgres.getConnection()
            |> Sql.query UPSERT_QUERY
            |> Sql.parameters [
                "id", Sql.Value id
                "name", Sql.Value model.Name
                "description", Sql.Value model.Description
            ]
            |> Sql.executeNonQuery

    let Delete(id: Guid) =
        Postgres.getConnection()
            |> Sql.query DELETE_QUERY
            |> Sql.parameters [ "id", Sql.Value id ]
            |> Sql.executeNonQuery