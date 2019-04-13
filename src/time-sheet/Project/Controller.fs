namespace TimeSheet.Project

open System
open Microsoft.AspNetCore.Mvc
open Newtonsoft.Json

[<Route("api/[controller]")>]
type ProjectsController() =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        ProjectRepository.Search() |> Async.AwaitTask

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) = async {

        let! result = ProjectRepository.FindById(id) |> Async.AwaitTask

        let hasValue = not (isNull (box result))
        return
            match hasValue with
            | false -> ContentResult(StatusCode = Nullable(404))
            | true -> ContentResult(Content = JsonConvert.SerializeObject(result))
    }

    [<HttpPost>]
    member this.Post([<FromBody>] project: Project) =
        project.Id <- Guid.NewGuid()
        ProjectRepository.Upsert(project) |> Async.AwaitTask

    [<HttpPut("{id}")>]
    member this.Put(id: Guid, [<FromBody>] project: Project) =
        ProjectRepository.Upsert(project) |> Async.AwaitTask

    [<HttpDelete("{id}")>]
    member this.Delete(id: Guid) =
        ProjectRepository.Delete(id)