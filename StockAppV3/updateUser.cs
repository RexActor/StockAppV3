using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAppV3
{
    public partial class updateUser : Form
    {
        public updateUser()
        {
            InitializeComponent();
        }

        private void updateUser_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 500);
            this.BackColor = Color.SteelBlue;
           
            Layout();

        }
        private void Layout()
        {
            Button close = new Button();
            close.Click += new EventHandler(closeForm);
            close.Text = "Close Form";
            

            TableLayoutPanel mainPanel = new TableLayoutPanel();

            mainPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            mainPanel.Size = new Size(ClientSize.Width-30, ClientSize.Height-30);
            mainPanel.BackColor = Color.White;
            mainPanel.Anchor = AnchorStyles.Top;
            mainPanel.Location = new Point(10, 10);
            mainPanel.ColumnCount = 2;
            mainPanel.RowCount = 11;

            Label name = new Label();
            Label age = new Label();
            Label phone = new Label();
            Label description = new Label();
            Label contract = new Label();
            Label nationality = new Label();
            Label payrate = new Label();
            Label holidays = new Label();
            Label cons = new Label();
            Label pros = new Label();
            Label department = new Label();
            name.AutoSize = true;
            age.AutoSize = true;
            phone.AutoSize = true;
            description.AutoSize = true;
            contract.AutoSize = true;
            nationality.AutoSize = true;
            payrate.AutoSize = true;
            holidays.AutoSize = true;
            cons.AutoSize = true;
            pros.AutoSize = true;
            department.AutoSize = true;





            name.Text = "Name";
            age.Text = "Age";
            phone.Text = "Phone Nr.";
            description.Text = "Description";
            contract.Text = "Contract";
            nationality.Text = "Nationality";
            payrate.Text = "PayRate";
            holidays.Text = "Holidays";
            cons.Text = "Cons";
            pros.Text = "Pros";
            department.Text = "Departments";



            Controls.Add(mainPanel);
            mainPanel.Controls.Add(name,0,0);
            mainPanel.Controls.Add(phone, 0, 1);
            mainPanel.Controls.Add(age, 0, 2);
            mainPanel.Controls.Add(description, 0, 3);
            mainPanel.Controls.Add(contract, 0, 4);
            mainPanel.Controls.Add(nationality, 0, 5);
            mainPanel.Controls.Add(payrate, 0, 6);
            mainPanel.Controls.Add(holidays, 0, 7);
            mainPanel.Controls.Add(cons, 0, 8);
            mainPanel.Controls.Add(pros, 0, 9);
            mainPanel.Controls.Add(department, 0, 10);
            mainPanel.Controls.Add(close,1,11);
            for (int i = 0; i < 11; i++)
            {

               
                TextBox update = new TextBox();
                update.Anchor = AnchorStyles.Left;

                update.Text = DatabaseUtility.WorkerName;

                update.Scale(new SizeF(2, 2));
                mainPanel.Controls.Add(update, 1, i);


            }





        }

        private void closeForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
