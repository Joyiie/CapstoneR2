#pragma warning disable CS8618
using CapstoneR2.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneR2.Infrastructure.Domain
{

    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions<DefaultDBContext> options)
     : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ConsultationRecord> ConsultationRecords { get; set; }
        public DbSet<Finding> Findings { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Patient> patients = new List<Patient>();
            List<ConsultationRecord> consultationRecords = new List<ConsultationRecord>();
            List<Finding> findings = new List<Finding>();
            List<User> users = new List<User>();
            List<Role> roles = new List<Role>();
            List<Appointment> appointments = new List<Appointment>();
            List<Prescription> prescriptions = new List<Prescription>();
            List<UserLogin> userLogins = new List<UserLogin>();
            List<UserRole> userRoles = new List<UserRole>();


            patients.Add(new Patient()
            {
                ID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                FirstName = "Raniel",
                MiddleName = "Adan",
                LastName = "Morales",
                Address = "Dinalupihan, Orani, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),
               
                Gender = Models.Enums.Gender.male
            });

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("12-02-23 12:00"),
                Symptom = "Dry Eyes"
            });


            consultationRecords.Add(new ConsultationRecord()
            {
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                AppointmentID = Guid.Parse("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                ID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                DateCreated = DateTime.Parse("07-01-22 11:30"),
           
                DateUpdated = DateTime.Parse("07-01-22 11:30"),
            }) ;
            findings.Add(new Finding()
            {
                ConsultationRecordID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                Description = "sore eyes",
                ID = Guid.NewGuid(),
                Tags = "123"
            });

            prescriptions.Add(new Prescription()
            {
                ConsultationRecordID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                Description = "biogesic",
                ID = Guid.NewGuid(),
                Tags= "123"
            });
            users.Add(new User()
            {
                ID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                Email = "renieldavid@yahoo.com",
                FirstName = "Reniel",
                LastName = "David",
                MiddleName = "Adan",
                BirthDate = DateTime.Parse("23/01/2001"),
                
                Gender = Models.Enums.Gender.male,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a")   
                , Address = "Dinalupihan, Orani, Bataan"
            });


            users.Add(new User()
            {
                ID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                Email =  "Janedavid@yahoo.com",
                FirstName = "Jane",
                LastName = "David",
                MiddleName = "Adan",
                BirthDate = DateTime.Parse("21/02/2002"),
               
                Gender = Models.Enums.Gender.female,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Address = "Dinalupihan, Orani , Bataan"
                
            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });

            roles.Add(new Role()
            {
                ID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Name = "patient",
                Abbreviation = "Pt",
                Description ="One who receives medical treatment"
            });

            roles.Add(new Role()
            {
                ID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Name = "admin",
                Abbreviation = "Adm",
                Description = "One who manages the system"
            });

            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });

            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
            });


            modelBuilder.Entity<ConsultationRecord>().HasData(consultationRecords);
            modelBuilder.Entity<Finding>().HasData(findings);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserLogin>().HasData(userLogins);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<UserRole>().HasData(userRoles);
        }

    }
}
