using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wrapmodeList
{
    public partial class Form1 : Form
    {
       //TODO добавить два столба в dataTable из прошлого моего проетка, который я скинул (фильтр методов и контекста)
       //настроить стиль отображения, чтобы нельзя было отличить датагрид от листбокса (опционально, но думаю справишься)
       //если будут строки со словами, длина которых превышает ширину датагрида пытаться обработать их другим методом или просто довольствоваться еще одним скролбаром снизу(на твое усмотрение)

        DataSet DS;
        DataTable DT;
        int counter;
        public Form1()
        {
            InitializeComponent();
            DS = new DataSet();
            DT = new DataTable("currentMethods");
            counter = 2;
            //создание dataTable, в нашем случае добавишь уже в существующий новый столбец, а вернее два, которые будут отвечать за фильтры
            DataColumn DC = new DataColumn("Method", typeof(string));
            DT.Columns.Add(DC);
            DS.Tables.Add(DT);
            DataRow dr = DT.NewRow();
            dr["Method"] = "method1";
            DT.Rows.Add(dr);

            dataGridView1.DataSource = DT; //привязка данных

            //смотри свойства датагрида, я убрал хедеры строк и столбоц и сделал перенос по словам

        }
        
        internal class CurrentMethod
        {
            public string method { get; set; }
        }

        private void button1_Click(object sender, EventArgs e) //добавить
        {
            DataRow dr = DT.NewRow();
            dr["Method"] = "yet another some long-long method name that we have to use"+counter;
            DT.Rows.Add(dr);
            counter++;
        }

        private void button2_Click(object sender, EventArgs e) //удалить
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                DT.Rows.RemoveAt(index);
            }
            
        }
    }
  
        
}
