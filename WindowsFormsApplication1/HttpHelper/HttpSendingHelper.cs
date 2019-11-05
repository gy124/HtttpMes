using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace HttpHelper
{
    public class HttpSendingHelper
    {

        /// <summary>     
        /// Get方式获取url地址输出内容     
        /// </summary> /// <param name="url">Http地址</param>     
        /// <param name="encoding">返回内容编码方式，例如：Encoding.UTF8</param>     
        public static String SendRequest(String url, Encoding encoding)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();
        }


        //get方法调用接口获取json文件内容  
        public void GetFunction()
        {

            string serviceAddress = "http://192.168.208.101/iot-api/v1/value";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            HttpContext.Current.Response.Write(retString);
        }




        /// <summary>
        /// （post方法调用接口获取json文件内容）  
        /// </summary>
        /// <param name="SeviceAddress">需要访问的http地址</param>
        /// <param name="id">设备编号</param>
        /// <param name="time">系统与服务器需要同步的时间</param>
        /// <param name="code">错误代码</param>
        /// <param name="value">错误代码编号</param>
        public static string HttpPost(bool OpenOrClose, string SeviceAddress, string id, string time, string code, int value,bool Init=false)
        {
            try
            {
                if (OpenOrClose)
                {
                   
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SeviceAddress);


                    request.Method = "POST";

                    request.ContentType = "application/json";
                    //json文本格式
                    StringWriter sw = new StringWriter();
                    JsonWriter JsonWriter = new JsonTextWriter(sw);
                    JsonWriter.WriteStartObject();

                    JsonWriter.WritePropertyName("id");
                    JsonWriter.WriteValue(id);

                    JsonWriter.WritePropertyName("time");
                    JsonWriter.WriteValue(time);

                    JsonWriter.WritePropertyName("items");
                    JsonWriter.WriteStartArray();

                    JsonWriter.WriteStartObject();
                    JsonWriter.WritePropertyName("code");
                    JsonWriter.WriteValue(code);
                    JsonWriter.WritePropertyName("value");
                    JsonWriter.WriteValue(value.ToString());
                    JsonWriter.WritePropertyName("time");
                    JsonWriter.WriteValue(time);
                    JsonWriter.WriteEndObject();
                    JsonWriter.WriteEndArray();

                    JsonWriter.WriteEndObject();
                    JsonWriter.Flush();
                    string jsonText = sw.GetStringBuilder().ToString();

                    using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                    {
                        dataStream.Write(jsonText);
                        dataStream.Close();
                    }
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string encoding = response.ContentEncoding;
                    if (encoding == null || encoding.Length < 1)
                    {
                        encoding = "UTF-8"; //默认编码    
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding)))
                    {
                        string retString = reader.ReadToEnd();
                        reader.Close();
                     //   JsonConvert.DeserializeObject<Object>(retString);  
                        //解析josn  
                        //JObject jo = JObject.Parse(retString);
                        //HttpContext.Current.Response.Write(jo["message"]["mmmm"].ToString());
                        //string Datatime2 = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+08:00");
                        return retString +code.ToString () + value .ToString ();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            }

        public static string GetDateTime(ref string dateTime)
        {
            dateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+08:00");
            return dateTime;
        }

    }
}
