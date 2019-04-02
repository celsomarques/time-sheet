namespace TimeSheet

open System
open Microsoft.EntityFrameworkCore

type BaseContext() =
    inherit DbContext(
        DbContextOptionsBuilder().
            UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STR")).
            Options
    )