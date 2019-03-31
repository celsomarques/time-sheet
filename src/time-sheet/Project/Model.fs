namespace TimeSheet.Project

open System
open Npgsql.FSharp
open TimeSheet

type Model =

    struct
        val mutable Id: Guid
        val mutable Name: string
        val mutable Description: string

        new(id: Guid, name: string, description: string) = {Id = id; Name = name; Description = description;}
    end


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