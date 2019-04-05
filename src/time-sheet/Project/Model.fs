namespace TimeSheet.Project

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<Table("projects")>]
type Project(Id0: Guid, Name0: string, Description0: string) =

    let mutable id: Guid = Id0
    let mutable name: string = Name0
    let mutable description: string = Description0

    new() = new Project(Guid.Empty, "", "")

    [<Key>]
    [<DatabaseGenerated(DatabaseGeneratedOption.None)>]
    [<Column("id")>]
    member this.Id
        with get() = id
        and set(v) = id <- v

    [<Column("name")>]
    member this.Name
        with get() = name
        and set(v) = name <- v

    [<Column("description")>]
    member this.Description
        with get() = description
        and set(v) = description <- v