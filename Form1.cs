using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entitylabdbfirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndepdisplay_Click(object sender, EventArgs e)
        {
            EmploymentEntities1 epentitys = new EmploymentEntities1();


            
            
                listBox1.Items.Clear();
                comboBox2.Items.Clear();
                var items = from i in epentitys.Departments select i;
                foreach (var i in items)
                {
                    listBox1.Items.Add(i.id + i.deptName);
                    comboBox2.Items.Add(i.id);

                }
                
           
           
            
        }

        private void btnempdisplay_Click(object sender, EventArgs e)
        {
            EmploymentEntities1 epentitys = new EmploymentEntities1();




            listBox1.Items.Clear();
            comboBoxemployee.Items.Clear();
            var items = from i in epentitys.Employees select i;
            foreach (var i in items)
            {
                listBox1.Items.Add(i.id + "\t"+i.name + "\t" +i.Id_dept);
                comboBoxemployee.Items.Add(i.id);
               
                

            }
        }

        private void btndepadd_Click(object sender, EventArgs e)
        {
            EmploymentEntities1 ent = new EmploymentEntities1();
            Department dep = new Department();
            dep.id = int.Parse(textBoxdepid.Text);
            dep.deptName = textBoxdepartmentanme.Text;
            ent.Departments.Add(dep);
            ent.SaveChanges();
            textBoxdepid.Text = textBoxdepartmentanme.Text = " ";
        }

        private void btnempadd_Click(object sender, EventArgs e)
        {
            EmploymentEntities1 ent = new EmploymentEntities1();
            Employee emp = new Employee();
            emp.id = int.Parse(textBoxid.Text);
           emp.name = textBoxempname.Text;
            emp.Id_dept=int.Parse(textBox1.Text);
            ent.Employees.Add(emp);
            ent.SaveChanges();
            textBox1.Text = textBoxempname.Text =textBoxid.Text= " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmploymentEntities1 ent = new EmploymentEntities1();
            int ID = int.Parse(comboBox2.Text);
            Department retrieve = ent.Departments.Find(ID);
            if(ID != null)
            {
                textBoxdepid.Text = retrieve.id.ToString();
                textBoxdepartmentanme.Text = retrieve.deptName;
                listBox1.Items.Clear();
                foreach(var d in retrieve.Employees)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(d.name);
                }
            }
        }

        private void comboBoxemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmploymentEntities1 ent = new EmploymentEntities1();
            int ID = int.Parse(comboBoxemployee.Text);
            Employee retrieve = ent.Employees.Find(ID);
            if(ID != null)
            {
                textBoxid.Text = retrieve.id.ToString();
                textBoxempname.Text = retrieve.name;
                textBox1.Text = retrieve.Id_dept.ToString();
                foreach(var i in retrieve.name)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(i);
                }
            }
        }

        private void btndepupdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBoxdepid.Text);
            EmploymentEntities1 emp = new EmploymentEntities1();

            var depart = emp.Departments.Where(d => d.id == ID).Select(d => d).First();
            
            depart.deptName = textBoxdepartmentanme.Text;
            
            emp.SaveChanges();
        }

        private void btndepdelete_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(textBoxdepid.Text);
            EmploymentEntities1 emp = new EmploymentEntities1();

            var depart = emp.Departments.Where(d => d.id == ID).Select(d => d).First();
            emp.Departments.Remove(depart);
            emp.SaveChanges();
        }

        private void btnempupdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBoxid.Text);
            EmploymentEntities1 emp = new EmploymentEntities1();

            var empls = emp.Employees.Where(d => d.id == ID).Select(d => d).First();
            empls.name = textBoxempname.Text;
            empls.Id_dept = int.Parse(textBox1.Text);
            emp.SaveChanges();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBoxid.Text);
            EmploymentEntities1 emp = new EmploymentEntities1();

            var empls = emp.Employees.Where(d => d.id == ID).Select(d => d).First();
            emp.Employees.Remove(empls);
            emp.SaveChanges();
        }
    }
}
