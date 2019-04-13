using System;

using FluentMigrator;

namespace Migrations {

    [Migration(20190330123000)]
    public class CreateProjectTable : AutoReversingMigration {

        public override void Up() {
            Create.
                Table("projects").
                WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(Guid.NewGuid()).
                WithColumn("name").AsString(255).NotNullable().
                WithColumn("description").AsString(255);
        }
    }
}