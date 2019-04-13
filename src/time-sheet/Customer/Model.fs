namespace TimeSheet

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<Table("customers")>]
type Customer(id0: Guid, name0: string) =

    let mutable id: Guid = id0
    let mutable name: string = name0

    new() = Customer(Guid.Empty, "")

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