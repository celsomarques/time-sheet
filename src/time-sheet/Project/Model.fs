namespace TimeSheet.Project

open System
open Npgsql.FSharp
open TimeSheet

type Model(Id: Guid, Name: string, Description: string) =

    new() = Model(Id = Guid.Empty, Name = "", Description = "")

    member this.Id = Id
    member this.Name = Name
    member this.Description = Description

    static member mapRow row = 
        match row with
        |
            [
                "id", SqlValue.Uuid id
                "name", SqlValue.String name
                "description", SqlValue.String description
            ] ->
            Some (Model(Id = id, Name = name, Description = description))

        | _ -> None


    override this.ToString() =
        sprintf "{ id: %s, name: %s, description: %s }" (Id.ToString()) Name Description