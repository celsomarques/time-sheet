namespace TimeSheet

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<Table("projects")>]
type Project(id0: Guid, name0: string, description0: string) =

    let mutable id: Guid = id0
    let mutable name: string = name0
    let mutable description: string = description0
    let mutable customerId: Guid = Guid.Empty

    new() = Project(Guid.Empty, "", "")

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

    [<Column("customer_id")>]
    member this.CustomerId
        with get() = customerId
        and set(v) = customerId <- v