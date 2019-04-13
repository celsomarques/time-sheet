namespace TimeSheet

open TimeSheet
open Microsoft.EntityFrameworkCore

type CustomerContext() =
    inherit BaseContext()

    [<DefaultValue>]
    val mutable customer: DbSet<Customer>
    member this.Customer
        with get() = this.customer
        and set(value) = this.customer <- value
