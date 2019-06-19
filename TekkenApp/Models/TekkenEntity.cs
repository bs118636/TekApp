namespace TekkenApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SQLite;

    public partial class TekkenEntity : DbContext
    {
        public TekkenEntity() : base("name=TekkenEntity") { }

        public TekkenEntity(string connectionString) : base(new SQLiteConnection() { ConnectionString = connectionString }, true) { }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Moves> Moves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
