
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
using System.Net.Sockets;
using System.Reflection;

namespace WindowsFormsApplication1
{

    public partial class Mes
    {
        public static Msg msg = new Msg();
        public static string ServerIP = "127.0.0.1";
        public static int ServerPort = 5005;
        public static bool isRunning = false;
        //设备上传服务器信息汇总
        public static ClassReportRecipeDownload ReportRecDown = new ClassReportRecipeDownload();
        public static ClassReportStatus ReportStaue = new ClassReportStatus();
        public static ClassReportMainInfoReport ReportMainInfo = new ClassReportMainInfoReport();
        public static ClassReportStartCheck ReportStauertCheck = new ClassReportStartCheck();
        public static ClassReportDateTimeGet ReportGetDate = new ClassReportDateTimeGet();
        public static ClassReportAlarm ReportAlarm = new ClassReportAlarm();
        public static ClassReportCollect ReportCollect = new ClassReportCollect();
        public static ClassReportRecipeUpload ReportRecipeUp = new ClassReportRecipeUpload();
        public static ClassReportEvent ReportEvent = new ClassReportEvent();
        //上传信息，服务器回复结果
        public static ClassRequesResultCheck ResultReportCheck = new ClassRequesResultCheck();
        public static ReportRecipeUplo ResultReportDownloadRecipe = new ReportRecipeUplo();
        //服务器获取设备信息汇总
        public static ClassRequstNameList ResultRequestNameList = new ClassRequstNameList();
        public static ReportRecipeUplo ResultRequestCurrentRecipe = new ReportRecipeUplo();
        public static ClassRequestParaNameList RequestParaNameList = new ClassRequestParaNameList();
        public static ClassRequestParaValueList mGetParaValueList = new ClassRequestParaValueList();

        public static ClassRequestMessage RequestCmdMessage = new ClassRequestMessage();
        public static DateTime currentTime = new DateTime();
        public static bool RequestEnable;//接收关机命令
        public static string RequestMsg;//接收信息
        #region  Report:Header And Result
        public class nullBody
        { };
        public class BodyHeader : nullBody
        {
            public string apiName;
            public string transactionId;
        }
        public class BodyResult : nullBody
        {
            public int code;
            public string message;
        }
        public class FullBody
        {
            public BodyHeader header;
            public object body;
            public BodyResult result;
        }
        #endregion
        #region  Report: Body
        public class ClassReportStatus : nullBody
        {
            public string eqpId;
            public UInt16 runStatus;
            public string eqpType;
            public string position;
            public string description;
            public string lotNo;
            public string orderNo;
            public UInt16 uph;
            public UInt16 qty;
            public UInt16 doneQty;
            public UInt16 defectQty;
            public string recipeid;
            public string startTime;
            public string alarmCode;
            public string alarmStatu;
        }

        public class ClassReportAlarm : nullBody
        {
            public string eqpId;
            public string eqptype;
            public string alarmMessage;
            public string alarmTime;
            public string alarmCode;
            public string alarmStatu;
            public string position;
        }
        public struct PARAMLIST
        {
            public string name;
            public string value;
            public string remark;
        }
        public struct paraName
        {
            public string name;
            public string remark;
        }
        public struct Name
        {
            public string name;
          
        }
        public class ClassRequstNameList : nullBody
        {
            public string eqpId;

