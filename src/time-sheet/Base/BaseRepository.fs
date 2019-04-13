namespace TimeSheet

open System

module BaseRepository =

    let private Query query parameters =
        Postgres.getConnection()
        |> Sql.query query
        |> Sql.parameters parameters

(*    let FindAll query mapRowFunc =
        Query query []
        |> Sql.executeTableAsync
        |> Async.map (Sql.mapEachRow mapRowFunc)

    let FindBy query mapRowFunc parameters =
        Query query parameters
        |> Sql.executeTableAsync
        |> Async.map (Sql.mapEachRow mapRowFunc)

    let FindById query (id: Guid) mapRowFunc =
        [ "id", Sql.Value id ]
        |> FindBy query mapRowFunc
        |> Async.map (List.tryHead)

    let Save query parameters =
        Query query parameters
        |> Sql.executeNonQueryAsync

    let Delete query (id: Guid) =
        [ "id", Sql.Value id ]
        |> Query query
        |> Sql.executeNonQueryAsync
        *)