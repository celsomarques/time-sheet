namespace TimeSheet.Project

open System
open System.Linq
open TimeSheet

module ProjectRepository =

    let context = new ProjectContext()

    let FindAll() =
        context.Project.ToList()

    let FindById(id: Guid) =
        context.Project.FindAsync(id) |> Async.AwaitTask

(*
    let Save(id: Guid, model: Model) =
        [
            "id", Sql.Value id
            "name", Sql.Value model.Name
            "description", Sql.Value model.Description
        ]
        |> BaseRepository.Save UPSERT_QUERY

    let Delete(id: Guid) =
        BaseRepository.Delete DELETE_QUERY id

        *)