            public Name[] paramList;
        }
        public class ClassReportCollect : nullBody
        {
            public string eqpId;
            public string orderNo;
            public string alarmMsg;
            public string collectionTime;
            public string station;
            public string parameterType;
            public PARAMLIST[] paramList = { new PARAMLIST(), new PARAMLIST(), new PARAMLIST() };
        }
        public class GetTime : nullBody
        {
            public string eqpId;

        }
        public class ClassReportStartCheck : nullBody
        {
            public string eqpId;
            public string lotNo;
        }
        public class ClassReportMainInfoReport : nullBody
        {
            public string eqpId;
            public string eqpType;
            public string eqpModel;
            public string IP;
            public string workshopId;
            public string department;
            public string keShi;
            public string position;
            public string responsible;
            public string createTime;
            public string operating;
            public string macAddress;


        }
        public class parameters
        {
            public string validateType;
            public int bcCompare;
            public int minValue;
            public int padCompare;
            public int maxValue;
            public string dataType;
            public string paramName;
            public int paramValue;
        }
        public class ReportRecipeUplo : nullBody
        {
            public string recipeName;
            public string description;
            public string eqpId;
            public int userId;
            public parameters parameters = new parameters();

        }
        public class ClassReportRecipeUpload : nullBody
        {
            public ReportRecipeUplo[] ReportRecipeUp;
            public ClassReportRecipeUpload()
            {
                ReportRecipeUplo[] ReportRecipeUp1 = { new ReportRecipeUplo(), new ReportRecipeUplo() };
                ReportRecipeUp = ReportRecipeUp1;
            }

        }

        public class ClassReportRecipeDownload : nullBody
        {
            public string eqpId;
            public string RecipeName;
        }
        public class ClassReportDateTimeGet : nullBody
        {
            public string eqpId;
        }
        public enum ReportApiName
        {
            EQPStatusReport,
            EQPAlarmReport,
            EQPDataCollectionReport,
            EQPClassReportDateTimeGet,
            EQPMainInfoReport,
            EQPStartCheck,
            RecipeUpload,
            RecipeDownload,
            EQPEventReport

        }
        public class ClassReportEvent : nullBody
        {
            public string eqpId;
            public string EventID;
            public string EventDesc;
            public string EventTime;
            public string OrderID;
            public string ProductID;
            public string StationID;
            public PARAMLIST[] paramList = { new PARAMLIST(), new PARAMLIST(), new PARAMLIST() };


        }
        #endregion
        #region Request :Body
        public class ClassRequestParaNameList : nullBody
        {
            public string eqpId;
            public string orderNo;
            public string collectionTime;
            public string station;
            public string parameterType;
            public paraName[] paramList = { new paraName(), new paraName(), new paraName() };
        }
        public class ClassRequestParaValueList : nullBody
        {
            public string eqpId;
            public string orderNo;
            public string collectionTime;
            public string station;
            public string parameterType;
            public PARAMLIST[] paramList ;
        }

        public class ClassRequestMessage
        {
            public string eqpId;
            public string message;
        }
        public class ClassRequestCurrentTime
        {
            public string eqpId;
            public string currentTime;
        }
        public class ClassRequestEnable
        {
            public string eqpId;
            public int enable;
        }
        public class ClassRequestReceipe
        {
            public string eqpId;
            public string recipeName;
        }
        public class ClassRequestRecipeUplo : nullBody
        {
            public string recipeName;
            public string description;
            public string eqpId;
            public int userId;
            public parameters parameters = new parameters();

        }
        public class ClassRequesResultCheck
        {
            public string checkStatu;
        }

        public class ClassRequestReceipeSwitch
        {
            public string eqpId;
            public string recipeName;
        }

