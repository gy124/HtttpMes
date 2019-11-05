using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Timers;

using System.Reflection;

namespace WindowsFormsApplication1
{

    public partial class Main : Form
    {
        
        public static string UserId = "";
        public static string Password = "";
        static FileStream Log;
        static string str_date;  //log文件日期     
        public static string PrintMsg = "";//界面打印信息
       

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Form_load frWarning = new Form_load(); //登录窗体
            //   fr_warning.BackColor = Color.Yellow;
            //用对话框格式显示，等待登录成功
            frWarning.ShowDialog();
            if (UserId == "")
                this.Close();
            if (Password == "")
                this.Close();
            tabControl1.SelectedIndex = 1;
           Mes. msg.StartUpdate(richTextBox_return);
            ReadMsg();
        }

        public void update_msg()
        {

            //if (Mes.ReportMainInfo == null)
            //    Mes.ReportMainInfo = new Mes.ClassReportMainInfoReport();
            Mes.ReportMainInfo.eqpId = tb_eqpID.Text;
            Mes.ReportMainInfo.eqpType = tb_eqptype.Text;
            Mes.ReportMainInfo.position = tb_position.Text;
            Mes.ReportMainInfo.eqpModel = tb_eqpModle.Text;
            Mes.ReportMainInfo.IP = tb_IP.Text;
            Mes.ReportMainInfo.workshopId = tb_workshopID.Text;
            Mes.ReportMainInfo.department = tb_department.Text;
            Mes.ReportMainInfo.keShi = tb_keshi.Text;
            Mes.ReportMainInfo.responsible = tb_resonsible.Text;
            Mes.ReportMainInfo.createTime = tb_mainCreatTime.Text;
            Mes.ReportMainInfo.operating = tb_operation.Text;
            Mes.ReportMainInfo.macAddress = tb_macAddress.Text;



            //if (Mes.ReportStaue == null)
            //    Mes.ReportStaue = new Mes.ClassReportStatus();
            Mes.ReportStaue.eqpType = tb_eqptype.Text;
            Mes.ReportStaue.eqpId = tb_eqpID.Text;
            Mes.ReportStaue.runStatus = Convert.ToUInt16(tb_runSta.Value);
            Mes.ReportStaue.description = tb_staDescription.Text;
            Mes.ReportStaue.lotNo = tb_lotNO.Text;
            Mes.ReportStaue.position = tb_position.Text;
            Mes.ReportStaue.orderNo = tb_orderNO.Text;
            Mes.ReportStaue.uph = Convert.ToUInt16(tb_UPH.Value);
            Mes.ReportStaue.qty = Convert.ToUInt16(tb_qty.Value);
            Mes.ReportStaue.doneQty = Convert.ToUInt16(tb_doneQty.Value);
            Mes.ReportStaue.defectQty = Convert.ToUInt16(tb_defectQty.Value);
            Mes.ReportStaue.recipeid = tb_receipeID.Text;
            Mes.ReportStaue.startTime = tb_lotStartTime.Text;
            Mes.ReportStaue.alarmCode = tb_alarmCode.Text;
            Mes.ReportStaue.alarmStatu = tb_alarmSta.Text;

            //if (Mes.ReportAlarm == null)
            //    Mes.ReportAlarm = new Mes.ClassReportAlarm();
            Mes.ReportAlarm.eqpId = tb_eqpID.Text;
            Mes.ReportAlarm.eqptype = tb_eqptype.Text;
            Mes.ReportAlarm.position = tb_position.Text;
            Mes.ReportAlarm.alarmCode = tb_alarmCode.Text;
            Mes.ReportAlarm.alarmStatu = tb_alarmSta.Text;
            Mes.ReportAlarm.alarmMessage = tb_AlarmMeg.Text;
            Mes.ReportAlarm.alarmTime = tb_AlarmTime.Text;

            //if (Mes.ReportStauertCheck == null)
            //    Mes.ReportStauertCheck = new Mes.ClassReportStartCheck();
            Mes.ReportStauertCheck.lotNo = tb_lotNO.Text;
            Mes.ReportStauertCheck.eqpId = tb_eqpID.Text;

            //if (Mes.ReportCollect == null)
            //    Mes.ReportCollect = new Mes.ClassReportCollect();
            Mes.ReportCollect.collectionTime = tb_collectTime.Text;
            Mes.ReportCollect.eqpId = tb_eqpID.Text;
            Mes.ReportCollect.orderNo = tb_orderNO.Text;
            Mes.ReportCollect.station = tb_station.Text;
            Mes.ReportCollect.parameterType = tb_paraType.Text;
            Mes.ReportCollect.paramList[0].name = tb_name1.Text;
            Mes.ReportCollect.paramList[1].name = tb_name2.Text;
            Mes.ReportCollect.paramList[2].name = tb_name3.Text;
            Mes.ReportCollect.paramList[0].value = tb_value1.Text;
            Mes.ReportCollect.paramList[1].value = tb_value2.Text;
            Mes.ReportCollect.paramList[2].value = tb_value3.Text;
            Mes.ReportCollect.paramList[0].remark = tb_remark1.Text;
            Mes.ReportCollect.paramList[1].remark = tb_remark2.Text;
            Mes.ReportCollect.paramList[2].remark = tb_remark3.Text;

            if (Mes.ReportRecDown == null)
                Mes.ReportRecDown = new Mes.ClassReportRecipeDownload();
            Mes.ReportRecDown.eqpId = tb_eqpID.Text;
            Mes.ReportRecDown.RecipeName = tb_recipeName.Text;

            //if (Mes.ReportRecipeUp == null)
            //    Mes.ReportRecipeUp = new Mes.ClassReportRecipeUpload();

            Mes.ReportRecipeUp.ReportRecipeUp[0].eqpId = tb_eqpID.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[0].description = tb_recDes1.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[0].recipeName = tb_recName1.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[0].userId = Convert.ToInt32(tb_userID1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.bcCompare = Convert.ToInt32(tb_recBcCom1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.dataType = tb_recDataType1.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.maxValue = Convert.ToInt32(tb_recMax1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.minValue = Convert.ToInt32(tb_recMin1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.padCompare = Convert.ToInt32(tb_recPadCom1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.paramName = tb_recDataName1.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.paramValue = Convert.ToInt32(tbRecDataValue1.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.validateType = tb_recParaType1.Text;

            Mes.ReportRecipeUp.ReportRecipeUp[1].eqpId = tb_eqpID.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[1].description = tb_recDes2.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[1].recipeName = tb_recName2.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[1].userId = Convert.ToInt32(tb_userID2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.bcCompare = Convert.ToInt32(tb_recBcCom2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.dataType = tb_recDataType2.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.maxValue = Convert.ToInt32(tb_recMax2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.minValue = Convert.ToInt32(tb_recMin2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.padCompare = Convert.ToInt32(tb_recPadCom2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.paramName = tb_recDataName2.Text;
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.paramValue = Convert.ToInt32(tbRecDataValue2.Text);
            Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.validateType = tb_recParaType2.Text;

            //if (Mes.ReportGetDate == null)
            //    Mes.ReportGetDate = new Mes.ClassReportDateTimeGet();
            Mes.ReportGetDate.eqpId = tb_eqpID.Text;
            //if (Mes.ReportEvent == null)
            //    Mes.ReportEvent = new Mes.ClassReportEvent();
            Mes.ReportEvent.EventDesc = tb_EventDesc.Text;
            Mes.ReportEvent.eqpId = tb_eqpID.Text;
            Mes.ReportEvent.EventID = tb_eventID.Text;
            Mes.ReportEvent.EventTime = tb_eventTime.Text;
            Mes.ReportEvent.OrderID = tb_orderNO.Text;
            Mes.ReportEvent.ProductID = tb_produceID.Text;
            Mes.ReportEvent.StationID = tb_station.Text;
            Mes.ReportEvent.paramList[0].name = tb_name1.Text;
            Mes.ReportEvent.paramList[1].name = tb_name2.Text;
            Mes.ReportEvent.paramList[2].name = tb_name3.Text;
            Mes.ReportEvent.paramList[0].value = tb_value1.Text;
            Mes.ReportEvent.paramList[1].value = tb_value2.Text;
            Mes.ReportEvent.paramList[2].value = tb_value3.Text;
            Mes.ReportEvent.paramList[0].remark = tb_remark1.Text;
            Mes.ReportEvent.paramList[1].remark = tb_remark2.Text;
            Mes.ReportEvent.paramList[2].remark = tb_remark3.Text;

        }
        /// <summary>
        /// 读取所有文件
        /// </summary>
        /// 
        public  void ReadMsg()
        {
            Mes.ReadFile();       
            tb_eqpID.Text = Mes.ReportMainInfo.eqpId;
            tb_eqptype.Text = Mes.ReportMainInfo.eqpType;
            tb_position.Text = Mes.ReportMainInfo.position;
            tb_eqpModle.Text = Mes.ReportMainInfo.eqpModel;
            tb_IP.Text = Mes.ReportMainInfo.IP;
            tb_workshopID.Text = Mes.ReportMainInfo.workshopId;
            tb_department.Text = Mes.ReportMainInfo.department;
            tb_keshi.Text = Mes.ReportMainInfo.keShi;
            tb_resonsible.Text = Mes.ReportMainInfo.responsible;
            tb_mainCreatTime.Text = Mes.ReportMainInfo.createTime;
            tb_operation.Text = Mes.ReportMainInfo.operating;
            tb_macAddress.Text = Mes.ReportMainInfo.macAddress;

            tb_runSta.Text = Mes.ReportStaue.runStatus.ToString();
            tb_staDescription.Text = Mes.ReportStaue.description;
            tb_lotNO.Text = Mes.ReportStaue.lotNo;
            tb_orderNO.Text = Mes.ReportStaue.orderNo;
            tb_UPH.Text = Mes.ReportStaue.uph.ToString();
            tb_qty.Text = Mes.ReportStaue.qty.ToString();
            tb_doneQty.Text = Mes.ReportStaue.doneQty.ToString();
            tb_defectQty.Text = Mes.ReportStaue.defectQty.ToString();
            tb_receipeID.Text = Mes.ReportStaue.recipeid;
            tb_lotStartTime.Text = Mes.ReportStaue.startTime;
            tb_alarmCode.Text = Mes.ReportStaue.alarmCode;
            tb_alarmSta.Text = Mes.ReportStaue.alarmStatu;
            tb_AlarmMeg.Text = Mes.ReportAlarm.alarmMessage;
            tb_AlarmTime.Text = Mes.ReportAlarm.alarmTime;

            tb_collectTime.Text = Mes.ReportCollect.collectionTime;

            tb_station.Text = Mes.ReportCollect.station;
            tb_paraType.Text = Mes.ReportCollect.parameterType;
            tb_name1.Text = Mes.ReportCollect.paramList[0].name;
            tb_name2.Text = Mes.ReportCollect.paramList[1].name;
            tb_name3.Text = Mes.ReportCollect.paramList[2].name;
            tb_value1.Text = Mes.ReportCollect.paramList[0].value;
            tb_value2.Text = Mes.ReportCollect.paramList[1].value;
            tb_value3.Text = Mes.ReportCollect.paramList[2].value;
            tb_remark1.Text = Mes.ReportCollect.paramList[0].remark;
            tb_remark2.Text = Mes.ReportCollect.paramList[1].remark;
            tb_remark3.Text = Mes.ReportCollect.paramList[2].remark;



            tb_recDes1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].description;
            tb_recName1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].recipeName;
            tb_userID1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].userId.ToString();
            tb_recBcCom1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.bcCompare.ToString();
            tb_recDataType1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.dataType;
            tb_recMax1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.maxValue.ToString();
            tb_recMin1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.minValue.ToString();
            tb_recPadCom1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.padCompare.ToString();
            tb_recDataName1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.paramName;
            tbRecDataValue1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.paramValue.ToString();
            tb_recParaType1.Text = Mes.ReportRecipeUp.ReportRecipeUp[0].parameters.validateType;


            tb_recDes2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].description;
            tb_recName2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].recipeName;
            tb_userID2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].userId.ToString();
            tb_recBcCom2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.bcCompare.ToString();
            tb_recDataType2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.dataType;
            tb_recMax2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.maxValue.ToString();
            tb_recMin2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.minValue.ToString();
            tb_recPadCom2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.padCompare.ToString();
            tb_recDataName2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.paramName;
            tbRecDataValue2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.paramValue.ToString();
            tb_recDataType2.Text = Mes.ReportRecipeUp.ReportRecipeUp[1].parameters.validateType;


            tb_EventDesc.Text = Mes.ReportEvent.EventDesc;
            tb_eqpID.Text = Mes.ReportEvent.eqpId;
            tb_eventID.Text = Mes.ReportEvent.EventID;
            tb_eventTime.Text = Mes.ReportEvent.EventTime;
            tb_orderNO.Text = Mes.ReportEvent.OrderID;
            tb_produceID.Text = Mes.ReportEvent.ProductID;
            tb_station.Text = Mes.ReportEvent.StationID;
            tb_name1.Text = Mes.ReportEvent.paramList[0].name;
            tb_name2.Text = Mes.ReportEvent.paramList[1].name;
            tb_name3.Text = Mes.ReportEvent.paramList[2].name;
            tb_value1.Text = Mes.ReportEvent.paramList[0].value;
            tb_value2.Text = Mes.ReportEvent.paramList[1].value;
            tb_value3.Text = Mes.ReportEvent.paramList[2].value;
            tb_remark1.Text = Mes.ReportEvent.paramList[0].remark;
            tb_remark2.Text = Mes.ReportEvent.paramList[1].remark;
            tb_remark3.Text = Mes.ReportEvent.paramList[2].remark;
        }
      

    

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button37_Click(object sender, EventArgs e)
        {
            update_msg();
            Mes.SaveFile();
            ReadMsg();
            MessageBox.Show("保存成功,其他信息请在debug文件内文本更改！");
        }
      
       

        /// <summary>
        /// log打印消息
        /// </summary>
        /// <param name="MsgStr">日志消息</param>
        public static void SaveMsg(string MsgStr)
        {
            

            if (Log == null || 0 != string.Compare(str_date, DateTime.Now.ToString("yyyy-MM-dd")))
            {
                String str;
                str = Path.GetFullPath("..") + "\\log\\";
                if (!Directory.Exists(str))
                {
                    //文件夹不存在则创建
                    Directory.CreateDirectory(str);
                }

                try
                {
                    if (Log != null)
                    {
                        Log.Close();
                        Log = null;
                    }
                    str += DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    if (!File.Exists(str))
                    {
                        Log = new FileStream(str, FileMode.Create);
                    }
                    else
                    {
                        Log = new FileStream(str, FileMode.Open);

                    }
                    str_date = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch (Exception)
                {
                    return;
                }
            }

           Mes. msg.addmsg(MsgStr);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

           

        }

        private void button36_Click(object sender, EventArgs e)
        {
            // var method = (Mes.ReportApiName)cb_report.SelectedIndex;
            //Mes. httpReport(method);
            Task mm = new Task(() =>
              {
                  Mes.BuilderRequest();
              });
            mm.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button67_Click(object sender, EventArgs e)
        {

        }

        private void button65_Click(object sender, EventArgs e)
        {

        }
    }
}
