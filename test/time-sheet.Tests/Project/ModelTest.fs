namespace TimeSheet

open System
open Xunit

open TimeSheet.Project

module ProjectModelTest =

    [<Fact>]
    let ``new Model(id, name, description)``() =

        let id = Guid.NewGuid()
        let name = "Name"
        let description = "Description"

        let model = Model(id, name, description)
        Assert.Equal(id, model.Id)
        Assert.Equal(name, model.Name)
        Assert.Equal(description, model.Description)

    [<Fact>]
    let ``new Model() and mutate field values``() =

        let mutable model = Model()
        model.Id <- Guid.NewGuid()
        model.Name <- "New Name"
        model.Description <- "New Description"

        Assert.NotEqual(Guid.Empty, model.Id)
        Assert.NotEmpty(model.Name)
        Assert.NotEmpty(model.Description)