        #endregion
        /// <summary>
        /// 构造汇报报文
        /// </summary>
        /// <param name="apiname">汇报函数名</param>
        /// <returns></returns>
        public static string BuildReportBody(ReportApiName apiname)
        {

            BodyHeader header = new BodyHeader();
            header.apiName = Enum.GetName(typeof(ReportApiName), apiname);
            object body;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            header.transactionId = Convert.ToInt64(ts.TotalSeconds).ToString();//时间戳
            BodyResult mresult = new BodyResult();
            mresult.code = 1;
            mresult.message = "获取" + Enum.GetName(typeof(ReportApiName), apiname);
            FullBody mbody = new FullBody();
            switch (apiname)
            {
                case ReportApiName.EQPAlarmReport:
                    body = ReportAlarm;
                    break;
                case ReportApiName.EQPDataCollectionReport:
                    body = ReportCollect;
                    break;
                case ReportApiName.EQPClassReportDateTimeGet:
                    body = ReportGetDate;
                    break;
                case ReportApiName.EQPEventReport:
                    body = ReportEvent;
                    break;
                case ReportApiName.EQPMainInfoReport:
                    body = ReportMainInfo;
                    break;
                case ReportApiName.EQPStartCheck:
                    body = ReportStauertCheck;
                    break;
                case ReportApiName.EQPStatusReport:
                    body = ReportStaue;
                    break;
                case ReportApiName.RecipeUpload:
                    body = ReportRecipeUp.ReportRecipeUp;
                    break;
                case ReportApiName.RecipeDownload:
                    body = ReportRecDown;
                    break;
                default:
                    body = ReportRecDown;
                    break;



            }
            mbody.header = header;
            mbody.body = body;
            mbody.result = mresult;
            return JsonConvert.SerializeObject(mbody);

        }
        /// <summary>
        /// 解析汇报返回的结果
        /// </summary>
        /// <param name="result">字符串结果</param>
        /// <param name="apiname">汇报函数名称</param>
        public static void GetReportResult(string result, ReportApiName apiname)
        {
            msg.addmsg("收到Mes" + result);
            switch (apiname)
            {
                case ReportApiName.EQPAlarmReport:
                    break;
                case ReportApiName.EQPDataCollectionReport:

                    break;
                case ReportApiName.EQPClassReportDateTimeGet:
                    //解析当前时间类
                    ClassRequestCurrentTime mTime = JsonConvert.DeserializeObject<ClassRequestCurrentTime>(result);
                    //更新当前时间变量
                    currentTime = Convert.ToDateTime(mTime.currentTime);
                    break;
                case ReportApiName.EQPEventReport:

                    break;
                case ReportApiName.EQPMainInfoReport:

                    break;
                case ReportApiName.EQPStartCheck:
                    //获得检测结果
                     ResultReportCheck = JsonConvert.DeserializeObject<ClassRequesResultCheck>(result);
                    break;
                case ReportApiName.EQPStatusReport:
                    break;
                case ReportApiName.RecipeUpload:
                    break;
                case ReportApiName.RecipeDownload:
                    //下载配方
                    ResultReportDownloadRecipe = JsonConvert.DeserializeObject<ReportRecipeUplo>(result);
                    break;
                default:

                    break;



            }


        }
        public static void httpReport(ReportApiName method)
        {
            try
            {
                string body = BuildReportBody(method);
                string url = "http://localhost:5005/RestAPI/" + Enum.GetName(typeof(ReportApiName), method);
                byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(body);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/json";
                myRequest.ContentLength = postBytes.Length;
                myRequest.Proxy = null;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postBytes, 0, postBytes.Length);
                newStream.Close();
                Main.SaveMsg("发送请求" + url + body);

                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    string content = reader.ReadToEnd();
                    //解析结果
                    GetReportResult(content, method);

                    reader.Close();
                }

            }
            catch (Exception ee)
            {
                Main.SaveMsg(ee.ToString());
                return;
            }

        }
       
        /// <summary>
        /// 开启服务器
        /// </summary>
        public static void BuilderRequest()
        {
            if (isRunning)
                return;
            int len = 0;//端口  
            byte[] buf = new byte[1024];
            string data;
            string StrHeader;
            string StrBody;
            DateTime NowTime;
            string apiName;
            string sendStr;
            //创建服务端Socket
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort));
            serverSocket.Listen(10);
            isRunning = true;


            //输出服务器状态
            Console.WriteLine("Sever is running at http://{0}:{1}/.", ServerIP, ServerPort);
            //连接客户端          
                while (isRunning)
                {
                    Socket clent = serverSocket.Accept();
                    len = clent.Receive(buf);
                    msg.addmsg(string.Format("收到 [{0}] 数据", len));
                    data = Encoding.ASCII.GetString(buf);
                   var vv=  data.Split(new string[] { "\r\n\r\n" },StringSplitOptions.None);
                if (vv.Length < 2)
                {
                    StrHeader = "HTTP/1.0 400 False\nContent-Type:application/json \n\n Welcome!<br>Now Time:{0}";
                    StrBody = "收到错误信息";
                }
                else
                {
                    msg.addmsg("收到：" + vv[1]);
                    FullBody mm = new FullBody();
                    try
                    {
                        mm = JsonConvert.DeserializeObject<FullBody>(vv[1]);
                    }
                    
                    catch (Exception ee)
                    {
                        StrHeader = "HTTP/1.0 400 False\nContent-Type:application/json \n\n Welcome!<br>Now Time:{0}";
                        StrBody = "解析失败" + ee.ToString();
                        NowTime = DateTime.Now;
                        sendStr = string.Format(StrHeader, NowTime.ToString());
                        len = clent.Send(Encoding.ASCII.GetBytes(sendStr));
                        clent.Send(Encoding.ASCII.GetBytes(StrBody));
                      
                        clent.Close();
                        break;
                    }
                    apiName= mm.header.apiName;
                    object RequestBody = mm.body;                
                    StrHeader = "HTTP/1.0 200 OK\nContent-Type:application/json \n\n Now Time:{0}";
                    //解析header并返回
                    StrBody = GetRequestResult(apiName, RequestBody);


                }
                //    string ss1 = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><title>My Home</title></head><body><h2>Web Server System</h2></body></html>";
                NowTime = DateTime.Now;
                sendStr = string.Format(StrHeader, NowTime.ToString());
                len = clent.Send(Encoding.ASCII.GetBytes(sendStr));
                clent.Send(Encoding.ASCII.GetBytes(StrBody));                   
                    clent.Close();
                }
           
         
            //Thread requestThread = new Thread(() => { ProcessRequest(clientSocket); });
            //requestThread.Start();
        }

        /// <summary>
        /// 解析请求报文
        /// </summary>
        /// <param name="GetStr"></param>
        /// <returns></returns>
        public static string GetRequestResult(string apiname,object body=null)
        {

            //FullBody mbody = new FullBody();
            //mbody = JsonConvert.DeserializeObject<FullBody>(GetStr);
            //string apiname = mbody.header.apiName;
            string mres;
            switch (apiname)
            {
                case "GetEQPParameterList":
                  return  mres = JsonConvert.SerializeObject(RequestParaNameList);
                    
                case "GetEQPParameterValueList":
                    ResultRequestNameList = (ClassRequstNameList) body;
                   List< PARAMLIST> ee=new List<PARAMLIST>();
                    foreach (var mm in ResultRequestNameList.paramList)
                    {
                        foreach (var nn in mGetParaValueList.paramList)
                        {
                            if (mm.name == nn.name)
                               ee.Add(nn);
                        }
                    }
                    mGetParaValueList.paramList = ee.ToArray();
                    if (ResultRequestNameList.paramList.Length > 0)
                    {
                        return mres = JsonConvert.SerializeObject(mGetParaValueList);
                    }
                    else
                        return "解析请求列表为空";
                   
                case "GetEQPState":
                    return mres = JsonConvert.SerializeObject(ReportStaue);
                case "CIMMessageCommand":
                    //收到信息
                    ClassRequestMessage mMsg =(ClassRequestMessage)body;
                    RequestMsg = mMsg.message;
                    return mres = "";
                case "DateTimeCommand":
                    //收到服务器时间
                    ClassRequestCurrentTime mTime = (ClassRequestCurrentTime)body;
                    currentTime = Convert.ToDateTime(mTime.currentTime);
                    return mres = "";
                case "StopEQPCommand":
                    //停止命令
                    ClassRequestEnable mcmd = (ClassRequestEnable)body;
                    if (mcmd.enable == 0)
                        RequestEnable = false;
                    else
                        RequestEnable = true;
                    return mres = "";
                case "RecipeUploadRequest":
                    //收到服务器时间
                    ClassRequestReceipe mreceipe = (ClassRequestReceipe)body;
                   foreach (var mm in ReportRecipeUp.ReportRecipeUp)
                    {
                        if(mm.recipeName== mreceipe.recipeName)
                            return mres = "";
                    }
                    return mres = "未找到配方名字";
                case "GetRecipeList":
                    return mres = JsonConvert.SerializeObject(ReportRecipeUp);
                  
                case "GetEQPMainInfo":
                    return mres = JsonConvert.SerializeObject(ReportMainInfo);
                   

                default:
                  return  mres = "异常API";
                   
            }
          


        }

        /// <summary>
        /// 读取json文件
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        private static string ReadJson(string FileName = "output.json")
        {
            string jsonsting;
            FileName = "config//" + FileName;
            try
            {
                bool bExt = File.Exists(FileName);

                if (!bExt)
                {
                    File.Create(FileName);
                    jsonsting = "";
                }
                else
                    jsonsting = File.ReadAllText(FileName);
                return jsonsting;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "err";
            }

        }
        //加载数据
        public static void ReadFile()
        {
            string StrMESMSG = ReadJson("ReportStaue.json");
            ReportStaue = JsonConvert.DeserializeObject<ClassReportStatus>(StrMESMSG);
            StrMESMSG = ReadJson("ReportMainInfo.json");
            ReportMainInfo = JsonConvert.DeserializeObject<ClassReportMainInfoReport>(StrMESMSG);
            StrMESMSG = ReadJson("ReportAlarm.json");
            ReportAlarm = JsonConvert.DeserializeObject<ClassReportAlarm>(StrMESMSG);

            StrMESMSG = ReadJson("ReportCollect.json");
            ReportCollect = JsonConvert.DeserializeObject<ClassReportCollect>(StrMESMSG);
            StrMESMSG = ReadJson("ReportRecipeUp.json");
            ReportRecipeUp = JsonConvert.DeserializeObject<ClassReportRecipeUpload>(StrMESMSG);
            StrMESMSG = ReadJson("mainRecDown.json");
            ReportRecDown = JsonConvert.DeserializeObject<ClassReportRecipeDownload>(StrMESMSG);

            StrMESMSG = ReadJson("ReportEvent.json");
            ReportEvent = JsonConvert.DeserializeObject<ClassReportEvent>(StrMESMSG);

            StrMESMSG = ReadJson("ReportStauertCheck.json");
            ReportStauertCheck = JsonConvert.DeserializeObject<ClassReportStartCheck>(StrMESMSG);
           
            if (ReportAlarm == null)
                ReportAlarm = new Mes.ClassReportAlarm();
            if (Mes.ReportMainInfo == null)
                Mes.ReportMainInfo = new Mes.ClassReportMainInfoReport();
            if (Mes.ReportRecDown == null)
                Mes.ReportRecDown = new Mes.ClassReportRecipeDownload();
            if (Mes.ReportStaue == null)
                ReportStaue = new ClassReportStatus();
            if (ReportStauertCheck == null)
                ReportStauertCheck = new ClassReportStartCheck();
            if (ReportGetDate == null)
                ReportGetDate = new ClassReportDateTimeGet();
            if (ReportCollect == null)
                ReportCollect = new ClassReportCollect();
            if (ReportRecipeUp == null)
                ReportRecipeUp = new ClassReportRecipeUpload();
            if (ReportEvent == null)
                ReportEvent = new ClassReportEvent();
    }
        //保存数据
        public static void SaveFile()
        {            
            string outputJson1 = JsonConvert.SerializeObject(ReportStaue);
            ;
            File.WriteAllText("config//ReportStaue.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportMainInfo);
            File.WriteAllText("config//ReportMainInfo.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportAlarm);
            File.WriteAllText("config//ReportAlarm.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportCollect);
            File.WriteAllText("config//ReportCollect.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportRecipeUp);
            File.WriteAllText("config//ReportRecipeUp.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportRecDown);
            File.WriteAllText("config//mainRecDown.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportStauertCheck);
            File.WriteAllText("config//ReportStauertCheck.json", outputJson1);
            outputJson1 = JsonConvert.SerializeObject(ReportEvent);
            File.WriteAllText("config//ReportEvent.json", outputJson1);

        }
      
        public static string GetDateTime(ref string dateTime)
        {
            dateTime = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.fff");
            return dateTime;
        }     
 
     



    }
}
