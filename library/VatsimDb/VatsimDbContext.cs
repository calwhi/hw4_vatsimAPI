using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimData;

/**
 * The Entity Framework Core tutorial is helpful here: 
 * https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
 *
 * You get this via this command: dotnet add package Microsoft.EntityFrameworkCore.Sqlite
 */

namespace VatsimLibrary.VatsimDb
{

    public class VatsimDbContext : DbContext
    {

        private string dbfile;

        public DbSet<VatsimClientPilotV1> Pilots { get; set; }
        public DbSet<VatsimClientPlannedFlightV1> Flights { get; set; }
        public DbSet<VatsimClientPilotSnapshotV1> Positions { get; set; }
        public DbSet<VatsimClientATCV1> Controllers { get; set; }

        public VatsimDbContext()
        {
            VatsimDataReader.EnsureDataDirectoryExists(VatsimDbHelper.DATA_DIR);
            this.dbfile = $@"{VatsimDbHelper.DATA_DIR}\vatsim.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($@"Data Source={dbfile}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // establish derived type keys
            modelBuilder.Entity<VatsimClientATCV1>()
                .HasKey(c => new { c.Cid, c.Callsign, c.TimeLogon });
            
            modelBuilder.Entity<VatsimClientPilotV1>()
                .HasKey(p => new { p.Cid, p.Callsign, p.TimeLogon });

            /* this establishes a composite key */
            modelBuilder.Entity<VatsimClientPlannedFlightV1>()
                .HasKey(f => new { f.Cid, 
                                   f.Callsign, 
                                   f.TimeLogon, 
                                   f.PlannedDepairport, 
                                   f.PlannedDestairport });

            /* this establishes a composite key */
            modelBuilder.Entity<VatsimClientPilotSnapshotV1>()
                .HasKey(p => new { p.Cid, p.Callsign, p.TimeLogon, p.TimeStamp });

        }
    }
}