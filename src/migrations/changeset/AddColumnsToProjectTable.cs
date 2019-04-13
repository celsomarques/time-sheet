using System;

using FluentMigrator;

namespace Migrations {

    [Migration(20190413175700)]
    public class AddColumnsToProjectTable: Migration {

        public override void Up() {

            Alter.Table("projects").
                AddColumn("customer_id").
                AsGuid();

            Create.ForeignKey("project_customer_fk").
                FromTable("projects").ForeignColumn("customer_id").
                ToTable("customers").PrimaryColumn("id");
        }

        public override void Down() {
            Delete.Column("customer_id").FromTable("projects");
        }
    }
}