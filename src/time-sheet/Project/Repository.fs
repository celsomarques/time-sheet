namespace TimeSheet

open System
open System.Threading.Tasks
open Microsoft.EntityFrameworkCore

module ProjectRepository =

    let context = new ProjectContext()

    let Search() =
        let query = query {
            for project in context.Project do
            select project
        }
        query.AsNoTracking().ToListAsync()

    let FindById(id: Guid) =
        context.Project.FindAsync(id)

    let Upsert(project: Project) =
        context.Project.Upsert(project).RunAsync()

    let Delete(id: Guid) =
        async {
            let! project = FindById(id) |> Async.AwaitTask
            context.Project.Remove(project) |> ignore
            return context.SaveChanges()
        }
