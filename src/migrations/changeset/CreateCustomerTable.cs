using System;

using FluentMigrator;

namespace Migrations {

    [Migration(20190413173500)]
    public class CreateCustomerTable : AutoReversingMigration {

        public override void Up() {
            Create.
                Table("customers").
                WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(Guid.NewGuid()).
                WithColumn("name").AsString(255).NotNullable();
        }
    }
}