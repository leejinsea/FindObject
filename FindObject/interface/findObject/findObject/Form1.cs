using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace findObject
{
    public partial class Form1 : Form
    {
        DataTable allDataTable = new DataTable();
        DataTable selectDataTable = new DataTable();


        private String timeScale(String Time)
        {
            string cmd = "";
            int oneHourBefore, oneHourLater; // 2021-09-25-10
            if(Time != "ALL")
            {

                int nowhour = Convert.ToInt32(Time.Substring(11));
                oneHourBefore = nowhour - 1;
                oneHourLater = nowhour + 1;
                string ymd = "";
                for (int i = 0; i < (Time.Length-2); ++i)
                {
                    ymd += Time[i];

                }

                cmd = "(Time1 = \"" + ymd + Convert.ToString(oneHourBefore) + "\" OR " + "Time1 = \"" + Time +"\"" + " OR " + " Time1 = \"" + ymd + Convert.ToString(oneHourLater)+"\")";
                // cmd 결과값 AND Time1 BETWEEN 'oneHourBefore' AND 'oneHourLater'
                

            }
            return cmd;
        }

        private String objectScale(String Objects)
        {
            string cmd = "";

            char[] delimiterChars = {' ', ',','\r'};
            string[] Object = Objects.Split(delimiterChars);
            Object = Object.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (Object.Length == 1)
            {
                cmd = "Tag" + " " + "LIKE" + " '%" + Object[0] + "%'";
                // cmd = Tag LIKE '%Object%'
            }
            else if (Object.Length > 1)
            {
                string objectgroup = "";

                for (int objectcnt = 0; objectcnt < Object.Length; ++objectcnt)
                {
                    objectgroup += Object[objectcnt];
                    if(objectcnt != (Object.Length-1))
                    {
                        objectgroup += "|";
                    }
                    // objectgroup 결과값 Object1|Object2|...
                }

                cmd = "Tag" + " " + "REGEXP" + " '" + objectgroup + "'";
                // cmd 결과값 OBJECT REGEXP 'Object1|Object2|...'

            }


            return cmd;
        }

        public Form1()
        {
            InitializeComponent();
            // 프로그램 내 table column 생성
            allDataTable.Columns.Add("CamID", typeof(string));
            allDataTable.Columns.Add("Time1", typeof(string));
            allDataTable.Columns.Add("Time2", typeof(string));
            allDataTable.Columns.Add("Tag", typeof(string));
            selectDataTable.Columns.Add("CamID", typeof(string));
            selectDataTable.Columns.Add("Time1", typeof(string));
            selectDataTable.Columns.Add("Time2", typeof(string));
            selectDataTable.Columns.Add("Tag", typeof(string));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable timedatatable = new DataTable();
            timedatatable.Columns.Add("Time1", typeof(string));



            // 서버 datatable 에 있는 값 가져오기
            using (MySqlConnection connection = new MySqlConnection("Server=192.168.1.139;Port=3306;Database=stray_db;Uid=minki;Pwd=1q2w3e4r."))
            {
                try//예외 처리
                {
                    connection.Open();
                    string sql = "SELECT * FROM CCTV";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader dbtable = cmd.ExecuteReader();
                    while (dbtable.Read())
                    {
                        allDataTable.Rows.Add(dbtable["CamID"], dbtable["Time1"], dbtable["Time2"], dbtable["Tag"]);
                    }
                    dbtable.Close();

                    // 서버에 있는 시간 값, 중복 제외 후 값 가져오기
                    sql = "SELECT DISTINCT TIME1 FROM CCTV";
                    MySqlCommand cmd2 = new MySqlCommand(sql, connection);
                    MySqlDataReader timetable = cmd2.ExecuteReader();

                    while (timetable.Read())
                    {
                        timedatatable.Rows.Add(timetable["Time1"]);
                    }
                    timetable.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
            }

            timedatatable.DefaultView.Sort = "Time1";
            dataGridViewAllData.DataSource = allDataTable;
            //dataGridViewSelectedData.DataSource = selectDataTable;

            // 시간값 combobox에 대입
            for (int i = 0; i < timedatatable.Rows.Count; i++)
            {
                string datatime = timedatatable.Rows[i]["Time1"].ToString();
                comboBoxSelectTime.Items.Add(datatime);
            }

            comboBoxSelectTime.SelectedIndex = 0;

            // 사진 불러 띄우기
            pictureBoxMap.Load(@"C:\gongdae.png");


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string check = "";
            selectDataTable.Rows.Clear();
            listBoxCamID.Items.Clear();
            
            // 검색 데이터 받은 뒤 Selectedgridbox에 표시, 샤용된 camid 확인하여 대응되는 위치 사진 위 표시
            using (MySqlConnection connection = new MySqlConnection("Server=192.168.1.139;Port=3306;Database=stray_db;Uid=minki;Pwd=1q2w3e4r."))
            {

                try//예외 처리
                {

                    string sql = "SELECT * FROM CCTV";
                    string command = "";

                    command = " Where " + objectScale(textBoxInputObject.Text.ToString());

                    if (command == " Where ")
                    {
                        command += timeScale(comboBoxSelectTime.SelectedItem.ToString());
                    }
                    else
                    {
                        command += " AND " + timeScale(comboBoxSelectTime.SelectedItem.ToString());
                    }


                    if (command != " Where ")
                    {
                        sql += command;
                    }



                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader dbtable = cmd.ExecuteReader();

                    while (dbtable.Read())
                    {
                        selectDataTable.Rows.Add(dbtable["CamID"], dbtable["Time1"], dbtable["Time2"], dbtable["Tag"]);
                    }
                    dbtable.Close();

                    // 필요한 카메라ID 값 추출


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + check);
                }

            }
            
            dataGridViewSelectedData.DataSource = selectDataTable;

            object[] camidobj = selectDataTable.Select().Select(x => x["CamID"]).Distinct().ToArray();
            string[] camidarray = camidobj.Cast<string>().ToArray();


            for (int i = 0; i < camidarray.Length; i++)
            {
                listBoxCamID.Items.Add(camidarray[i]);
            }


        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DataTable fliterdata = new DataTable();

            fliterdata.Columns.Add("CamID", typeof(string));
            fliterdata.Columns.Add("Time1", typeof(string));
            fliterdata.Columns.Add("Time2", typeof(string));
            fliterdata.Columns.Add("Tag", typeof(string));

            for (int a = 0; a < selectDataTable.Rows.Count; ++a)
            {
                if (selectDataTable.Rows[a]["CamID"].ToString() == listBoxCamID.SelectedItem.ToString())
                {
                    fliterdata.Rows.Add(selectDataTable.Rows[a].ItemArray);
                }
            }

            dataGridViewSelectedData.DataSource = fliterdata;
        }
    }

}

