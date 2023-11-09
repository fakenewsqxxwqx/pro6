using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace pro6
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class Model1 : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Model1”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“pro6.Model1”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Model1”
        //连接字符串。
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Model1>());
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Log> Logs { get; set; }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public List<Class> Classes { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }

        public School School { get; set; }
        public List<Student> Students { get; set; } 
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }

    public class Log
    {
        public int LogId { get; set; } 
        public DateTime LogDate { get; set; }
        public string Operator { get; set; } 
    }
}