using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Concrete.EntityFramework
{
    public class FormContext : DbContext
    {
        public virtual DbSet<User> USER { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<Form> FORM { get; set; }
        public virtual DbSet<Question> QUESTION { get; set; }
        public virtual DbSet<QuestionType> QUESTIONTYPE { get; set; }
        public virtual DbSet<Choice> CHIOCE { get; set; }
        public virtual DbSet<Answer> ANSWER { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=OMER-ESER\SQLEXPRESS;Initial Catalog=FORMSYS;persist security info=True;user id=sa;password=123456;");
            }
        }
    }
}
