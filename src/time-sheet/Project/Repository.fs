namespace TimeSheet.Project

open System
open System.Linq
open Microsoft.EntityFrameworkCore

module ProjectRepository =

    let context = new ProjectContext()

    let FindAll() =
        context.Project.AsNoTracking().ToList()

    let FindById(id: Guid) =
        context.Project.FindAsync(id)

    let Upsert(project: Project) =
        context.Project.Upsert(project).RunAsync()

    let Delete(id: Guid) = async {
        let! project = FindById(id) |> Async.AwaitTask
        context.Project.Remove(project) |> ignore
        return context.SaveChangesAsync() |> Async.AwaitTask
    }
