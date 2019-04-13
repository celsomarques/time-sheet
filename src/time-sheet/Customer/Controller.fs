namespace TimeSheet

open System
open Microsoft.AspNetCore.Mvc
open Newtonsoft.Json

[<Route("api/[controller]")>]
type CustomersController() =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        CustomerRepository.Search() |> Async.AwaitTask

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) = async {

        let! result = CustomerRepository.FindById(id) |> Async.AwaitTask

        let hasValue = not (isNull (box result))
        return
            match hasValue with
            | false -> ContentResult(StatusCode = Nullable(404))
            | true -> ContentResult(Content = JsonConvert.SerializeObject(result))
    }

    [<HttpPost>]
    member this.Post([<FromBody>] customer: Customer) =
        customer.Id <- Guid.NewGuid()
        CustomerRepository.Upsert(customer) |> Async.AwaitTask

    [<HttpPut("{id}")>]
    member this.Put(id: Guid, [<FromBody>] customer: Customer) =
        CustomerRepository.Upsert(customer) |> Async.AwaitTask

    [<HttpDelete("{id}")>]
    member this.Delete(id: Guid) =
        CustomerRepository.Delete(id)