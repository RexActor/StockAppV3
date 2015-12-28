using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAppV3
{
    public partial class stock : UserControl
    {
        public string status = "Closed";
        TableLayoutPanel leftpanel = new TableLayoutPanel();
        public stock()
        {
            InitializeComponent();
        }

        private void stock_Load(object sender, EventArgs e)
        {

        }
        public TableLayoutPanel layout()
        {

            //main layout in which one holds two seperate layouts - right panel and left panel
            TableLayoutPanel mainLayout = new TableLayoutPanel();

            mainLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            mainLayout.AutoSize = true;
            mainLayout.Size = new Size(1075, 720);
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 865));

            //creating right panel where will be displayed list with workers
            TableLayoutPanel rightpanel = new TableLayoutPanel();
            rightpanel.BackColor = Color.LightCyan;
            rightpanel.Dock = DockStyle.Fill;
            rightpanel.AutoSize = true;

            //creating list of persons from database

            for (int i = 0; i <DatabaseUtility.SelectCount("WorkersTable"); i++)
            {
                

                Label WorkerListName = new Label();
                WorkerListName.Text =DatabaseUtility.getData(i).ToString();
                WorkerListName.AutoSize = true;
                WorkerListName.Click += new EventHandler(CreateWorkerReport);
                WorkerListName.MouseEnter += new EventHandler(mouseOver);
                WorkerListName.MouseLeave += new EventHandler(mouseOff);
                DatabaseUtility.getData(WorkerListName.Text, "stock");
                string workerTooltip;
                workerTooltip = DatabaseUtility.WorkerAge + " years old " + DatabaseUtility.WorkerNationality+ "\nPhone Nr."+DatabaseUtility.WorkerPhoneNr
                    +"\nHave holidays on "+DatabaseUtility.WorkerHolidays
                    +"\nDescription: "+DatabaseUtility.WorkerDescription;

                ToolTip workerToolTip = new ToolTip();
                workerToolTip.SetToolTip(WorkerListName,workerTooltip);
                rightpanel.Controls.Add(WorkerListName, 0, i);
            }


            //creating left panel where will be displayed all information about selected person
           
            leftpanel.AutoSize = true;
            leftpanel.Dock = DockStyle.Fill;
            leftpanel.BackColor = Color.Linen;
            mainLayout.Controls.Add(leftpanel, 0, 0);
            mainLayout.Controls.Add(rightpanel, 1, 0);










            return mainLayout;


        }

        private void mouseOff(object sender, EventArgs e)
        {
            Label sent = (Label)sender;
            sent.ForeColor = Color.Black;
            sent.Font = new Font("Verdana", 8, FontStyle.Regular);
        }

        private void mouseOver(object sender, EventArgs e)
        {
             Label sent = (Label)sender;
            sent.ForeColor = Color.Red;
            sent.Font = new Font("Verdana", 9, FontStyle.Bold);
        }

        private void CreateWorkerReport(object sender, EventArgs e)
        {
            Button updateWorker = new Button();
            updateWorker.Text = "Update";
            updateWorker.BackColor = Color.Azure;
            updateWorker.AutoSize = true;
            updateWorker.Anchor = AnchorStyles.Top;

            updateWorker.Location = new Point(400, -20);
            updateWorker.Click += new EventHandler(updateUserMethod);
            Button deleteWorker = new Button();
            deleteWorker.Text = "Delete";
            deleteWorker.BackColor = Color.Beige;
            deleteWorker.AutoSize = true;
            deleteWorker.Anchor = AnchorStyles.Top;
            deleteWorker.Location = new Point(400, -20);



        
            //loads from which name needs to find in DB
            Label Worker = (Label)sender;
            DatabaseUtility.getData(Worker.Text, "stock");

            //clears old entries in report

            leftpanel.Controls.Clear();

            leftpanel.Location = new Point(30, 299);
            leftpanel.Size = new Size(900, 615);
            //StockTeamInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //Seting up main label (shown in middle of window with Worker name and surname)
            Label Name = new Label();
            Name.Size = new Size(300, 25);
            Name.Location = new Point(300, 10);
            Name.AutoSize = true;
            Name.Anchor = AnchorStyles.Top;
            Name.Font = new Font("Sans Serif", 18);

            Name.Text = DatabaseUtility.WorkerName;

            //adding label to main layout
            leftpanel.Controls.Add(Name);
            leftpanel.Controls.Add(updateWorker);
            leftpanel.Controls.Add(deleteWorker);



            Label cons = new Label();
            Label pros = new Label();

            //editable value labels which ones are changing depending on db values
            Label Age = new Label();
            Label Nationality = new Label();
            Label Salary = new Label();
            Label Description = new Label();
            Label PhoneNumber = new Label();
            Label WorkerContract = new Label();
            Label WorkerHolidays = new Label();
            Label AditionalInfo2 = new Label();



            //fixed value labels
            Label AgeText = new Label();
            Label NationalityText = new Label();
            Label SalaryText = new Label();
            Label DescriptionText = new Label();
            Label PhoneNumberText = new Label();
            Label HolidaysText = new Label();
            Label IplOrAgencyText = new Label();
            Label AditionalInfo = new Label();

            //default label texts - not changing during executing
            AgeText.Text = "Age: ";
            NationalityText.Text = "Nationality: ";
            SalaryText.Text = "Pay Rate: ";
            DescriptionText.Text = "Description: ";
            PhoneNumberText.Text = "Phone Nr.: ";
            HolidaysText.Text = "Holidays:";
            IplOrAgencyText.Text = "Ipl/Agency?";
            AditionalInfo.Text = "Other info";


            //Setting up label size and font
            Age.Size = new Size(200, 25);
            Age.Font = new Font("Sans Serif", 10);
            Nationality.Size = new Size(200, 25);
            Nationality.Font = new Font("Sans Serif", 10);
            Salary.Size = new Size(200, 25);
            Salary.Font = new Font("Sans Serif", 10);
            Description.Size = new Size(500, 25);
            Description.Font = new Font("Sans Serif", 10);
            PhoneNumber.Size = new Size(200, 25);
            PhoneNumber.Font = new Font("Sans Serif", 10);





            //pulls data from DB and assign values to labels
            Description.Text = DatabaseUtility.WorkerDescription;
            Age.Text = DatabaseUtility.WorkerAge;
            Nationality.Text = DatabaseUtility.WorkerNationality;
            Salary.Text = DatabaseUtility.WorkerPayRate;
            PhoneNumber.Text = DatabaseUtility.WorkerPhoneNr;
            WorkerHolidays.Text = DatabaseUtility.WorkerHolidays;
            WorkerContract.Text = DatabaseUtility.WorkerIplOrAgency;



            //creates basic information layout
            TableLayoutPanel BasicWorkerInformation = new TableLayoutPanel();
            BasicWorkerInformation.ColumnCount = 4;
            BasicWorkerInformation.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            BasicWorkerInformation.BackColor = Color.FromArgb(0, 153, 153);
            BasicWorkerInformation.Size = new Size(885, 120);
            BasicWorkerInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            BasicWorkerInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            BasicWorkerInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            BasicWorkerInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));



            Label AdditinalInfoHeader = new Label();
            AdditinalInfoHeader.Text = "Additional Information";
            AdditinalInfoHeader.AutoSize = true;
            AdditinalInfoHeader.Font = new Font("Sans Serif", 18);
            AdditinalInfoHeader.Anchor = AnchorStyles.Top;

            TableLayoutPanel flagSector = new TableLayoutPanel();
            //flagSector.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            flagSector.Anchor = AnchorStyles.Top;
            flagSector.Size = new Size(885, 60);
            flagSector.BackColor = Color.FromArgb(255, 77, 0);


            //creates addutional information layout
            TableLayoutPanel AdditionalWorkerInfoMain = new TableLayoutPanel();
            //AdditionalWorkerInfoMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            AdditionalWorkerInfoMain.Size = new Size(885, 380);
            //AdditionalWorkerInfoMain.BackColor = Color.Beige;
            //AdditionalWorkerInfoMain.Anchor = AnchorStyles.Bottom;

            TableLayoutPanel AdditionalWorkerInfoProsCons = new TableLayoutPanel();
            //AdditionalWorkerInfoProsCons.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            AdditionalWorkerInfoProsCons.BackColor = Color.Wheat;
            //AdditionalWorkerInfoProsCons.Padding.Left = 20;
            AdditionalWorkerInfoProsCons.Size = new Size(880, 340);
            AdditionalWorkerInfoProsCons.Anchor = AnchorStyles.Left;
            AdditionalWorkerInfoProsCons.ColumnCount = 2;
            AdditionalWorkerInfoProsCons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            AdditionalWorkerInfoProsCons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            AdditionalWorkerInfoMain.Controls.Add(AdditinalInfoHeader);
            AdditionalWorkerInfoMain.Controls.Add(AdditionalWorkerInfoProsCons);

           

            pros.AutoSize = true;
            cons.AutoSize = true;
            pros.Anchor = AnchorStyles.Top;
            cons.Anchor = AnchorStyles.Top;
            cons.Font = new Font("sans serif", 16, FontStyle.Underline);
            pros.Font = new Font("sans serif", 16, FontStyle.Underline);

            cons.Text = "Cons";
            pros.Text = "Pros";

            AdditionalWorkerInfoProsCons.Controls.Add(cons);

            AdditionalWorkerInfoProsCons.Controls.Add(pros, 1, 0);

            foreach (string s in DatabaseUtility.split(DatabaseUtility.WorkerCons, ','))
            {

                Label conresult = new Label();
                conresult.AutoSize = true;
                conresult.Anchor = AnchorStyles.Top;
                conresult.Text = s + "\n";
                AdditionalWorkerInfoProsCons.RowCount = 4;
                AdditionalWorkerInfoProsCons.Controls.Add(conresult, 0, 1);

            }
            foreach (string s in DatabaseUtility.split(DatabaseUtility.WorkerPros, ','))
            {
                //int counter = 1;
                Label proresult = new Label();
                proresult.Anchor = AnchorStyles.Top;
                proresult.AutoSize = true;
                proresult.Text = s + "\n";

                AdditionalWorkerInfoProsCons.Controls.Add(proresult, 1, 1);

            }






            BasicWorkerInformation.Controls.Add(AgeText);//Adds "Age" text in 1 column and 1 row
            BasicWorkerInformation.Controls.Add(Age, 1, 0); //Pulls data from DB and adds result in 2 collumn 1 row

            BasicWorkerInformation.Controls.Add(DescriptionText, 2, 1);//adds "Description" text in 3 column 2 row
            BasicWorkerInformation.Controls.Add(Description, 3, 1); //pulls data from DB and adds result in 4 column 2 row

            BasicWorkerInformation.Controls.Add(NationalityText, 0, 1);//adds "nationality" text in 1 column 2 row
            BasicWorkerInformation.Controls.Add(Nationality, 1, 1);//pulls data from DB and adds result in 2 column 2 row

            BasicWorkerInformation.Controls.Add(SalaryText, 2, 0); //adds "payrate" text in 3 column and 1 row
            BasicWorkerInformation.Controls.Add(Salary, 3, 0);//pulls data from DB and adds result in 4 column 1 row

            BasicWorkerInformation.Controls.Add(PhoneNumberText, 0, 3);//adds "Phone Nr" text in 1 column 4 row
            BasicWorkerInformation.Controls.Add(PhoneNumber, 1, 3);//pulls data from DB and adds result in 2 column 4 row

            BasicWorkerInformation.Controls.Add(HolidaysText, 0, 2);//adds "Holidays" text in 1 column 3 row
            BasicWorkerInformation.Controls.Add(WorkerHolidays, 1, 2);//pulls data from DB and adds result in 2 column 3 row

            BasicWorkerInformation.Controls.Add(IplOrAgencyText, 2, 2);//Adds "Ipl/Agency" text in 3 column 3 row
            BasicWorkerInformation.Controls.Add(WorkerContract, 3, 2);//pulls data from DB and adds result in 4 column 3 row

            BasicWorkerInformation.Controls.Add(AditionalInfo, 2, 3); //Adds "Other info" text in 3 column 4 row
            BasicWorkerInformation.Controls.Add(AditionalInfo2, 3, 3); //pulls data from DB and adds result in 4 column 4 row

            leftpanel.Controls.Add(BasicWorkerInformation); //adds Basic Worker Information layout
            if (DatabaseUtility.WorkerFlag == true)
            {
                leftpanel.Controls.Add(flagSector);
            }

            leftpanel.Controls.Add(AdditionalWorkerInfoMain);  //adds Additional Information layout


        }

        private void updateUserMethod(object sender, EventArgs e)
        {
            updateUser update = new updateUser();
            update.ShowDialog();
        }
    }
}
