using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university_scheduler
{
    public partial class HomeScreenWithTable : Form
    {
        public HomeScreenWithTable()
        {
            InitializeComponent();
        }

        private void HomeScreenWithTable_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(env.db_con_str))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM program", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    cn.Close();
                    genExcel(dt);
                }
            }
        }

        void genExcel(DataTable dt){
            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            //Header
            for(int i =0; i<dt.Columns.Count; i++){
                ws.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            }

            for (int i = 0; i < dt.Rows.Count; i++) {
                for (int j = 0; j < dt.Columns.Count; j++){
                    ws.Cells[i+2, j + 1] = dt.Rows[i][j].ToString();
                }
            }
            ws.Name = "Godz";

            wb.SaveAs(@"D:\welcome.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            wb.Close(true, misValue, misValue);
            app.Quit();
        }
    }
}
