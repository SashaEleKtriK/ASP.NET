using RSVP;
using System.Data.Entity;
public class SampleContext : DbContext
{
    public SampleContext()
    : base("SeminarBD")
    { }
    public DbSet<GuestResponse> GuestResponses { get; set; }
    public DbSet<Report> Reports { get; set; }
}