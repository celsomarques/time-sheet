namespace TimeSheet.Project

open System
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
type ProjectsController() =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        Repository.findAll()

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) =
        Repository.findById(id)

    [<HttpPost>]
    member this.Post([<FromBody>] value: string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id: int, [<FromBody>] value: string) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id: int) =
        ()
