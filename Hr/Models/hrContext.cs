using System;
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hr.Models
{
    public partial class hrContext : DbContext
    {
        internal readonly object ACourcesName;

        public hrContext() 
        {

            
        }

        public hrContext(DbContextOptions<hrContext> options)
            : base(options)
        {
            //this.Database.SetCommandTimeout(3 * 60);

        }
        public virtual DbSet<memberst> Memberst { get; set; }
        public virtual DbSet<members> Members { get; set; }
        public virtual DbSet<commite> commite { get; set; }
        public virtual DbSet<Payrollr2> Payrollrs2 { get; set; }
        public virtual DbSet<Payrollr> Payrollrs { get; set; }
        public virtual DbSet<PersnolEmpGrade> PersnolEmpGrade { get; set; }
        public virtual DbSet<TMRequestTypeId2> TMRequestTypeIds2 { get; set; }
        public virtual DbSet<TMDetail2> TMDetailss2 { get; set; }
        public virtual DbSet<TMcomment2> TMComments2 { get; set; }
        public virtual DbSet<EvalRequestTypeId2> EvalRequestTypeIds2 { get; set; }
        public virtual DbSet<EvalDetail2> EvalDetailss2 { get; set; }
        public virtual DbSet<Evalcomment2> EvalComments2 { get; set; }
        public virtual DbSet<Aevallog> Aevallogs { get; set; }
        public virtual DbSet<Aeval2log> Aeval2logs { get; set; }
        public virtual DbSet<SupportDetail> SupportDetails { get; set; }
        public virtual DbSet<SupportProcess> SupportProcesses { get; set; }
        public virtual DbSet<SupportRequestTypeId> SupportRequestTypeIds { get; set; }
        public virtual DbSet<Supportcomment> Supportcomments { get; set; }
        public virtual DbSet<MessagesRequestTypeId> MessagesRequestTypeIds { get; set; }
        public virtual DbSet<MessagesDetail> MessagesDetailss { get; set; }
        public virtual DbSet<Messagescomment> Messagescomments { get; set; }
        public virtual DbSet<MessagesProcess> MessagesProcesss { get; set; }
        public virtual DbSet<AGoalsLogs> AGoalsLogs { get; set; }
        public virtual DbSet<APersonalEmpLogsf> APersonalEmpLogsf { get; set; }
        public virtual DbSet<APersonalEmpLogs> APersonalEmpLogs { get; set; }
        public virtual DbSet<ACourcesLogs> ACourcesLogs { get; set; }
        public virtual DbSet<ACourcesLogsD> ACourcesLogsD { get; set; }
        public virtual DbSet<EvalRequestTypeId> EvalRequestTypeIds { get; set; }
        public virtual DbSet<EvalDetail> EvalDetailss { get; set; }
        public virtual DbSet<Evalcomment> EvalComments { get; set; }

        public virtual DbSet<MasterRequestTypeId> MasterRequestTypeIds { get; set; }
        public virtual DbSet<MasterDetails> MasterDetailss { get; set; }
        public virtual DbSet<ViewModelMasterwithother> ViewModelMasterwithothers { get; set; }
        
        public virtual DbSet<ACourcesCertImage> ACourcesCertImages { get; set; }
        public virtual DbSet<ACourcesCertImagehr> ACourcesCertImagehrs { get; set; }
        public virtual DbSet<ACourcesDeptin> ACourcesDeptins { get; set; }
        public virtual DbSet<ACourcesDeptout> ACourcesDeptouts { get; set; }
        public virtual DbSet<ACourcesEstimate> ACourcesEstimates { get; set; }
        public virtual DbSet<ACourcesMaster> ACourcesMasters { get; set; }
        public virtual DbSet<ACourcesName> ACourcesNames { get; set; }

        public virtual DbSet<ACourcesPrograms> ACourcesPrograms { get; set; }
        public virtual DbSet<ACourcesPrograms1> ACourcesPrograms1 { get; set; }
        public virtual DbSet<AJobsNames> AJobsNames { get; set; }
        public virtual DbSet<ACourcesTrainingMethod> ACourcesTrainingMethods { get; set; }
        public virtual DbSet<ACourcesType> ACourcesTypes { get; set; }
        public virtual DbSet<Cemp> Cemps { get; set; }
        public virtual DbSet<MenuModels> menuemodelss { get; set; }
        public virtual DbSet<Roles> roless { get; set; }
        public virtual DbSet<logind> logind { get; set; }

        public virtual DbSet<loginc> loginc { get; set; }

        public virtual DbSet<MainMenue> MainMenues { get; set; }
        public virtual DbSet<ViewModelRoleWithOther> ViewModelRoleWithOther { get; set; }
      
        public virtual DbSet<ViewModelEvalwithother> ViewModelEvalwithother { get; set; }
        public virtual DbSet<ViewModelEvalwithother1> ViewModelEvalwithother1 { get; set; }

        public virtual DbSet<ACoursesLocation> ACoursesLocation { get; set; }
        public virtual DbSet<ACourcesNeeded> ACourcesNeeded { get; set; }
        public virtual DbSet<ACourcesNeeded1> ACourcesNeeded1 { get; set; }
        public virtual DbSet<ACourcesOffered> ACourcesOffered { get; set; }
        public virtual DbSet<ACourcesOffered2> ACourcesOffered2 { get; set; }

        public virtual DbSet<ACourcesOffered3> ACourcesOffered3 { get; set; }

        public virtual DbSet<ACourcesIdManagement> ACourcesIdManagement { get; set; }

        public virtual DbSet<ACourcesOptions> ACourcesOptions { get; set; }

        public virtual DbSet<NeededDetails> NeededDetails { get; set; }
        public virtual DbSet<Needed1Details> Needed1Details { get; set; }
        public virtual DbSet<OfferedDetails> OfferedDetails { get; set; }

        public virtual DbSet<OfferedDetails2> OfferedDetails2 { get; set; }

        public virtual DbSet<OfferedDetails3> OfferedDetails3 { get; set; }
        public virtual DbSet<NeededRequestTypeId> NeededRequestTypeId { get; set; }
        public virtual DbSet<Needed1RequestTypeId> Needed1RequestTypeId { get; set; }

        public virtual DbSet<OfferedRequestTypeId> OfferedRequestTypeId { get; set; }

        public virtual DbSet<OfferedRequestTypeId2> OfferedRequestTypeId2 { get; set; }
        public virtual DbSet<OfferedRequestTypeId3> OfferedRequestTypeId3 { get; set; }


        public virtual DbSet<DepartWithMnagement> DepartWithMnagement { get; set; }
        public virtual DbSet<NeededComments> NeededComments { get; set; }
        public virtual DbSet<Needed1Comments> Needed1Comments { get; set; }
        public virtual DbSet<OfferComments> OfferComments { get; set; }


        
        public virtual DbSet<OfferComments2> OfferComments2 { get; set; }
        public virtual DbSet<OfferComments3> OfferComments3 { get; set; }


        public virtual DbSet<AEvaluEmpType> AEvaluEmpTypes { get; set; }
        public virtual DbSet<AEvaluationCompetenciesD> AEvaluationCompetenciesDs { get; set; }
        public virtual DbSet<AEvaluationCompetenciesM> AEvaluationCompetenciesMs { get; set; }
        public virtual DbSet<AEvaluationEmp> AEvaluationEmps { get; set; }
        public virtual DbSet<AEvaluationEmpLog> AEvaluationEmpLogs { get; set; }
        public virtual DbSet<AEvaluationGoal> AEvaluationGoals { get; set; }
        public virtual DbSet<AEvaluationGoal1> AEvaluationGoals1 { get; set; }

        public virtual DbSet<TransferDetail> TransferDetails { get; set; }
        public virtual DbSet<TransferProcess> TransferProcesss { get; set; }
        public virtual DbSet<TransferRequestTypeId> TransferRequestTypeIds { get; set; }
        public virtual DbSet<Transfercomment> Transfercomments { get; set; }
        public virtual DbSet<TasksEmployee> TasksEmployee { get; set; }
        public virtual DbSet<TasksEmployeeGoals> TasksEmployeeGoals { get; set; }
        public virtual DbSet<TasksEmployeeTasks> TasksEmployeeTasks { get; set; }
        public virtual DbSet<TasksManagement> TasksManagement { get; set; }
        public virtual DbSet<TasksManagementDesc> TasksManagementDesc { get; set; }
        public virtual DbSet<TasksManagementsDecision> TasksManagementsDecision { get; set; }
        public virtual DbSet<TasksManagementsOutput> TasksManagementsOutput { get; set; }
        public virtual DbSet<TasksManagementGoals> TasksManagementGoals { get; set; }
        public virtual DbSet<TasksManagementStat> TasksManagementStat { get; set; }
        public virtual DbSet<TasksManagementTasks> TasksManagementTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-4IRPVGQ\\SQLEXPRESS;Database=hr;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //
            modelBuilder.Entity<memberst>(entity =>
            {
                entity.ToTable("memberstmp");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.userid)
                    .HasColumnName("userid");
                entity.Property(e => e.username)
                  .HasColumnName("username");

                entity.Property(e => e.dateexcute)
                  .HasColumnName("dateexcute");

                entity.Property(e => e.commitedescession)
               .HasColumnName("commitedescession");
                entity.Property(e => e.userentry)
               .HasColumnName("userentry");

                entity.Property(e => e.timeentry)
              .HasColumnName("timeentry");


            });
            //
            modelBuilder.Entity<members>(entity =>
            {
                entity.ToTable("members");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.userid)
                    .HasColumnName("userid");
                entity.Property(e => e.username)
                  .HasColumnName("username");

                entity.Property(e => e.dateexcute)
                  .HasColumnName("dateexcute");

                entity.Property(e => e.commitedescession)
               .HasColumnName("commitedescession");
                entity.Property(e => e.userentry)
               .HasColumnName("userentry");

                entity.Property(e => e.timeentry)
              .HasColumnName("timeentry");

                entity.Property(e => e.status)
              .HasColumnName("status");
            });
            //
            modelBuilder.Entity<commite>(entity =>
            {
                entity.ToTable("commite");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.userid)
                    .HasColumnName("userid");
                entity.Property(e => e.username)
                  .HasColumnName("username");

                entity.Property(e => e.dateexcute)
                  .HasColumnName("dateexcute");

                entity.Property(e => e.commitedescession)
               .HasColumnName("commitedescession");
                entity.Property(e => e.userentry)
               .HasColumnName("userentry");

                entity.Property(e => e.timeentry)
              .HasColumnName("timeentry");
                entity.Property(e => e.CourcesIdImagecert)
               .HasColumnName("CourcesIdImagecert");
                entity.Property(e => e.status)
                  .HasColumnName("status");

            });

            //
            modelBuilder.Entity<TasksEmployee>(entity =>
            {
                entity.ToTable("TasksEmployees");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");

              

            });
            //
            modelBuilder.Entity<TasksEmployeeGoals>(entity =>
            {
                entity.ToTable("TasksEmployeesGoals");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksEmployeeTasks>(entity =>
            {
                entity.ToTable("TasksEmployeesTasks");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagement>(entity =>
            {
                entity.ToTable("TasksManagements");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementDesc>(entity =>
            {
                entity.ToTable("TasksManagementsDesc");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementsDecision>(entity =>
            {
                entity.ToTable("TasksManagementsDecision");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementsOutput>(entity =>
            {
                entity.ToTable("TasksManagementsOutput");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementGoals>(entity =>
            {
                entity.ToTable("TasksManagementsGoals");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementStat>(entity =>
            {
                entity.ToTable("TasksManagementsStat");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<TasksManagementTasks>(entity =>
            {
                entity.ToTable("TasksManagementsTasks");
                entity.HasKey(e => e.TaskMSerial);

                entity.Property(e => e.TaskMSerial).HasColumnName("TaskMSerial");
                entity.Property(e => e.TaskM1)
                    .HasColumnName("TaskM1");
                entity.Property(e => e.TaskM2)
                  .HasColumnName("TaskM2");

                entity.Property(e => e.TaskM3)
                  .HasColumnName("TaskM3");

                entity.Property(e => e.TaskM4)
               .HasColumnName("TaskM4");
                entity.Property(e => e.TaskM5)
               .HasColumnName("TaskM5");

                entity.Property(e => e.TaskM6)
              .HasColumnName("TaskM6");

                entity.Property(e => e.TaskM7)
            .HasColumnName("TaskM7");

                entity.Property(e => e.TaskM8)
           .HasColumnName("TaskM8");

                entity.Property(e => e.TaskM9)
           .HasColumnName("TaskM9");

                entity.Property(e => e.TaskM10)
           .HasColumnName("TaskM10");



            });
            //
            modelBuilder.Entity<Payrollr2>(entity =>
            {
                entity.ToTable("payrollr2");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("reqid");
                entity.Property(e => e.requestor)
                    .HasColumnName("requestor");
                entity.Property(e => e.EmpName)
                  .HasColumnName("EmpName");

                entity.Property(e => e.grade)
                  .HasColumnName("grade");

                entity.Property(e => e.classs)
               .HasColumnName("class");
                entity.Property(e => e.hiring)
               .HasColumnName("hiring");

                entity.Property(e => e.BirthDate)
              .HasColumnName("BirthDate");

                entity.Property(e => e.Department)
            .HasColumnName("Department");

                entity.Property(e => e.phone)
           .HasColumnName("phone");

                entity.Property(e => e.parent)
           .HasColumnName("parent");

                entity.Property(e => e.Parm1)
           .HasColumnName("Parm1");

                entity.Property(e => e.Parm2)
          .HasColumnName("Parm2");

                entity.Property(e => e.Parm3)
          .HasColumnName("Parm3");

                entity.Property(e => e.Parm4)
          .HasColumnName("Parm4");
                entity.Property(e => e.Parm5)
          .HasColumnName("Parm5");
                entity.Property(e => e.Parm6)
          .HasColumnName("Parm6");
                entity.Property(e => e.Parm7)
          .HasColumnName("Parm7");
      //          entity.Property(e => e.Parm8)
      //.HasColumnName("Parm8");

            });
            //
            modelBuilder.Entity<Payrollr>(entity =>
            {
                entity.ToTable("payrollr");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("reqid");
                entity.Property(e => e.requestor)
                    .HasColumnName("requestor");
                entity.Property(e => e.EmpName)
                  .HasColumnName("EmpName");

                entity.Property(e => e.grade)
                  .HasColumnName("grade");

                entity.Property(e => e.classs)
               .HasColumnName("class");
                entity.Property(e => e.hiring)
               .HasColumnName("hiring");

                entity.Property(e => e.BirthDate)
              .HasColumnName("BirthDate");

                entity.Property(e => e.Department)
            .HasColumnName("Department");

                entity.Property(e => e.phone)
           .HasColumnName("phone");

                entity.Property(e => e.parent)
           .HasColumnName("parent");

                entity.Property(e => e.Parm1)
           .HasColumnName("Parm1");

                entity.Property(e => e.Parm2)
          .HasColumnName("Parm2");

                entity.Property(e => e.Parm3)
          .HasColumnName("Parm3");

                entity.Property(e => e.Parm4)
          .HasColumnName("Parm4");
                entity.Property(e => e.Parm5)
          .HasColumnName("Parm5");
                entity.Property(e => e.Parm6)
          .HasColumnName("Parm6");
                entity.Property(e => e.Parm7)
          .HasColumnName("Parm7");
                entity.Property(e => e.Parm8)
      .HasColumnName("Parm8");

            });

            //
            modelBuilder.Entity<PersnolEmpGrade>(entity =>
            {
                entity.ToTable("PersonalEmpGrade");
                entity.HasKey(e => e.seriad);

                entity.Property(e => e.seriad).HasColumnName("seriad");


                entity.Property(e => e.empnational)
                    .HasMaxLength(250)
                    .HasColumnName("empnational");

                entity.Property(e => e.empname)
                    .HasMaxLength(250)
                    .HasColumnName("empname");

                entity.Property(e => e.empgrade)
                      .HasMaxLength(250)
                      .HasColumnName("empgrade");
                entity.Property(e => e.empdate)
                      //.HasMaxLength(250)
                      .HasColumnName("empdate");
            });
            //
            modelBuilder.Entity<Aeval2log>(entity =>
            {
                entity.ToTable("AEVAL2LOGS");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Editdate)
                    .HasColumnType("datetime")
                    .HasColumnName("editdate");

                entity.Property(e => e.Evid)
                    .HasMaxLength(250)
                    .HasColumnName("evid");

                entity.Property(e => e.Useredit)
                    .HasMaxLength(50)
                    .HasColumnName("useredit");
            });
            //
            modelBuilder.Entity<Aevallog>(entity =>
            {
                entity.ToTable("AEVALLOGS");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Editdate)
                    .HasColumnType("datetime")
                    .HasColumnName("editdate");

                entity.Property(e => e.Evid)
                    .HasMaxLength(250)
                    .HasColumnName("evid");

                entity.Property(e => e.Useredit)
                    .HasMaxLength(50)
                    .HasColumnName("useredit");
            });
            modelBuilder.Entity<SupportDetail>(entity =>
            {
                entity.ToTable("SupportDetails");
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3_copy1_copy1_copy1");
                

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });

            modelBuilder.Entity<SupportProcess>(entity =>
            {
                entity.ToTable("SupportProcess");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Daterequest)
                    .HasColumnType("datetime")
                    .HasColumnName("daterequest");

                entity.Property(e => e.Fromr)
                    .HasMaxLength(50)
                    .HasColumnName("fromr");

                entity.Property(e => e.Mestypereqidp).HasColumnName("mestypereqidp");

                entity.Property(e => e.Mestypetopic0)
                   .HasMaxLength(250)
                   .HasColumnName("mestypetopic0");

                entity.Property(e => e.Mestypetopic)
                    .HasMaxLength(250)
                    .HasColumnName("mestypetopic");

                entity.Property(e => e.Redesc)
                    .HasMaxLength(250)
                    .HasColumnName("redesc");
            });

            modelBuilder.Entity<SupportRequestTypeId>(entity =>
            {
                entity.ToTable("SupportRequestTypeId");
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3_copy1_copy1_copy1");

                entity.ToTable("SupportRequestTypeId");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<Supportcomment>(entity =>
            {
                entity.ToTable("Supportcomments");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
            });

            //
            modelBuilder.Entity<MessagesDetail>(entity =>
            {
                entity.ToTable("MessagesDetails");
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3_copy1_copy1");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });

            modelBuilder.Entity<MessagesProcess>(entity =>
            {
                entity.ToTable("MessagesProcess");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Daterequest)
                    .HasColumnType("datetime")
                    .HasColumnName("daterequest");

                entity.Property(e => e.Fromr)
                    .HasMaxLength(50)
                    .HasColumnName("fromr");

             

                entity.Property(e => e.redesc)
                    .HasMaxLength(50)
                    .HasColumnName("redesc");

              

                entity.Property(e => e.mestypereqid).HasColumnName("mestypereqid");

                entity.Property(e => e.mestypetopic)
                    .HasMaxLength(250)
                    .HasColumnName("mestypetopic");
            });

            modelBuilder.Entity<MessagesRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3_copy1_copy1");

                entity.ToTable("MessagesRequestTypeId");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<Messagescomment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
            });
            //
            modelBuilder.Entity<AGoalsLogs>(entity =>
            {
                entity.ToTable("A_GOALS_LOGS");
                entity.HasKey(e => e.id)
                    .HasName("id");

                entity.Property(e => e.requestid).HasColumnName("REUESTID");
                entity.Property(e => e.userr).HasColumnName("USERr");
                entity.Property(e => e.tt).HasColumnName("tt");


            });
            //
            modelBuilder.Entity<APersonalEmpLogsf>(entity =>
            {
                entity.ToTable("A_PersonalEmp_LOGSF");
                entity.HasKey(e => e.id)
                    .HasName("id");

                entity.Property(e => e.requestid).HasColumnName("REUESTID");
                entity.Property(e => e.userr).HasColumnName("USERr");
                entity.Property(e => e.tt).HasColumnName("tt");


            });
            //
            modelBuilder.Entity<APersonalEmpLogs>(entity =>
            {
                entity.ToTable("A_PersonalEmp_LOGS");
                entity.HasKey(e => e.id)
                    .HasName("id");

                entity.Property(e => e.requestid).HasColumnName("REUESTID");
                entity.Property(e => e.userr).HasColumnName("USERr");
                entity.Property(e => e.tt).HasColumnName("tt");


            });


            //
            modelBuilder.Entity<ACourcesLogs>(entity =>
            {
                entity.ToTable("A_COURCES_LOGS");
                entity.HasKey(e => e.id)
                    .HasName("id");

                entity.Property(e => e.requestid).HasColumnName("REUESTID");
                entity.Property(e => e.userr).HasColumnName("USERr");
                entity.Property(e => e.tt).HasColumnName("tt");


            });
            //
            modelBuilder.Entity<ACourcesLogsD>(entity =>
            {
                entity.ToTable("A_COURCES_LOGSD");
                entity.HasKey(e => e.id)
                    .HasName("id");

                entity.Property(e => e.requestid).HasColumnName("REUESTID");
                entity.Property(e => e.userr).HasColumnName("USERr");
                entity.Property(e => e.tt).HasColumnName("tt");


            });

            //
            modelBuilder.Entity<TransferDetail>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3_copy1");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });

            modelBuilder.Entity<TransferProcess>(entity =>
            {
                entity.ToTable("TransferProcess");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.fromr).HasColumnName("fromr");

                entity.Property(e => e.Daterequest)
                    .HasColumnType("datetime")
                    .HasColumnName("daterequest");

                entity.Property(e => e.Manageolddepid).HasColumnName("manageolddepid");

                entity.Property(e => e.Managernewid).HasColumnName("managernewid");

                entity.Property(e => e.Managernewname)
                    .HasMaxLength(50)
                    .HasColumnName("managernewname");

                entity.Property(e => e.Manageroldname)
                    .HasMaxLength(250)
                    .HasColumnName("manageroldname");

                entity.Property(e => e.Newdepid).HasColumnName("newdepid");

                entity.Property(e => e.Newdepname)
                    .HasMaxLength(250)
                    .HasColumnName("newdepname");

                entity.Property(e => e.Olddepid).HasColumnName("olddepid");

                entity.Property(e => e.Olddepname)
                    .HasMaxLength(250)
                    .HasColumnName("olddepname");
            });

            modelBuilder.Entity<TransferRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3_copy1");

                entity.ToTable("TransferRequestTypeId");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<Transfercomment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
            });
            //
            modelBuilder.Entity<AEvaluEmpType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A_EVALU_EMP_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<AEvaluationCompetenciesD>(entity =>
            {
                entity.HasKey(e => e.Idd2);

                entity.ToTable("A_EVALUATION_COMPETENCIES_D");

                //entity.Property(e => e.Idd2)
                //    .ValueGeneratedNever()
                //    .HasColumnName("IDD");

                entity.Property(e => e.CovenantCompetenciecDLevel).HasColumnName("COVENANT_COMPETENCIEC_D_LEVEL");

                entity.Property(e => e.CovenantCompetenciesDDesc)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_COMPETENCIES_D_DESC");

                entity.Property(e => e.CovenantCompetenciesDSeq).HasColumnName("COVENANT_COMPETENCIES_D_SEQ");

                entity.Property(e => e.CovenantCompetenciesDSeqD).HasColumnName("COVENANT_COMPETENCIES_D_SEQ_D");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.EvaluationOutputCompetency).HasColumnName("EVALUATION_OUTPUT_COMPETENCY");

                entity.Property(e => e.EvaluationResults).HasColumnName("EVALUATION_RESULTS");
                entity.Property(e => e.EvaluationResults2).HasColumnName("EVALUATION_RESULTS2");

                entity.Property(e => e.EvaluationTotal).HasColumnName("EVALUATION_TOTAL");
            });

            modelBuilder.Entity<AEvaluationCompetenciesM>(entity =>
            {
                entity.HasKey(e => e.Idd1);

                entity.ToTable("A_EVALUATION_COMPETENCIES_M");

                //entity.Property(e => e.Idd1)
                //    .ValueGeneratedNever()
                //    .HasColumnName("IDD");

                entity.Property(e => e.CovenantCompetenciesSeq).HasColumnName("COVENANT_COMPETENCIES_SEQ");

                entity.Property(e => e.CovenantCompetencyName)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_COMPETENCY_NAME");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.CovenantWeight)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_WEIGHT");

                entity.Property(e => e.CovenantWeightSum).HasColumnName("COVENANT_WEIGHT_SUM");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");
            });

            modelBuilder.Entity<AEvaluationEmp>(entity =>
            {
                entity.HasKey(e => e.Idd);

                entity.ToTable("A_EVALUATION_EMP");

                //entity.Property(e => e.Idd)
                //    .ValueGeneratedNever()
                //    .HasColumnName("IDD");

                entity.Property(e => e.Adprtno).HasColumnName("ADPRTNO");

                entity.Property(e => e.CovenantDate)
                    .HasColumnType("date")
                    .HasColumnName("COVENANT_DATE");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.CovenantYear).HasColumnName("COVENANT_YEAR");

                entity.Property(e => e.DepName)
                    .HasMaxLength(250)
                    .HasColumnName("DEP_NAME");

                entity.Property(e => e.EmpIdEnter).HasColumnName("EMP_ID_ENTER");
                entity.Property(e => e.year).HasColumnName("year");

                entity.Property(e => e.Empname)
                    .HasMaxLength(250)
                    .HasColumnName("EMPNAME");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.EvaEmpnoNameOut)
                    .HasMaxLength(250)
                    .HasColumnName("EVA_EMPNO_NAME_OUT");

                entity.Property(e => e.EvaEmpnoNameOut1)
                    .HasMaxLength(250)
                    .HasColumnName("EVA_EMPNO_NAME_OUT1");

                entity.Property(e => e.EvaEmpnoOut).HasColumnName("EVA_EMPNO_OUT");

                entity.Property(e => e.Jobname)
                    .HasMaxLength(250)
                    .HasColumnName("JOBNAME");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(250)
                    .HasColumnName("MANAGER_NAME");

                entity.Property(e => e.Managerid).HasColumnName("MANAGERID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .HasColumnName("NOTES");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.SubDepName)
                    .HasMaxLength(250)
                    .HasColumnName("SUB_DEP_NAME");

                entity.Property(e => e.TypeNo)
                    .HasColumnName("TYPE_NO")
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.comment1).HasColumnName("comment1");
                entity.Property(e => e.comment2).HasColumnName("comment2");
            });

            modelBuilder.Entity<AEvaluationEmpLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A_EVALUATION_EMP_LOG");

                entity.Property(e => e.Adprtno).HasColumnName("ADPRTNO");

                entity.Property(e => e.CovenantDate)
                    .HasColumnType("date")
                    .HasColumnName("COVENANT_DATE");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.CovenantYear).HasColumnName("COVENANT_YEAR");

                entity.Property(e => e.Datee)
                    .HasColumnType("date")
                    .HasColumnName("DATEE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepName)
                    .HasMaxLength(250)
                    .HasColumnName("DEP_NAME");

                entity.Property(e => e.EmpIdEnter).HasColumnName("EMP_ID_ENTER");

                entity.Property(e => e.Empname)
                    .HasMaxLength(250)
                    .HasColumnName("EMPNAME");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.EvaEmpnoNameOut)
                    .HasMaxLength(250)
                    .HasColumnName("EVA_EMPNO_NAME_OUT");

                entity.Property(e => e.EvaEmpnoNameOut1)
                    .HasMaxLength(250)
                    .HasColumnName("EVA_EMPNO_NAME_OUT1");

                entity.Property(e => e.EvaEmpnoOut).HasColumnName("EVA_EMPNO_OUT");

                entity.Property(e => e.Idd).HasColumnName("IDD");

                entity.Property(e => e.Jobname)
                    .HasMaxLength(250)
                    .HasColumnName("JOBNAME");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(250)
                    .HasColumnName("MANAGER_NAME");

                entity.Property(e => e.Managerid).HasColumnName("MANAGERID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .HasColumnName("NOTES");

                entity.Property(e => e.OpType)
                    .HasMaxLength(250)
                    .HasColumnName("OP_TYPE");

                entity.Property(e => e.OpTypeId).HasColumnName("OP_TYPE_ID");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.Seq).HasColumnName("SEQ");

                entity.Property(e => e.SubDepName)
                    .HasMaxLength(250)
                    .HasColumnName("SUB_DEP_NAME");

                entity.Property(e => e.TypeNo).HasColumnName("TYPE_NO");
            });
            modelBuilder.Entity<AEvaluationGoal>(entity =>
            {
                entity.HasKey(e => e.Idd4);

                entity.ToTable("A_EVALUATION_GOALS");

                entity.Property(e => e.CovenantDate)
                    .HasColumnType("date")
                    .HasColumnName("COVENANT_DATE");

                entity.Property(e => e.CovenantGoalsName)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_GOALS_NAME");

                entity.Property(e => e.CovenantGoalsSeq).HasColumnName("COVENANT_GOALS_SEQ");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.CovenantMeasurementCriteria)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_MEASUREMENT_CRITERIA");

                entity.Property(e => e.CovenantPercentageWeight).HasColumnName("COVENANT_PERCENTAGE_WEIGHT");

                entity.Property(e => e.CovenantTargetedOutput).HasColumnName("COVENANT_TARGETED_OUTPUT");

                entity.Property(e => e.CovenantWeightSum).HasColumnName("COVENANT_WEIGHT_SUM");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.EmpIdEnter).HasColumnName("EMP_ID_ENTER");

                entity.Property(e => e.EmpType)
                    .HasMaxLength(250)
                    .HasColumnName("EMP_TYPE");

                entity.Property(e => e.EvaluationActualOutput).HasColumnName("EVALUATION_ACTUAL_OUTPUT");

                entity.Property(e => e.EvaluationDate)
                    .HasColumnType("date")
                    .HasColumnName("EVALUATION_DATE");

                entity.Property(e => e.EvaluationDifferenceOutputs).HasColumnName("EVALUATION_DIFFERENCE_OUTPUTS");

                entity.Property(e => e.EvaluationEquilibrium).HasColumnName("EVALUATION_EQUILIBRIUM");

                entity.Property(e => e.EvaluationId).HasColumnName("EVALUATION_ID");

                entity.Property(e => e.EvaluationResult).HasColumnName("EVALUATION_RESULT");

                entity.Property(e => e.EvaluationTotal).HasColumnName("EVALUATION_TOTAL");

                entity.Property(e => e.Idd4).HasColumnName("IDD");
            });
            //
            modelBuilder.Entity<AEvaluationGoal1>(entity =>
            {
                entity.HasKey(e => e.Idd4);

                entity.ToTable("A_EVALUATION_GOALS1");

                entity.Property(e => e.CovenantDate)
                    .HasColumnType("date")
                    .HasColumnName("COVENANT_DATE");

                entity.Property(e => e.CovenantGoalsName)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_GOALS_NAME");

                entity.Property(e => e.CovenantGoalsSeq).HasColumnName("COVENANT_GOALS_SEQ");

                entity.Property(e => e.CovenantId).HasColumnName("COVENANT_ID");

                entity.Property(e => e.CovenantMeasurementCriteria)
                    .HasMaxLength(250)
                    .HasColumnName("COVENANT_MEASUREMENT_CRITERIA");

                entity.Property(e => e.CovenantPercentageWeight).HasColumnName("COVENANT_PERCENTAGE_WEIGHT");

                entity.Property(e => e.CovenantTargetedOutput).HasColumnName("COVENANT_TARGETED_OUTPUT");

                entity.Property(e => e.CovenantWeightSum).HasColumnName("COVENANT_WEIGHT_SUM");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.EmpIdEnter).HasColumnName("EMP_ID_ENTER");

                entity.Property(e => e.EmpType)
                    .HasMaxLength(250)
                    .HasColumnName("EMP_TYPE");

                entity.Property(e => e.EvaluationActualOutput).HasColumnName("EVALUATION_ACTUAL_OUTPUT");

                entity.Property(e => e.EvaluationDate)
                    .HasColumnType("date")
                    .HasColumnName("EVALUATION_DATE");

                entity.Property(e => e.EvaluationDifferenceOutputs).HasColumnName("EVALUATION_DIFFERENCE_OUTPUTS");

                entity.Property(e => e.EvaluationEquilibrium).HasColumnName("EVALUATION_EQUILIBRIUM");

                entity.Property(e => e.EvaluationId).HasColumnName("EVALUATION_ID");

                entity.Property(e => e.EvaluationResult).HasColumnName("EVALUATION_RESULT");

                entity.Property(e => e.EvaluationTotal).HasColumnName("EVALUATION_TOTAL");

                entity.Property(e => e.Idd4).HasColumnName("IDD");
            });
            //
            modelBuilder.Entity<TMDetail2>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3");
                entity.ToTable("TMDetails2");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });
            modelBuilder.Entity<TMRequestTypeId2>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3");

                entity.ToTable("TMRequestTypeId2");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<TMcomment2>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("id");
                entity.ToTable("TMcomments2");
                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.dtapproved).HasColumnName("dtapproved");
            });

            //

            modelBuilder.Entity<EvalDetail2>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3");
                entity.ToTable("EvalDetails2");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });
            modelBuilder.Entity<EvalRequestTypeId2>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3");

                entity.ToTable("EvalRequestTypeId2");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<Evalcomment2>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("id");
                entity.ToTable("Evalcomments2");
                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.dtapproved).HasColumnName("dtapproved");
            });


            //
            modelBuilder.Entity<EvalDetail>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial)
                    .HasName("PK_OfferedDetails_copy3");
                entity.ToTable("EvalDetails");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestNotes).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo2).HasMaxLength(250);

                entity.Property(e => e.OfferedRequestTo3).HasMaxLength(50);

                entity.Property(e => e.OfferedRequestTo4)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferedRequestTo5)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offeredoption).HasMaxLength(250);
            });

            modelBuilder.Entity<EvalRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial)
                    .HasName("PK_OfferedRequestTypeId_copy3");

                entity.ToTable("EvalRequestTypeId");

                entity.Property(e => e.CourcesIdoffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.Offercoursefrom).HasMaxLength(250);
            });

            modelBuilder.Entity<Evalcomment>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("id");
                entity.ToTable("Evalcomments");
                entity.Property(e => e.Offerapproval)
                    .HasMaxLength(250)
                    .HasColumnName("offerapproval");

                entity.Property(e => e.Offerdetailscomment)
                    .HasMaxLength(250)
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.Offerdetailsid).HasColumnName("offerdetailsid");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.dtapproved).HasColumnName("dtapproved");
            });


            //
            modelBuilder.Entity<ACourcesCertImage>(entity =>
            {
                entity.HasKey(e => e.CourcesIdImagecert);

                entity.ToTable("A_COURCES_CERT_IMAGE");

                entity.Property(e => e.CourcesIdImagecert).HasColumnName("COURCES_ID_IMAGECERT");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.FileName1)
                    .HasMaxLength(255)
                    .HasColumnName("FILE_NAME1");

                entity.Property(e => e.ImageCreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("IMAGE_CREATED_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.ImageType)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("NOTE");
            });

            modelBuilder.Entity<ACourcesCertImagehr>(entity =>
            {
                entity.HasKey(e => e.CourcesIdImagehr);

                entity.ToTable("A_COURCES_CERT_IMAGEHR");

                entity.Property(e => e.CourcesIdImagehr).HasColumnName("COURCES_ID_IMAGEHR");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.FileName1)
                    .HasMaxLength(255)
                    .HasColumnName("FILE_NAME1");

                entity.Property(e => e.ImageCreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("IMAGE_CREATED_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.ImageType)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("NOTE");
            });

            modelBuilder.Entity<ACourcesNeeded>(entity =>
            {
                entity.HasKey(e => e.CourcesNeededId);

                entity.ToTable("A_COURCES-NEEDED_FOR_CANDIDACY");
                entity.Property(e => e.CourcesNeededId).HasColumnName("A_COURCES-NEEDEDID");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");
                entity.Property(e => e.CourcesIdDescription).HasColumnName("COURCES_ID_DESCRIPTION");

                entity.Property(e => e.CourcesIdDeptin).HasColumnName("COURCES_ID_DEPTIN");

               
                entity.Property(e => e.CourcesIdManagement).HasColumnName("COURCES_ID_MANAGEMENTIN");

                entity.Property(e => e.jobsid).HasColumnName("COURCES_JOBSID");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.Cempid).HasColumnName("CEMPID");

                entity.Property(e => e.notes).HasColumnName("NOTES");
                entity.Property(e => e.available).HasColumnName("available");
                entity.Property(e => e.passrate).HasColumnName("passrate");
                entity.Property(e => e.levelt).HasColumnName("levelt");




            });



            modelBuilder.Entity<ACourcesNeeded1>(entity =>
            {
                entity.HasKey(e => e.CourcesNeededId);

                entity.ToTable("A_COURCES-NEEDED1_FOR_CANDIDACY");
                entity.Property(e => e.CourcesNeededId).HasColumnName("A_COURCES-NEEDEDID");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");
                entity.Property(e => e.CourcesIdDegree).HasColumnName("COURCES_ID_DEGREE");

                entity.Property(e => e.CourcesIdNOOFSTUDENT).HasColumnName("COURCES_ID_NOOFSTUDENT");


                entity.Property(e => e.CourcesIdSEARCHTITLE).HasColumnName("COURCES_ID_SEARCHTITLE");

                entity.Property(e => e.GRADUATIONTITLE).HasColumnName("COURCES_GRADUATIONTITLE");

                //entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.Cempid).HasColumnName("CEMPID");

                entity.Property(e => e.notes).HasColumnName("NOTES");
                entity.Property(e => e.available).HasColumnName("available");
                entity.Property(e => e.passrate).HasColumnName("passrate");

                //entity.Property(e => e.levelt).HasColumnName("levelt");

            });



            modelBuilder.Entity<ACourcesOffered>(entity =>
            {
                entity.HasKey(e => e.CourcesOfferedId);

                entity.ToTable("A_COURCES-OFFERED_FOR_CANDIDACY");
                entity.Property(e => e.CourcesOfferedId).HasColumnName("A_COURCES-OFFEREDID");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesIdLocation).HasColumnName("COURCES_ID_LOCATIONID");
                entity.Property(e => e.CourcesIdManagement).HasColumnName("COURCES_ID_MANAGEMENTIN");

                entity.Property(e => e.CourcesIdperiodbydays).HasColumnName("COURCES_PERIODBYDAYS");

                entity.Property(e => e.CourcesIdTime).HasColumnName("COURCES_TIME");

                entity.Property(e => e.CourcesStartDate).HasColumnName("COURCES_START_DATE");

                entity.Property(e => e.CourcesStartDateh).HasColumnName("COURSES_START_DATE_HIJ");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.Cempid).HasColumnName("CEMPID");

                entity.Property(e => e.Option).HasColumnName("option");
                entity.Property(e => e.available).HasColumnName("available");
                entity.Property(e => e.timefrom).HasColumnName("timefrom");
                entity.Property(e => e.timeto).HasColumnName("timeto");


            });

            modelBuilder.Entity<ACourcesOffered2>(entity =>
            {
                entity.HasKey(e => e.CourcesOfferedId);

                entity.ToTable("A_COURCES-OFFERED_FOR_CANDIDACY2");
                entity.Property(e => e.CourcesOfferedId).HasColumnName("A_COURCES-OFFEREDID");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesIdLocation).HasColumnName("COURCES_ID_LOCATIONID");
                entity.Property(e => e.CourcesIdManagement).HasColumnName("COURCES_ID_MANAGEMENTIN");

                entity.Property(e => e.CourcesIdperiodbydays).HasColumnName("COURCES_PERIODBYDAYS");

                entity.Property(e => e.CourcesIdTime).HasColumnName("COURCES_TIME");

                entity.Property(e => e.CourcesStartDate).HasColumnName("COURCES_START_DATE");

                entity.Property(e => e.CourcesStartDateh).HasColumnName("COURSES_START_DATE_HIJ");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.Cempid).HasColumnName("CEMPID");

                entity.Property(e => e.Option).HasColumnName("option");
                entity.Property(e => e.available).HasColumnName("available");
                entity.Property(e => e.timefrom).HasColumnName("timefrom");
                entity.Property(e => e.timeto).HasColumnName("timeto");
                entity.Property(e => e.COURCES_ID_IMAGE).HasColumnName("COURCES_ID_IMAGE");


            });

            modelBuilder.Entity<ACourcesOffered3>(entity =>
            {
                entity.HasKey(e => e.CourcesOfferedId);

                entity.ToTable("A_COURCES-OFFERED_FOR_CANDIDACY3");
                entity.Property(e => e.CourcesOfferedId).HasColumnName("A_COURCES-OFFEREDID");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");
                entity.Property(e => e.CourcesId2).HasColumnName("COURCES_ID2");
                entity.Property(e => e.CourcesId3).HasColumnName("COURCES_ID3");
                entity.Property(e => e.CourcesId4).HasColumnName("COURCES_ID4");
                entity.Property(e => e.CourcesId5).HasColumnName("COURCES_ID5");
                entity.Property(e => e.CourcesId6).HasColumnName("COURCES_ID6");
                entity.Property(e => e.CourcesId7).HasColumnName("COURCES_ID7");
                entity.Property(e => e.CourcesId8).HasColumnName("COURCES_ID8");

                entity.Property(e => e.CourcesId01).HasColumnName("COURCES_ID01");
                entity.Property(e => e.CourcesId02).HasColumnName("COURCES_ID02");
                entity.Property(e => e.CourcesId03).HasColumnName("COURCES_ID03");
                entity.Property(e => e.CourcesId04).HasColumnName("COURCES_ID04");
                entity.Property(e => e.CourcesId05).HasColumnName("COURCES_ID05");
                entity.Property(e => e.CourcesId06).HasColumnName("COURCES_ID06");
                entity.Property(e => e.CourcesId07).HasColumnName("COURCES_ID07");
                entity.Property(e => e.CourcesId08).HasColumnName("COURCES_ID08");

                entity.Property(e => e.CourcesPassRate1).HasColumnName("CourcesPassRate1");
                entity.Property(e => e.CourcesPassRate2).HasColumnName("CourcesPassRate2");
                entity.Property(e => e.CourcesPassRate3).HasColumnName("CourcesPassRate3");
                entity.Property(e => e.CourcesPassRate4).HasColumnName("CourcesPassRate4");
                entity.Property(e => e.CourcesPassRate5).HasColumnName("CourcesPassRate5");
                entity.Property(e => e.CourcesPassRate6).HasColumnName("CourcesPassRate6");
                entity.Property(e => e.CourcesPassRate7).HasColumnName("CourcesPassRate7");
                entity.Property(e => e.CourcesPassRate8).HasColumnName("CourcesPassRate8");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                //entity.Property(e => e.CourcesIdLocation).HasColumnName("COURCES_ID_LOCATIONID");
                entity.Property(e => e.workdue).HasColumnName("workdue");

                //entity.Property(e => e.CourcesIdperiodbydays).HasColumnName("COURCES_PERIODBYDAYS");

                //entity.Property(e => e.CourcesIdTime).HasColumnName("COURCES_TIME");

                //entity.Property(e => e.CourcesStartDate).HasColumnName("COURCES_START_DATE");
                entity.Property(e => e.CourcesStartDate1).HasColumnName("COURCES_START_DATE1");
                entity.Property(e => e.CourcesStartDate2).HasColumnName("COURCES_START_DATE2");
                entity.Property(e => e.CourcesStartDate3).HasColumnName("COURCES_START_DATE3");
                entity.Property(e => e.CourcesStartDate4).HasColumnName("COURCES_START_DATE4");
                entity.Property(e => e.CourcesStartDate5).HasColumnName("COURCES_START_DATE5");
                entity.Property(e => e.CourcesStartDate6).HasColumnName("COURCES_START_DATE6");
                entity.Property(e => e.CourcesStartDate7).HasColumnName("COURCES_START_DATE7");
                entity.Property(e => e.CourcesStartDate8).HasColumnName("COURCES_START_DATE8");

                entity.Property(e => e.CourcesStartDateh).HasColumnName("COURSES_START_DATE_HIJ");

                //entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.Cempid).HasColumnName("CEMPID");

                //entity.Property(e => e.Option).HasColumnName("option");
                //entity.Property(e => e.available).HasColumnName("available");
                //entity.Property(e => e.timefrom).HasColumnName("timefrom");
                //entity.Property(e => e.timeto).HasColumnName("timeto");
               


            });

            modelBuilder.Entity<DepartWithMnagement>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("DepartWithMnagement");
                entity.Property(e => e.CEMPADPRTNO).HasColumnName("CEMPADPRTNO");
                entity.Property(e => e.depcode).HasColumnName("depcode");

                entity.Property(e => e.DEP_NAME).HasColumnName("DEP_NAME");

                entity.Property(e => e.MANAGERID).HasColumnName("MANAGERID");

                entity.Property(e => e.MANAGERNAME).HasColumnName("MANAGERNAME");
                entity.Property(e => e.PARENTID).HasColumnName("PARENTID");
                entity.Property(e => e.mancode).HasColumnName("mancode");

                entity.Property(e => e.PARENTNAME).HasColumnName("PARENTNAME");

                entity.Property(e => e.PARENTMANAGERID).HasColumnName("PARENTMANAGERID");

                entity.Property(e => e.PARENTMANAGERNAME).HasColumnName("PARENTMANAGERNAME");

               


            });

            modelBuilder.Entity<ACourcesIdManagement>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("A_COURCES-MANAGEMENTIN");

                entity.Property(e => e.id).HasColumnName("COURCES_ID_MANAGEMENTIN");

                entity.Property(e => e.name)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_MANAGEMENTIN");
                entity.Property(e => e.ManagerId)
                    .HasMaxLength(250)
                    .HasColumnName("ManagerId");
                entity.Property(e => e.ManagerName)
                 .HasMaxLength(250)
                 .HasColumnName("ManagerName");

                entity.Property(e => e.newcode)
                .HasMaxLength(250)
                .HasColumnName("newcode");
            });

            modelBuilder.Entity<ACourcesOptions>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("A_COURCES_OPTIONS");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("optionch");
            });


            modelBuilder.Entity<NeededComments>(entity =>
            {


                entity.ToTable("neededcomments");

                entity.Property(e => e.id).HasColumnName("offerdetailsid");

                entity.Property(e => e.comments)

                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.offerapproval)

                   .HasColumnName("offerapproval");
            });

            modelBuilder.Entity<Needed1Comments>(entity =>
            {


                entity.ToTable("needed1comments");

                entity.Property(e => e.id).HasColumnName("offerdetailsid");

                entity.Property(e => e.comments)

                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.offerapproval)

                   .HasColumnName("offerapproval");
            });

            modelBuilder.Entity<OfferComments>(entity =>
            {
               

                entity.ToTable("offercomments");

                entity.Property(e => e.id).HasColumnName("offerdetailsid");

                entity.Property(e => e.comments)
                   
                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.offerapproval)

                   .HasColumnName("offerapproval");
            });

            modelBuilder.Entity<OfferComments2>(entity =>
            {


                entity.ToTable("offercomments2");

                entity.Property(e => e.id).HasColumnName("offerdetailsid");

                entity.Property(e => e.comments)

                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.offerapproval)

                   .HasColumnName("offerapproval");
            });


            modelBuilder.Entity<OfferComments3>(entity =>
            {


                entity.ToTable("offercomments3");

                entity.Property(e => e.id).HasColumnName("offerdetailsid");

                entity.Property(e => e.comments)

                    .HasColumnName("offerdetailscomment");

                entity.Property(e => e.offerapproval)

                   .HasColumnName("offerapproval");
            });


            modelBuilder.Entity<ACourcesDeptin>(entity =>
            {
                entity.HasKey(e => e.CourcesIdDeptin0);
                //entity.HasKey(e => e.CourcesIdDeptin);

                entity.ToTable("A_COURCES_DEPTIN");
                entity.Property(e => e.CourcesIdDeptin0).HasColumnName("COURCES_ID_DEPTIN0");
                entity.Property(e => e.CourcesIdDeptin).HasColumnName("COURCES_ID_DEPTIN");

                entity.Property(e => e.CourcesNameDeptin)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_DEPTIN");

                entity.Property(e => e.newcode).HasColumnName("newcode");
            });

            modelBuilder.Entity<loginc>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("loginc");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.userid).HasColumnName("userid");
                entity.Property(e => e.dtimelogin).HasColumnName("dttimelogin");
        
                entity.Property(e => e.ip).HasColumnName("userlastip");
                entity.Property(e => e.comment).HasColumnName("comment");



            });

            modelBuilder.Entity<logind>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("logind");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.userid).HasColumnName("userid");
                entity.Property(e => e.dtimelogin).HasColumnName("dttimelogin");
                entity.Property(e => e.dtimelogout).HasColumnName("dtimelogout");
                entity.Property(e => e.ip).HasColumnName("userlastip");
                entity.Property(e => e.comment).HasColumnName("comment");



            });

            modelBuilder.Entity<MenuModels>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tblSubMenu");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.SubMenuNamear).HasColumnName("SubMenuear");
                entity.Property(e => e.SubMenuNameen).HasColumnName("SubMenueen");
                entity.Property(e => e.ControllerName).HasColumnName("Controller");
                entity.Property(e => e.ActionName).HasColumnName("Action");
                entity.Property(e => e.MainMenuId).HasColumnName("mainmenueid");
                entity.Property(e => e.RoleId).HasColumnName("roleid");
                entity.Property(e => e.mmodule).HasColumnName("mmodule");
                entity.Property(e => e.treeroot).HasColumnName("treeroot");


            });


            modelBuilder.Entity<ACoursesLocation>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("A_COURCES_LOCATIONS");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ACourcesDeptout>(entity =>
            {
                entity.HasKey(e => e.CourcesIdDeptout);

                entity.ToTable("A_COURCES_DEPTOUT");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesNameDeptout)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_DEPTOUT");
            });
            //
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.roleid);

                entity.ToTable("tblRoles");

                entity.Property(e => e.roleid).HasColumnName("Id");

                entity.Property(e => e.rolename)
                    .HasMaxLength(250)
                    .HasColumnName("Roles");
            });
            //
            modelBuilder.Entity<MainMenue>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tblMainMenu");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.mainmenue)
                    .HasMaxLength(250)
                    .HasColumnName("mainmenue");

                entity.Property(e => e.mainarabic)
                   .HasMaxLength(250)
                   .HasColumnName("mainarabic");
            });

            modelBuilder.Entity<NeededRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("NeededRequestTypeId");
                entity.Property(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial).HasColumnName("OfferedRequestTypeIdsOfferedRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestType)

                    .HasColumnName("OfferedRequestType");

                entity.Property(e => e.Offercoursefrom)

                   .HasColumnName("Offercoursefrom");
            });
            modelBuilder.Entity<Needed1RequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("Needed1RequestTypeId");
                entity.Property(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial).HasColumnName("OfferedRequestTypeIdsOfferedRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestType)

                    .HasColumnName("OfferedRequestType");

                entity.Property(e => e.Offercoursefrom)

                   .HasColumnName("Offercoursefrom");
            });




            modelBuilder.Entity<OfferedRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedRequestTypeId");
                entity.Property(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial).HasColumnName("OfferedRequestTypeIdsOfferedRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestType)

                    .HasColumnName("OfferedRequestType");

                entity.Property(e => e.Offercoursefrom)

                   .HasColumnName("Offercoursefrom");
            });

            modelBuilder.Entity<OfferedRequestTypeId2>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedRequestTypeId2");
                entity.Property(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial).HasColumnName("OfferedRequestTypeIdsOfferedRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestType)

                    .HasColumnName("OfferedRequestType");

                entity.Property(e => e.Offercoursefrom)

                   .HasColumnName("Offercoursefrom");
            });



            modelBuilder.Entity<OfferedRequestTypeId3>(entity =>
            {
                entity.HasKey(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedRequestTypeId3");
                entity.Property(e => e.OfferedRequestTypeIdsOfferedRequestTypeIdserial).HasColumnName("OfferedRequestTypeIdsOfferedRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestType)

                    .HasColumnName("OfferedRequestType");

                entity.Property(e => e.Offercoursefrom)

                   .HasColumnName("Offercoursefrom");
            });

            modelBuilder.Entity<NeededDetails>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("NeededDetails");
                entity.Property(e => e.OfferedDetailsSerial).HasColumnName("OfferedDetailsSerial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasColumnName("OfferedRequestFrom");
                entity.Property(e => e.OfferedRequestTo).HasColumnName("OfferedRequestTo");
                entity.Property(e => e.OfferedRequestTo2).HasColumnName("OfferedRequestTo2");
                entity.Property(e => e.OfferedRequestTo3).HasColumnName("OfferedRequestTo3");
                entity.Property(e => e.OfferedRequestTo4).HasColumnName("OfferedRequestTo4");
                entity.Property(e => e.OfferedRequestTo5).HasColumnName("OfferedRequestTo5");
                entity.Property(e => e.OfferedRequestTypeSatus).HasColumnName("OfferedRequestTypeSatus");
                entity.Property(e => e.OfferedRequestNotes).HasColumnName("OfferedRequestNotes");
                entity.Property(e => e.Offeredoption).HasColumnName("Offeredoption");

            });
            modelBuilder.Entity<Needed1Details>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("Needed1Details");
                entity.Property(e => e.OfferedDetailsSerial).HasColumnName("OfferedDetailsSerial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasColumnName("OfferedRequestFrom");
                entity.Property(e => e.OfferedRequestTo).HasColumnName("OfferedRequestTo");
                entity.Property(e => e.OfferedRequestTo2).HasColumnName("OfferedRequestTo2");
                entity.Property(e => e.OfferedRequestTo3).HasColumnName("OfferedRequestTo3");
                entity.Property(e => e.OfferedRequestTo4).HasColumnName("OfferedRequestTo4");
                entity.Property(e => e.OfferedRequestTo5).HasColumnName("OfferedRequestTo5");
                entity.Property(e => e.OfferedRequestTypeSatus).HasColumnName("OfferedRequestTypeSatus");
                entity.Property(e => e.OfferedRequestNotes).HasColumnName("OfferedRequestNotes");
                entity.Property(e => e.Offeredoption).HasColumnName("Offeredoption");

            });




            modelBuilder.Entity<OfferedDetails>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedDetails");
                entity.Property(e => e.OfferedDetailsSerial).HasColumnName("OfferedDetailsSerial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasColumnName("OfferedRequestFrom");
                entity.Property(e => e.OfferedRequestTo).HasColumnName("OfferedRequestTo");
                entity.Property(e => e.OfferedRequestTo2).HasColumnName("OfferedRequestTo2");
                entity.Property(e => e.OfferedRequestTo3).HasColumnName("OfferedRequestTo3");
                entity.Property(e => e.OfferedRequestTo4).HasColumnName("OfferedRequestTo4");
                entity.Property(e => e.OfferedRequestTo5).HasColumnName("OfferedRequestTo5");
                entity.Property(e => e.OfferedRequestTypeSatus).HasColumnName("OfferedRequestTypeSatus");
                entity.Property(e => e.OfferedRequestNotes).HasColumnName("OfferedRequestNotes");
                entity.Property(e => e.Offeredoption).HasColumnName("Offeredoption");

            });
            modelBuilder.Entity<OfferedDetails2>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedDetails2");
                entity.Property(e => e.OfferedDetailsSerial).HasColumnName("OfferedDetailsSerial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasColumnName("OfferedRequestFrom");
                entity.Property(e => e.OfferedRequestTo).HasColumnName("OfferedRequestTo");
                entity.Property(e => e.OfferedRequestTo2).HasColumnName("OfferedRequestTo2");
                entity.Property(e => e.OfferedRequestTo3).HasColumnName("OfferedRequestTo3");
                entity.Property(e => e.OfferedRequestTo4).HasColumnName("OfferedRequestTo4");
                entity.Property(e => e.OfferedRequestTo5).HasColumnName("OfferedRequestTo5");
                entity.Property(e => e.OfferedRequestTypeSatus).HasColumnName("OfferedRequestTypeSatus");
                entity.Property(e => e.OfferedRequestNotes).HasColumnName("OfferedRequestNotes");
                entity.Property(e => e.Offeredoption).HasColumnName("Offeredoption");

            });


            modelBuilder.Entity<OfferedDetails3>(entity =>
            {
                entity.HasKey(e => e.OfferedDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("OfferedDetails3");
                entity.Property(e => e.OfferedDetailsSerial).HasColumnName("OfferedDetailsSerial");

                entity.Property(e => e.COURCES_IDOffered).HasColumnName("COURCES_IDOffered");

                entity.Property(e => e.OfferedRequestFrom).HasColumnName("OfferedRequestFrom");
                entity.Property(e => e.OfferedRequestTo).HasColumnName("OfferedRequestTo");
                entity.Property(e => e.OfferedRequestTo2).HasColumnName("OfferedRequestTo2");
                entity.Property(e => e.OfferedRequestTo3).HasColumnName("OfferedRequestTo3");
                entity.Property(e => e.OfferedRequestTo4).HasColumnName("OfferedRequestTo4");
                entity.Property(e => e.OfferedRequestTo5).HasColumnName("OfferedRequestTo5");
                entity.Property(e => e.OfferedRequestTypeSatus).HasColumnName("OfferedRequestTypeSatus");
                entity.Property(e => e.OfferedRequestNotes).HasColumnName("OfferedRequestNotes");
                entity.Property(e => e.Offeredoption).HasColumnName("Offeredoption");

            });


            modelBuilder.Entity<MasterRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.MasterRequestTypeIdsMasterRequestTypeIdserial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("MasterRequestTypeId");
                entity.Property(e => e.MasterRequestTypeIdsMasterRequestTypeIdserial).HasColumnName("MasterRequestTypeIdsMasterRequestTypeIdserial");

                entity.Property(e => e.COURCES_IDMASTER).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.MasterRequestType)

                    .HasColumnName("MasterRequestType");
            });

            modelBuilder.Entity<MasterDetails>(entity =>
            {
                entity.HasKey(e => e.MasterDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("MasterDetails");

                entity.Property(e => e.COURCES_IDMASTER).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.MasterRequestFrom) .HasColumnName("MasterRequestFrom");
                entity.Property(e => e.MasterRequestTo).HasColumnName("MasterRequestTo");
                entity.Property(e => e.MasterRequestTo2).HasColumnName("MasterRequestTo2");
                entity.Property(e => e.MasterRequestTo3).HasColumnName("MasterRequestTo3");
                entity.Property(e => e.MasterRequestTo4).HasColumnName("MasterRequestTo4");
                entity.Property(e => e.MasterRequestTo5).HasColumnName("MasterRequestTo5");
                entity.Property(e => e.MasterRequestTypeSatus).HasColumnName("MasterRequestTypeSatus");
                entity.Property(e => e.MasterRequestNotes).HasColumnName("MasterRequestNotes");

            });



            //
            modelBuilder.Entity<ACourcesEstimate>(entity =>
            {
                entity.HasKey(e => e.CourcesIdEstimate);

                entity.ToTable("A_COURCES_ESTIMATE");

                entity.Property(e => e.CourcesIdEstimate).HasColumnName("COURCES_ID_ESTIMATE");

                entity.Property(e => e.CourcesNameEstimate)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_ESTIMATE");

                entity.Property(e => e.Range)
                  .HasMaxLength(250)
                  .HasColumnName("Range");
            });

            modelBuilder.Entity<ACourcesMaster>(entity =>
            {
                entity.HasKey(e => e.CourcesIdmaster);

                entity.ToTable("A_COURCES_MASTER");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.Cempid)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPID");

                entity.Property(e => e.CourcesEndDate)
                    .HasColumnType("date")
                    .HasColumnName("COURCES_END_DATE")
                    .HasDefaultValueSql("(getdate())");


                entity.Property(e => e.CourcesStartDateh)
                    //.HasColumnType("date")
                    .HasColumnName("COURSES_START_DATE_HIJ");



                entity.Property(e => e.CourceendDateh)
                    //.HasColumnType("date")
                    .HasColumnName("COURSES_END_DATE_HIJ");




                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesIdDeptin).HasColumnName("COURCES_ID_DEPTIN");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesIdEstimate).HasColumnName("COURCES_ID_ESTIMATE");

                entity.Property(e => e.CourcesIdImagecert).HasColumnName("COURCES_ID_IMAGECERT");

                entity.Property(e => e.CourcesIdImagehr).HasColumnName("COURCES_ID_IMAGEHR");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.CourcesIdType).HasColumnName("COURCES_ID_TYPE");

                entity.Property(e => e.CourcesNumberofdays).HasColumnName("COURCES_NUMBEROFDAYS");

                entity.Property(e => e.CourcesPassRate).HasColumnName("COURCES_PASS_RATE");
                entity.Property(e => e.COURCES_EXCUTION).HasColumnName("COURCES_EXCUTION");

                entity.Property(e => e.CourcesStartDate)
                    .HasColumnType("date")
                    .HasColumnName("COURCES_START_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cemp)
                    .WithMany(p => p.ACourcesMasters)
                    .HasForeignKey(d => d.Cempid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A_COURCES_MASTER_CEMPS");

                entity.HasOne(d => d.Cources)
                    .WithMany(p => p.ACourcesMasters)
                    .HasForeignKey(d => d.CourcesId)
                    .HasConstraintName("FK_A_COURCES_MASTER_A_COURCES_NAME");
            });

            modelBuilder.Entity<AJobsNames>(entity =>
            {
                entity.HasKey(e => e.CourcesId);

                entity.ToTable("A_JOBS_NAME");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME");
            });

            modelBuilder.Entity<ACourcesPrograms>(entity =>
            {
                entity.HasKey(e => e.CourcesId);

                entity.ToTable("A_PROGRAMS_NAME");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME");
            });
            modelBuilder.Entity<ACourcesPrograms1>(entity =>
            {
                entity.HasKey(e => e.CourcesId);

                entity.ToTable("A_PROGRAMS_NAME1");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME");
            });

            modelBuilder.Entity<ACourcesName>(entity =>
            {
                entity.HasKey(e => e.CourcesId);

                entity.ToTable("A_COURCES_NAME");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME");
            });

            modelBuilder.Entity<ACourcesTrainingMethod>(entity =>
            {
                entity.HasKey(e => e.CourcesIdTraining);

                entity.ToTable("A_COURCES_TRAINING_METHOD");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.CourcesNameTraining)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_TRAINING");
            });

            modelBuilder.Entity<ACourcesType>(entity =>
            {
                entity.HasKey(e => e.CourcesIdType);

                entity.ToTable("A_COURCES_TYPE");

                entity.Property(e => e.CourcesIdType).HasColumnName("COURCES_ID_TYPE");

                entity.Property(e => e.CourcesTypeName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_TYPE_NAME");
            });

            modelBuilder.Entity<Cemp>(entity =>
            {
                entity.HasKey(e => e.Cempid);
                entity.ToTable("CEMPS");
               
                entity.Property(e => e.Cempid)
                .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPID");

                entity.Property(e => e.CEMPUSERNO)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPUSERNO");

                entity.Property(e => e.CEMPPASSWRD)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPPASSWRD");
                entity.Property(e => e.CEMPPASSWRD1)
                    //.IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPPASSWRD2");

                entity.Property(e => e.Cemphiringdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CEMPHIRINGDATE");
                entity.Property(e => e.CEMPHIRINGDATEHIJRA)
                   .HasColumnType("date")
                   .HasColumnName("CEMPHIRINGDATEHIJRA");

                entity.Property(e => e.CROLEID)
                   
                   .HasColumnName("CROLEID");
                entity.Property(e => e.cip)

                 .HasColumnName("cip");

                entity.Property(e => e.cbrowser)

                 .HasColumnName("cbrowser");

                entity.Property(e => e.CEMPNO)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPNO");

                entity.Property(e => e.Cemplastupgrade)
                    .HasColumnType("datetime")
                    .HasColumnName("CEMPLASTUPGRADE");

                entity.Property(e => e.CEMPLASTUPGRADEHIJRA)
                  .HasColumnType("date")
                  .HasColumnName("CEMPLASTUPGRADEHIJRA");


                entity.Property(e => e.CEMPNAME)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPNAME");

                entity.Property(e => e.CEMPJOBNAME)
                .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPJOBNAME");

                entity.Property(e => e.CEMPADPRTNO)
                .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPADPRTNO");

                entity.Property(e => e.DEP_NAME)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("DEP_NAME");

                entity.Property(e => e.CLSSNO)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CLSSNO");
                entity.Property(e => e.grade)
                    //.IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("grade");
                entity.Property(e => e.mobileno)
                   //.IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("mobileno");
                entity.Property(e => e.mail)
                //.IsRequired()
                .HasMaxLength(50)
                .HasColumnName("mail");
                entity.Property(e => e.MANAGERID)
                   .IsRequired()
                   .HasMaxLength(250)
                   .HasColumnName("MANAGERID");
                entity.Property(e => e.MANAGERID2)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("MANAGERID2");
                entity.Property(e => e.MANAGERID2id)
               //.IsRequired()
               .HasMaxLength(250)
               .HasColumnName("MANAGERID2id");
                entity.Property(e => e.MANAGERNAME)
                 .IsRequired()
                 .HasMaxLength(250)
                 .HasColumnName("MANAGERNAME");
                entity.Property(e => e.PARENTID)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("PARENTID");
                entity.Property(e => e.PARENTID)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("PARENTID");
                entity.Property(e => e.PARENTNAME)
            .IsRequired()
            .HasMaxLength(250)
            .HasColumnName("PARENTNAME");


             entity.Property(e => e.imagepath)
           .HasMaxLength(250)
           .HasColumnName("imagepath");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
