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
    member this.Get(id: Guid) =
        async {
            let! result = ProjectRepository.FindById(id)

            let hasValue = not (box result = null)
            match hasValue with
            | false -> return ContentResult(StatusCode = Nullable(404))
            | true -> return ContentResult(Content = JsonConvert.SerializeObject(result))
        }

    [<HttpPost>]
    member this.Post([<FromBody>] project: Project) =
        () //Repository.Save(Guid.NewGuid(), project)

    [<HttpPut("{id}")>]
    member this.Put(id: Guid, [<FromBody>] project: Project) =
        () //Repository.Save(id, project)

    [<HttpDelete("{id}")>]
    member this.Delete(id: Guid) =
        () //Repository.Delete(id)