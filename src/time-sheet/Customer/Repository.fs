namespace TimeSheet

open System
open System.Threading.Tasks
open Microsoft.EntityFrameworkCore

module CustomerRepository =

    let context = new CustomerContext()

    let Search() =
        let query = query {
            for customer in context.Customer do
            select customer
        }
        query.AsNoTracking().ToListAsync()

    let FindById(id: Guid) =
        context.Customer.FindAsync(id)

    let Upsert(customer: Customer) =
        context.Customer.Upsert(customer).RunAsync()

    let Delete(id: Guid) =
        async {
            let! customer = FindById(id) |> Async.AwaitTask
            context.Customer.Remove(customer) |> ignore
            return context.SaveChanges()
        }
