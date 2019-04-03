namespace TimeSheet.Project

open System
open System.Linq
open Microsoft.EntityFrameworkCore

module ProjectRepository =

    let context = new ProjectContext()

    let FindAll() =
        context.Project.ToList()

    let FindById(id: Guid) =
        context.Project.FindAsync(id) |> Async.AwaitTask

    let Insert(project: Project) =
        context.Project.Add(project) |> ignore
        context.SaveChangesAsync() |> Async.AwaitTask

    let Update(project: Project) =
        context.Project.Update(project) |> ignore
        context.SaveChangesAsync() |> Async.AwaitTask

    let Delete(id: Guid) = async {
        let! project = FindById(id)
        context.Project.Remove(project) |> ignore
        return context.SaveChangesAsync() |> Async.AwaitTask
    }
