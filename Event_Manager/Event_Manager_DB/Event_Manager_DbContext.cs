namespace Event_Manager_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Event_Manager_DB.Entities;

    public partial class Event_Manager_DbContext : DbContext
    {
        public Event_Manager_DbContext()
            : base("name=Event_Manager_DbContext")
        {
        }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
