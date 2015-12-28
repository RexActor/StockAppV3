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
    public partial class Form1 : Form
    {

        //Declare Variables
       public  TabControl layout = new TabControl();
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private Condition condition = new Condition();
        private stock stock = new stock();
        private adjustments adjustments = new adjustments();
        private holidays holidays = new holidays();
        private rota rota = new rota();



        public Form1()
        {
            InitializeComponent();
            this.Text = "Stock Control Line Leader Application";
            this.Size = new Size(1100, 800);
            //disable ability to resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainLayout();

        }

       public void mainLayout()
        {
            
           
            layout.Size = new Size(ClientSize.Width, ClientSize.Height);
            layout.SizeMode = TabSizeMode.Fixed;
           
            

            this.tabPage1 = new TabPage();

            this.tabPage2 = new TabPage();

            this.tabPage3 = new TabPage();

            this.tabPage4 = new TabPage();

            this.tabPage5 = new TabPage();
            this.tabPage6 = new TabPage();
            this.tabPage7 = new TabPage();
            this.tabPage8 = new TabPage();

            this.tabPage1.Controls.Add(stock.layout());
           
            

            tabPage1.Text = "Stock Control (" + stock.status+ ")";
            tabPage1.Size = new Size(ClientSize.Width, ClientSize.Height);
            tabPage2.Text = "Condition (" + condition.status + ")";
            tabPage3.Text = "Adjustments (" + adjustments.status + ")";
            tabPage4.Text = "Holidays (" + holidays.status + ")";
            tabPage5.Text = "Rota (" + rota.status + ")";
            tabPage6.Text = "Information (" + stock.status + ")";
            tabPage7.Text = "Debug (" + stock.status + ")";
            tabPage8.Text = "Top Secret (" + stock.status + ")";

            


            layout.TabPages.AddRange(new TabPage[] { tabPage1, tabPage2, tabPage3, tabPage4, tabPage5,tabPage6,tabPage7,tabPage8 });

            int tabcount = layout.TabPages.Count;

            layout.ItemSize = new Size((ClientSize.Width /tabcount)-1, 30);
            Controls.Add(layout);

            layout.Visible = true;
            

        }
    }
}
