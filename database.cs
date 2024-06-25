using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OperationRoomControlPanelV1._1._0.Class
{
    class database
    {

        static string path = @"Provider=Microsoft.ACE.OleDb.12.0;Data Source = " + Application.StartupPath + "/DatabaseORCP.accdb";

        public static DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            try
            {
                OleDbConnection connection = new OleDbConnection(path);

                connection.Open();
                OleDbCommand command1 = new OleDbCommand("Select * from veritabani", connection);
                OleDbDataAdapter register1 = new OleDbDataAdapter(command1);
                register1.Fill(table);
                connection.Close();
            }

            catch (OleDbException ex)
            {
                MessageBox.Show(" " + ex);
            }

            return table;
        }

        public static void SetDataTable(int[] dataSet, string IP, string sifre, string NO)
        {
            OleDbCommand command2 = new OleDbCommand(); 
            OleDbCommand command3 = new OleDbCommand(); 
            OleDbCommand command4 = new OleDbCommand(); 
            OleDbCommand command5 = new OleDbCommand(); 

            OleDbConnection connection = new OleDbConnection(path);
            connection.Open();

            //command2 = new OleDbCommand();
            command2.Connection = connection;
            command2.CommandText = "update veritabani set O2L = @O2DusukAlarmSetDeger , O2H = @O2YuksekAlarmSetDeger , N2OL = @N2ODusukAlarmSetDeger , N2OH = @N2OYuksekAlarmSetDeger, H4L = @H4DusukAlarmSetDeger , H4H = @H4YuksekAlarmSetDeger , H7L = @H7DusukAlarmSetDeger , H7H = @H7YuksekAlarmSetDeger , VACL = @VACDusukAlarmSetDeger, CO2L = @CO2DusukAlarmSetDeger , CO2H = @CO2YuksekAlarmSetDeger ";
            command2.Parameters.AddWithValue("@O2DusukAlarmSetDeger", dataSet[0]);
            command2.Parameters.AddWithValue("@O2YuksekAlarmSetDeger ", dataSet[1]);
            command2.Parameters.AddWithValue("@N2ODusukAlarmSetDeger ", dataSet[2]);
            command2.Parameters.AddWithValue("@N2OYuksekAlarmSetDeger", dataSet[3]);
            command2.Parameters.AddWithValue("@H4DusukAlarmSetDeger", dataSet[4]);
            command2.Parameters.AddWithValue("@H4YuksekAlarmSetDeger ", dataSet[5]);
            command2.Parameters.AddWithValue("@H7DusukAlarmSetDeger ", dataSet[6]);
            command2.Parameters.AddWithValue("@H7YuksekAlarmSetDeger", dataSet[7]);
            command2.Parameters.AddWithValue("@VACDusukAlarmSetDeger ", dataSet[8]);
            command2.Parameters.AddWithValue("@CO2DusukAlarmSetDeger ", dataSet[9]);
            command2.Parameters.AddWithValue("@CO2YuksekAlarmSetDeger", dataSet[10]);
            command2.ExecuteNonQuery();

            //command3 = new OleDbCommand();
            command3.Connection = connection;
            command3.CommandText = "update veritabani set TEMPL = @sicaklikDusukAlarmSetDeger , TEMPH = @sicaklikYuksekAlarmSetDeger , NEML = @nemDusukAlarmSetDeger , NEMH = @nemYuksekAlarmSetDeger, FARKBASINCL = @farkBasincDusukAlarmSetDeger , FARKBASINCH = @farkBasincYuksekAlarmSetDeger , HEPAFILTRE = @hepaFiltreKirliAlarmSetDeger ";
            command3.Parameters.AddWithValue("@sicaklikDusukAlarmSetDeger", dataSet[11]);
            command3.Parameters.AddWithValue("@sicaklikYuksekAlarmSetDeger ", dataSet[12]);
            command3.Parameters.AddWithValue("@nemDusukAlarmSetDeger ", dataSet[13]);
            command3.Parameters.AddWithValue("@nemYuksekAlarmSetDeger", dataSet[14]);
            command3.Parameters.AddWithValue("@farkBasincDusukAlarmSetDeger", dataSet[15]);
            command3.Parameters.AddWithValue("@farkBasincYuksekAlarmSetDeger ", dataSet[16]);
            command3.Parameters.AddWithValue("@hepaFiltreKirliAlarmSetDeger ", dataSet[17]);
            command3.ExecuteNonQuery();


            //command4 = new OleDbCommand();
            command4.Connection = connection;
            command4.CommandText = "update veritabani set ALARMO2 = @O2Alarm , ALARMN2O = @N2OAlarm , ALARMH4 = @H4Alarm , ALARMH7 = @H7Alarm , ALARMCO2 = @CO2Alarm , ALARMVAC = @VACAlarm , TEMPALARM = @sicaklikAlarm, NEMALARM = @nemAlarm , FARKBASINCALARM = @farkBasincAlarm, HEPAFILTREALARM = @hepaFiltreAlarm ";
            command4.Parameters.AddWithValue("@O2Alarm ", dataSet[18]);
            command4.Parameters.AddWithValue("@N2OAlarm ", dataSet[19]);
            command4.Parameters.AddWithValue("@H4Alarm ", dataSet[20]);
            command4.Parameters.AddWithValue("@H7Alarm ", dataSet[21]);
            command4.Parameters.AddWithValue("@VACAlarm ", dataSet[22]);
            command4.Parameters.AddWithValue("@sicaklikAlarm", dataSet[23]);
            command4.Parameters.AddWithValue("@nemAlarm", dataSet[24]);
            command4.Parameters.AddWithValue("@farkBasincAlarm ", dataSet[25]);
            command4.Parameters.AddWithValue("@hepaFiltreAlarm ", dataSet[26]);
            command4.Parameters.AddWithValue("@CO2Alarm ", dataSet[27]);
            command4.ExecuteNonQuery();
              
            //command5 = new OleDbCommand();
            command5.Connection = connection;
            command5.CommandText = "update veritabani set SERVERIP = @serverIP , SIFRE = @sipSifre , TELEFONNO = @sipTelefoNo , MODBUSID = @modbusID , MODBUSBR = @modbusBR , ISTEMTEMP = @istemTemp , ISTEMHUM = @istemHum , DIL = @dil, O2Enable=@O2Enable, N2OEnable=@N2OEnable, H4Enable=@H4Enable, H7Enable=@H7Enable, CO2Enable=@CO2Enable, VACEnable=@VACEnable";
            command5.Parameters.AddWithValue("@serverIP", IP);
            command5.Parameters.AddWithValue("@sipSifre", sifre);
            command5.Parameters.AddWithValue("@sipTelefoNo", NO);
            command5.Parameters.AddWithValue("@modbusID", dataSet[28]);
            command5.Parameters.AddWithValue("@modbusBR", dataSet[29]);
            command5.Parameters.AddWithValue("@istemTemp", dataSet[30]);
            command5.Parameters.AddWithValue("@istemHum", dataSet[31]);
            command5.Parameters.AddWithValue("@dil", dataSet[32]);
            command5.Parameters.AddWithValue("@O2Enable", dataSet[33]);
            command5.Parameters.AddWithValue("@N22Enable", dataSet[34]);
            command5.Parameters.AddWithValue("@H4Enable", dataSet[35]);
            command5.Parameters.AddWithValue("@H7Enable", dataSet[36]);
            command5.Parameters.AddWithValue("@CO2Enable", dataSet[37]);
            command5.Parameters.AddWithValue("@VACEnable", dataSet[38]);


            command5.ExecuteNonQuery();
            
            connection.Close();

        }
    }
}
