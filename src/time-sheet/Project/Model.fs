namespace TimeSheet.Project

open System
open Npgsql.FSharp
open TimeSheet

type Model(Id0: Guid, Name0: string, Description0: string) =

    let mutable id: Guid = Id0
    let mutable name: string = Name0
    let mutable description: string = Description0

    new() = Model(Guid.Empty, "", "")

    member this.Id with get() = id and set(value) = id <- value
    member this.Name with get() = name and set(value) = name <- value
    member this.Description with get() = description and set(value) = description <- value

    static member mapRow row = 
        match row with
        |
            [
                "id", SqlValue.Uuid id
                "name", SqlValue.String name
                "description", SqlValue.String description
            ] ->
            Some (Model(id, name, description))

        | _ -> None


    override this.ToString() =
        sprintf "{ id: %s, name: %s, description: %s }" (this.Id.ToString()) this.Name this.Description