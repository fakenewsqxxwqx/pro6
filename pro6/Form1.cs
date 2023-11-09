using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var school = new School { Name = this.textBox1.Text };
                school.Classes = new List<Class>()
                {
                    new Class{ Name = this.textBox2.Text }
                };
                school.Classes[-1].Students = new List<Student>()
                {
                    new Student{Name = this.textBox3.Text}
                };
                db.Schools.Add(school);
                db.SaveChanges();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var student= db.Students.SingleOrDefault(s => s.StudentId.Equals(this.textBox10.Text));
                student.Name = this.textBox1.Text;
                db.SaveChanges();
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var log = db.Logs;
                foreach(var item in log)
                {
                    this.textBox6.Text += item.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var student= db.Students.SingleOrDefault(s=>s.StudentId.Equals(this.textBox4.Text));
                this.textBox5.Text = student.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var student = db.Students.SingleOrDefault(s => s.StudentId.Equals(this.textBox4.Text));
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}
