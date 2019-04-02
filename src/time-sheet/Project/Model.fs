﻿namespace TimeSheet.Project

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<CLIMutable>]
[<Table("projects")>]
type Project = {

    [<Key>]
    [<Column("id")>]
    Id: Guid

    [<Column("name")>]
    Name: string

    [<Column("description")>]
    Description: string
}