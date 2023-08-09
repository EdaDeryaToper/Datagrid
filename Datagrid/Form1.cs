using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Datagrid
{
    public partial class Form1 : Form
    {
        private DataModel[] jsonData;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadJsonData();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "İşlemler";
            buttonColumn.Name = "btnColumn";
            buttonColumn.Text = "Görüntüle";
            buttonColumn.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.Columns.Insert(0, buttonColumn); // İlk sütuna ekle


            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    DataGridViewImageCell cell = new DataGridViewImageCell();
            //    cell.Value = Image.FromFile("C:\\Users\\eda_t\\Github\\Datagrid\\Datagrid\\car.png"); // Düğme için kullanılacak görüntüyü belirtin
                
            //    dataGridView1.Rows[i].Cells["btnColumn"] = cell;
            //}
           
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }
        private void LoadJsonData()
        {
            string jsonFilePath = "C:\\Users\\eda_t\\Github\\Datagrid\\Datagrid\\data.json";

            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                var jsonData = JsonConvert.DeserializeObject<DataModel[]>(jsonContent);

                dataGridView1.DataSource = jsonData;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0 && e.ColumnIndex == 0) // İlk sütun (düğme sütunu) tıklamasını kontrol et
            //{
            //    int rowIndex = e.RowIndex;
            //    DataModel selectedData = jsonData[rowIndex]; // Seçili satırın verileri

            //    textBox1.Text = selectedData.CompanyName;
            //    textBox2.Text = selectedData.City;

            //}
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["btnColumn"].Index) // İlk sütun (düğme sütunu) tıklamasını kontrol et
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string property1Value = selectedRow.Cells[1].Value.ToString();
                string property2Value = selectedRow.Cells[2].Value.ToString();
                string property3Value = selectedRow.Cells[3].Value.ToString();
                string property4Value = selectedRow.Cells[4].Value.ToString();

                textBox1.Text = property1Value;
                textBox2.Text = property2Value;
                textBox3.Text = property3Value;
                textBox4.Text = property4Value;

            }
        }

        

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            
        }
    }
}
