namespace TimeSheet.Project

open System
open Microsoft.AspNetCore.Mvc
open Newtonsoft.Json

[<Route("api/[controller]")>]
type ProjectsController() =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        ProjectRepository.FindAll()

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) = async {

        let! result = ProjectRepository.FindById(id) |> Async.AwaitTask

        let hasValue = not (box result = null)
        return
            match hasValue with
            | false -> ContentResult(StatusCode = Nullable(404))
            | true -> ContentResult(Content = JsonConvert.SerializeObject(result))
    }

    [<HttpPost>]
    member this.Post([<FromBody>] project: Project) = async {
        project.Id <- Guid.NewGuid()
        return! ProjectRepository.Upsert(project) |> Async.AwaitTask
    }

    [<HttpPut("{id}")>]
    member this.Put(id: Guid, [<FromBody>] project: Project) = async {
        return! ProjectRepository.Upsert(project) |> Async.AwaitTask
    }

    [<HttpDelete("{id}")>]
    member this.Delete(id: Guid) = async {
        return! ProjectRepository.Delete(id)
    }