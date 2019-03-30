namespace TimeSheet.Project

open System
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
type ProjectsController() =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        Repository.FindAll()

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) =
        Repository.FindById(id)

    [<HttpPost>]
    member this.Post([<FromBody>] project: Model) =
        Repository.Save(Guid.NewGuid(), project)

    [<HttpPut("{id}")>]
    member this.Put(id: Guid, [<FromBody>] project: Model) =
        Repository.Save(id, project)

    [<HttpDelete("{id}")>]
    member this.Delete(id: Guid) =
        Repository.Delete(id)
