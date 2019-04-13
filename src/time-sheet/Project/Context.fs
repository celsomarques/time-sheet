namespace TimeSheet

open TimeSheet
open Microsoft.EntityFrameworkCore

type ProjectContext() =
    inherit BaseContext()

    [<DefaultValue>]
    val mutable project: DbSet<Project>
    member this.Project
        with get() = this.project
        and set(value) = this.project <- value
