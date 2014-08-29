/*
 * Author : Jackie Yu
 * Date : 2012-4-24
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO.Compression;

namespace Achievo.Poster
{
    public partial class PostForm : Form
    {
        private long elapsedTime = 0;
        private string costFormat = "Response - Costs: {0} ms";
        private const string LINE_SEPARATE = "\n\r=======================[{0}], Costs:{1} ms, Length:{2}, traceId:{3} =====================\n\r";

        private static SharedHttpHeaderSettingEntity SHARED_HTTP_HEADER_SETTING = null;
        private static List<HostEntity> HOSTS = null;
        private DateTime LastExecuteTime = DateTime.Now;
        public PostForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            System.Net.ServicePointManager.DefaultConnectionLimit = 5000;
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            this.txtRequestHeader.Text = @"Content-Type: application/json
appid : com.accela.inspector
//Content-Type: application/x-www-form-urlencoded
//BizURL : 
//AccessKey :
";

            LoadHistory(null);
            LoadHosts();
            //LoadSharedHttpHeaderSetting();
        }

        private void LoadHosts()
        {
            try
            {
                HOSTS = FileUtility.ReadHostsFromFile();
                BindHosts(this.cmbHosts, HOSTS);
                BindHosts(cmbHostsTab2, HOSTS, -1);
                //BindHostsToDataGrid(HOSTS);
                ShowHostsToHostsText(HOSTS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void BindHosts(ComboBox cmbBox, List<HostEntity> hosts, int selectedIndex = 0)
        {
            cmbBox.Items.Clear();

            if(hosts != null && hosts.Count > 0)
            {
                var hostArr = hosts.ToArray();
                cmbBox.Items.AddRange(hostArr);

                if (cmbBox.Items.Count > 0)
                {
                    cmbBox.SelectedIndex = selectedIndex;
                }
            }
        }

        private void LoadHistory(string name)
        {
            try
            {
                this.cmbURL.Items.Clear();
                FileInfo[] files = FileUtility.GetHistoryList();
                if (files != null && files.Length > 0)
                {
                    foreach (var f in files)
                    {
                        string fileName = f.Name.Substring(0, f.Name.Length - 4);
                        this.cmbURL.Items.Add(fileName);
                        if (fileName.Equals(name))
                        {
                            cmbURL.SelectedItem = name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LoadSharedHttpHeaderSetting(HostEntity host)
        {
            try
            {
                if (host == null) return;
                // open application, init a token
                //btnGenerateToken_Click(null, null);
                SHARED_HTTP_HEADER_SETTING = FileUtility.ReadHttpHeaderSettingFile(host);

                FillSharedHttpHeaderSettings(SHARED_HTTP_HEADER_SETTING);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void FillSharedHttpHeaderSettings(SharedHttpHeaderSettingEntity entity)
        {
            if(entity == null)
            {
                this.txtAgency.Clear();
                this.txtAppID.Clear();
                this.txtAppSecret.Clear();
                this.txtContentType.Clear();
                this.txtEnvironment.Clear();
                this.txtRequestBodyForGettingToken.Clear();
                this.txtRequestUrlForGettingToken.Clear();
                this.txtResponseToken.Clear();
                this.txtAccessKey.Clear();
            }
            else
            {
                this.txtAgency.Text = entity.Agency;
                this.txtAppID.Text = entity.AppId;
                this.txtAppSecret.Text = entity.AppSecret;
                this.txtContentType.Text = entity.ContentType;
                this.txtEnvironment.Text = entity.Environment;
                this.txtRequestBodyForGettingToken.Text = entity.GetTokenRequestBody;
                this.txtRequestUrlForGettingToken.Text = entity.GetTokenRequestUrl;
                this.txtResponseToken.Text = entity.AccessToken;
                this.txtAccessKey.Text = entity.AccessKey;
            }
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            await PostPutDeletePatch(HttpMethod.Get);
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            await PostPutDeletePatch(HttpMethod.Post);
        }

        private async void btnPut_Click(object sender, EventArgs e)
        {
            await PostPutDeletePatch(HttpMethod.Put);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await PostPutDeletePatch(HttpMethod.Delete);
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            //PostPutDeletePatch(HttpMethod.);
        }

        private async Task PostPutDeletePatch(HttpMethod httpMethod)
        {
            try
            {
                RegenerateTokenWhenMoreThan24Hours();

                this.txtResponseHeader.Clear();
                this.txtResponse.Text = "Processing...";
                elapsedTime = 0;
                groupResponse.Text = "Response";
                string url = this.txtRequestUrl.Text.Trim();
                if (String.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Request URL is required.", "Warn");
                    return;
                }

                listView1.Items.Clear();
                int concurrent = Convert.ToInt32(this.numericUpDown1.Value);
  
                NameValueCollection headers = this.GetHeaders(this.chkReplaceHeader.Checked, SHARED_HTTP_HEADER_SETTING);
                string requestBody = this.txtRequestBody.Text.Trim();
                TaskScheduler uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
                Task[] tasks = new Task[concurrent];
                for (int i = 0; i < concurrent; i++)
                {
                    int index = i + 1;

                    tasks[i] = Task.Run(async () => await SendRequest(httpMethod, headers, index, concurrent, url, requestBody, uiTaskScheduler));
                }

                //// start task
                //await Task.WhenAll(tasks);

                //for (int i = 0; i < concurrent; i++)
                //{
                //    int index = i + 1;
                //    await SendRequest(httpMethod, headers, index, concurrent, url, requestBody);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            if (cmbURL.SelectedItem == null || String.IsNullOrWhiteSpace(cmbURL.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a favorite that you want to delete.");
                return;
            }

            try
            {
                var result = MessageBox.Show("Are you sure to delete '" + cmbURL.SelectedItem.ToString() + "' from favorites?", "Warn", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    FileUtility.DeleteHistory(cmbURL.SelectedItem.ToString());
                    LoadHistory(null);
                    this.txtSaveAs.Clear();
                    this.txtRequestUrl.Clear();
                    this.txtRequestBody.Clear();
                    this.txtResponse.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtSaveAs.Text.Trim();
            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.", "Error");
                return;
            }
            else if (!FileUtility.IsValidFileName(name))
            {
                MessageBox.Show("File Name is invalid.", "Error");
                return;
            }

            SaveRequestData(name);

            MessageBox.Show("The request has been saved to favorites.", "Success");

            LoadHistory(name);
        }

        private async Task SendRequest(HttpMethod httpMethod, NameValueCollection headers, int sequence, int total, string requestUrl, string requestBody, TaskScheduler uiTaskScheduler)
        {
            requestUrl = requestUrl.Replace(" ", "").Replace("\\r", "").Replace("\\n", "").Replace("\\r\\n", "");

            try
            {

                ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return (true); };
                HttpClient client = new HttpClient();
                HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, requestUrl);
               
               // requestMessage.Version = Version.Parse("1.0");
                if (httpMethod != HttpMethod.Get)
                {
                    requestMessage.Content = new StringContent(requestBody, Encoding.UTF8, headers["Content-Type"]);
                }

                SetRequestHeader(client, requestMessage, headers);

                string responseString = string.Empty;

                elapsedTime = 0;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //TaskScheduler uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
               
                var task = client.SendAsync(requestMessage);

                await task.ContinueWith((requestTask) =>
                {
                    watch.Stop();
                    elapsedTime = watch.ElapsedMilliseconds;
                    
                    if (this.txtResponse.Text == "Processing...")
                    {
                        this.txtResponse.Text = "Results :";
                    }

                    string traceId = GetTraceIdFromHeader(requestTask.Result.Headers);

                    // Get HTTP response from completed task.
                    if (requestTask.IsCompleted && requestTask.Status == TaskStatus.RanToCompletion)
                    {
                        if(sequence == 1 && this.chkReplaceHeader.Checked
                            && SHARED_HTTP_HEADER_SETTING != null 
                            && !String.IsNullOrWhiteSpace(SHARED_HTTP_HEADER_SETTING.GetTokenRequestUrl)
                            && !String.IsNullOrWhiteSpace(SHARED_HTTP_HEADER_SETTING.GetTokenRequestBody)
                            && requestTask.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            //auto generate a access token
                            this.GenerateToken(SHARED_HTTP_HEADER_SETTING.GetTokenRequestUrl, SHARED_HTTP_HEADER_SETTING.GetTokenRequestBody);
                        }

                        //    HttpResponseMessage response = requestTask.Result;
                        var header = requestTask.Result.Content.Headers.ToString();
                        this.txtResponseHeader.Text = ((int)requestTask.Result.StatusCode) + "-" + requestTask.Result.StatusCode.ToString() + "\r\n" + header + requestTask.Result.Headers.ToString();
                        //response.Content.Headers.ContentType
                        var resultStream = requestTask.Result.Content.ReadAsStreamAsync().Result;
                        if (requestTask.Result.Content.Headers.ContentEncoding.Count > 0)
                        {
                            var contentEncoding = requestTask.Result.Content.Headers.ContentEncoding.First();
                            resultStream = Decompress(resultStream, contentEncoding);
                            resultStream.Position = 0;
                            StreamReader reader = new StreamReader(resultStream);
                            responseString = reader.ReadToEnd();
                            resultStream.Close();
                            reader.Close();
                        }
                        else
                        {
                            responseString = requestTask.Result.Content.ReadAsStringAsync().Result;
                        }

                        this.txtResponse.Text += String.Format(LINE_SEPARATE, sequence, elapsedTime, responseString.Length, traceId) + responseString;
                        groupResponse.Text = String.Format(costFormat, elapsedTime);
                        ListViewItem item = new ListViewItem(new string[] { sequence.ToString(), elapsedTime.ToString() });
                        listView1.Items.Add(item);
                    }
                    else if (requestTask.Status == TaskStatus.Faulted)
                    {
                        this.txtResponse.Text += String.Format(LINE_SEPARATE, sequence, elapsedTime, responseString.Length, traceId);
                        this.txtResponse.Text += "Request Failed. Exception: \r\n" + GetInnerException( requestTask.Exception).Message;
                    }
                    else
                    {
                        this.txtResponse.Text += String.Format(LINE_SEPARATE, sequence, elapsedTime, responseString.Length, traceId);
                        this.txtResponse.Text += "Request Failed, please check the request url.";
                    }
                }, uiTaskScheduler);
            }
            catch (Exception ex)
            {
                this.txtResponse.Text += String.Format(LINE_SEPARATE, sequence, elapsedTime, 0, "");
                this.txtResponse.Text += GetInnerException(ex).Message;
            }
        }

        private static string GetTraceIdFromHeader(HttpResponseHeaders headers)
        {
            if(headers == null || headers.Count() == 0)
            {
                return string.Empty;
            }

            foreach(var h in headers)
            {
                if (h.Key.Equals("x-accela-traceId", StringComparison.OrdinalIgnoreCase))
                {
                    return h.Value.FirstOrDefault();
                }
            }

            return string.Empty;
        }

        private Exception GetInnerException(Exception ex)
        {
            Exception innerException = ex;

            while (innerException != null && innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
            }

            return innerException;
        }
        private static Stream Compress(Stream raw)
        {
            MemoryStream memory = new MemoryStream();

            using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
            {
                byte[] buffer = new byte[1024];
                int nRead;
                while ((nRead = raw.Read(buffer, 0, buffer.Length)) > 0)
                {
                    gzip.Write(buffer, 0, nRead);
                }
            }
            return memory;
        }
        private static Stream Decompress(Stream raw, string contentEncoding)
        {
            MemoryStream memory = new MemoryStream();

            if ("gzip".Equals(contentEncoding, StringComparison.OrdinalIgnoreCase))
            {
                using (GZipStream gzip = new GZipStream(raw, CompressionMode.Decompress, true))
                {
                    byte[] buffer = new byte[1024];
                    int nRead;
                    while ((nRead = gzip.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memory.Write(buffer, 0, nRead);
                    }
                }
            }
            else if ("deflate".Equals(contentEncoding, StringComparison.OrdinalIgnoreCase))
            {
                using (DeflateStream gzip = new DeflateStream(raw, CompressionMode.Decompress, true))
                {
                    byte[] buffer = new byte[1024];
                    int nRead;
                    while ((nRead = gzip.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memory.Write(buffer, 0, nRead);
                    }
                }
            }
            else
            {
                return raw;
            }
            return memory;
        }

        private void SetRequestHeader(HttpClient httpClient, HttpRequestMessage request, NameValueCollection headers)
        {
            //The restricted headers are:
            string[] restrictedHeaders = new string[]{
                    "Accept","Connection","Content-Length",
                    "Content-Type","Date","Expect","Host",
                    "If-Modified-Since","Range","Referer",
                    "Transfer-Encoding","User-Agent",
                    "Proxy-Connection" };

            foreach (var key in headers.AllKeys)
            {
                if (key.Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
                {
                    //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headers[key]));
                }
                else if (key.Equals("Accept", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (key.Equals("Connection", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (key.Equals("Content-Length", StringComparison.InvariantCultureIgnoreCase))
                {
                    // httpClient.DefaultRequestHeaders.
                }
                else if (key.Equals("Host", StringComparison.InvariantCultureIgnoreCase))
                {
                    httpClient.DefaultRequestHeaders.Host = headers[key];
                }
                else if (key.Equals("User-Agent", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (key.Equals("Transfer-Encoding", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (key.Equals("Proxy-Connection", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (key.Equals("If-Modified-Since", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (key.Equals("Range", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (key.Equals("Referer", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (key.Equals("Date", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (key.Equals("Expect", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else
                {
                    request.Headers.Add(key, headers[key]);
                }
            }

        }
        private NameValueCollection GetHeaders(bool usingSharedHeader, SharedHttpHeaderSettingEntity sharedSetting)
        {
            NameValueCollection headerList = new NameValueCollection();

            string headers = this.txtRequestHeader.Text.Trim();

            string[] arr = headers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arr)
            {
                if (!String.IsNullOrWhiteSpace(s))
                {
                    string[] kv = s.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (kv.Length > 1)
                    {
                        string key = kv[0].Trim().ToLower();
                        if (!key.StartsWith("//"))
                        {

                            headerList.Add(key, kv[1].Trim());
                        }
                    }
                }
            }

            if (usingSharedHeader && sharedSetting != null)
            {
                if (headerList.AllKeys.Contains("content-type"))
                {
                    headerList["content-type"] = sharedSetting.ContentType;
                }
                else
                {
                    headerList.Add("content-type", sharedSetting.ContentType);
                }

                if (headerList.AllKeys.Contains("x-accela-appid"))
                {
                    headerList["x-accela-appid"] = sharedSetting.AppId;
                }
                else
                {
                    headerList.Add("x-accela-appid", sharedSetting.AppId);
                }

                if (headerList.AllKeys.Contains("x-accela-appsecret"))
                {
                    headerList["x-accela-appsecret"] = sharedSetting.AppSecret;
                }
                else
                {
                    headerList.Add("x-accela-appsecret", sharedSetting.AppSecret);
                }

                if (headerList.AllKeys.Contains("x-accela-agency"))
                {
                    headerList["x-accela-agency"] = sharedSetting.Agency;
                }
                else
                {
                    headerList.Add("x-accela-agency", sharedSetting.Agency);
                }

                if (headerList.AllKeys.Contains("x-accela-environment"))
                {
                    headerList["x-accela-environment"] = sharedSetting.Environment;
                }
                else
                {
                    headerList.Add("x-accela-environment", sharedSetting.Environment);
                }

                if (headerList.AllKeys.Contains("authorization"))
                {
                    headerList["authorization"] = sharedSetting.AccessToken;
                }
                else
                {
                    headerList.Add("authorization", sharedSetting.AccessToken);
                }
            }
            //if (sharedSetting != null)
            //{
            //    headerList.AllKeys.Contains("Content-Type")
            //    var enumerator = headerList.GetEnumerator();

            //    while(enumerator.MoveNext())
            //    {
            //        //enumerator.Current.
            //    }
            //}

            return headerList;
        }

        private void SaveRequestData(string name)
        {
            /* file format
             ----------RequestURL----------
             RequestURL={0}
             ----------RequestURL----------
             ----------RequestHeader----------
             RequestHeader={1}
             ----------RequestHeader----------
             ----------RequestBody----------
             RequestBody={2}
             ----------RequestBody----------
             */

            string fileFormat = @"----------RequestURL----------
RequestURL={0}
----------RequestURL----------
----------RequestHeader----------
RequestHeader={1}
----------RequestHeader----------
----------RequestBody----------
RequestBody={2}
----------RequestBody----------";

            string requestUrl = this.txtRequestUrl.Text.Trim();
            string requestHeader = this.txtRequestHeader.Text.Trim();
            string requestBody = this.txtRequestBody.Text.Trim();
            string content = String.Format(fileFormat, requestUrl, requestHeader, requestBody);
            try
            {
                FileUtility.WriteFile(name + ".txt", content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        private void cmbURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                groupResponse.Text = "Response";
                string selected = cmbURL.Text as string;
                if (string.IsNullOrEmpty(selected))
                {
                    return;
                }

                RequestEntity re = FileUtility.GetRequestDataFromFile(selected);
                if (re != null)
                {
                    // get host
                    string host = "";
                    var selectHost = this.cmbHosts.SelectedItem as HostEntity;
                    if (selectHost != null)
                    {
                        host = selectHost.HostUrl;
                    }

                    if (!String.IsNullOrWhiteSpace(host) && re.RequestURL.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        int pos = re.RequestURL.IndexOf("/", 8);
                        if (!host.EndsWith("/"))
                        {
                            host += "/";
                        }
                        this.txtRequestUrl.Text = (host + re.RequestURL.Substring(pos + 1)).Replace("\r", "");
                    }
                    else
                    {
                        this.txtRequestUrl.Text = re.RequestURL.Replace("\r", "");
                    }

                    this.txtRequestHeader.Text = re.RequestHeader;
                    this.txtRequestBody.Text = re.RequestBody;
                    this.txtSaveAs.Text = selected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                SharedHttpHeaderSettingEntity settingObj = new SharedHttpHeaderSettingEntity();
                settingObj.ContentType = this.txtContentType.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.AppId = this.txtAppID.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.AppSecret = txtAppSecret.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.GetTokenRequestUrl = this.txtRequestUrlForGettingToken.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.GetTokenRequestBody = txtRequestBodyForGettingToken.Text.Trim().Replace("\r\n", String.Empty);

                settingObj.Agency = txtAgency.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.Environment = txtEnvironment.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.AccessKey = txtAccessKey.Text.Trim().Replace("\r\n", String.Empty);

                if (string.IsNullOrWhiteSpace(settingObj.ContentType)
                    || string.IsNullOrWhiteSpace(settingObj.AppId)
                    || string.IsNullOrWhiteSpace(settingObj.AppSecret)
                    || string.IsNullOrWhiteSpace(settingObj.GetTokenRequestUrl)
                    || string.IsNullOrWhiteSpace(settingObj.GetTokenRequestBody)
                    || string.IsNullOrWhiteSpace(settingObj.Agency)
                    || string.IsNullOrWhiteSpace(settingObj.Environment)
                    || this.cmbHostsTab2.SelectedItem == null
                    )
                {
                    MessageBox.Show("Please enter all required fields.");
                    return;
                }
                var selectedHost = this.cmbHostsTab2.SelectedItem as HostEntity;
                FileUtility.WriteHttpHeaderSettingFile(settingObj, selectedHost);


                MessageBox.Show("Update Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnGenerateToken_Click(object sender, EventArgs e)
        {
            try
            {
                SharedHttpHeaderSettingEntity settingObj = new SharedHttpHeaderSettingEntity();
                settingObj.ContentType = this.txtContentType.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.AppId = this.txtAppID.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.AppSecret = txtAppSecret.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.GetTokenRequestUrl = this.txtRequestUrlForGettingToken.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.GetTokenRequestBody = txtRequestBodyForGettingToken.Text.Trim().Replace("\r\n", String.Empty);

                settingObj.Agency = txtAgency.Text.Trim().Replace("\r\n", String.Empty);
                settingObj.Environment = txtEnvironment.Text.Trim().Replace("\r\n",String.Empty);
                settingObj.AccessKey = txtAccessKey.Text.Trim().Replace("\r\n", String.Empty);

                if(string.IsNullOrWhiteSpace(settingObj.ContentType)
                    || string.IsNullOrWhiteSpace(settingObj.AppId)
                    || string.IsNullOrWhiteSpace(settingObj.AppSecret)
                    || string.IsNullOrWhiteSpace(settingObj.GetTokenRequestUrl)
                    || string.IsNullOrWhiteSpace(settingObj.GetTokenRequestBody)
                    || string.IsNullOrWhiteSpace(settingObj.Agency)
                    || string.IsNullOrWhiteSpace(settingObj.Environment)
                    || this.cmbHostsTab2.SelectedItem == null
                    )
                {
                    MessageBox.Show("Please enter all required fields.");
                    return;
                }
                var selectedHost = this.cmbHostsTab2.SelectedItem as HostEntity;

                FileUtility.WriteHttpHeaderSettingFile(settingObj, selectedHost);
                SHARED_HTTP_HEADER_SETTING = settingObj;

                // send request to get access token
                ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return (true); };
                HttpClient client = new HttpClient();
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, settingObj.GetTokenRequestUrl);
                requestMessage.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

                requestMessage.Content = new StringContent(settingObj.GetTokenRequestBody, Encoding.UTF8, "application/x-www-form-urlencoded");
                
                var task = client.SendAsync(requestMessage,HttpCompletionOption.ResponseContentRead);
                
                await task.ContinueWith((requestTask) =>
                {
                    if (requestTask.IsCompleted && requestTask.Status == TaskStatus.RanToCompletion)
                    {
                         settingObj.AccessToken = this.txtResponseToken.Text =ParseToken( requestTask.Result.Content.ReadAsStringAsync().Result);
                         FileUtility.WriteHttpHeaderSettingFile(settingObj, selectedHost);
                    }
                    else
                    {
                        MessageBox.Show("Failed to generate access token, please try again.");
                        return;
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateToken(string requestURL, string requestBody)
        {
            if (String.IsNullOrWhiteSpace(requestURL) || String.IsNullOrWhiteSpace(requestBody))
            {
                 throw new ArgumentNullException("requestURL or requestBody");
            }
            // send request to get access token
            ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return (true); };
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, requestURL);
            requestMessage.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            requestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");

            var task = client.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead);

            task.ContinueWith((response) =>
            {
                if (response.IsCompleted && response.Status == TaskStatus.RanToCompletion)
                {
                    if (SHARED_HTTP_HEADER_SETTING == null)
                        SHARED_HTTP_HEADER_SETTING = new SharedHttpHeaderSettingEntity();

                    SHARED_HTTP_HEADER_SETTING.AccessToken = ParseToken(response.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    MessageBox.Show("Failed to generate access token, please try again.");
                    return;
                }
            });
        }

        private string ParseToken(string tokenObj)
        {
            //{"access_token":"BaTnHQjVRoUvUiKrpAav7ocnKK4NODi-e9eWjKJUvIK-Y6y4BuoqxQXLJvVzgeCedLhVfGI9Pb0hFng6qRxJFV4DWxq1F0TYdINZWRjVoufe_Qc3c5e9N_GvgoxNiv89bS76_9hq09yOyYwtkr1hsnRlanbocnSj4AH_t2l0qqjy8BZTIubP5AxStxQokOYx0QP1NWB5LQ7AEhQbdYCrlKMpce4dDXS4JPeTUqFd0crkh53Jt3ZQunGXCLhYgA2hnozbsxS8L40JOE3kqkLyu08jYawxdfcy7PNXwrpzZ5AoCkRKs2KrEfxdb0bVi4AEOE33xeJajfzMQxou6YtlGzcy-cBknZ-yELYuwvRAJoXLeAkfaHDhDILxMK0nNcZdO7Y8XJH4V19-J8dS-luc1IIcsaxBTvEszGRKo-h7l8P4vm4vFsjsvdlvZi-QpZecdv-YMfe0bmFp-Yiq47XbW_TPz92e-eEM6qQ4l3A6RYXJ4T6_wQVELnzmFXd6V-C3jvi9buLki2Ej9L2Tf0o30gRIT2NHgKiXgq41cZXKOq2vncuH9w5T4lIaJx_z8VL6kWUO3tFmwr2RF7QsxJA6MLm7Ciq3FfZTFT_e66obo7x8loJsMQeoCguEp4mMTOnYSJ0u15WCq-dhzM0dgwfEqAg-At09BHFeBBPND3YreEjszlezcJ6HiszVJNWRJx1k0",
            //"token_type":"bearer",
            //"expires_in":"86400",
            //"refresh_token":"NNn5!IAAAAHHjD5WnVDx_peUahDxY1S2GwUfAs6UmOYyvJrc9XKT7wQEAAAHmnNAdQMzjUmTi2a7xh3ic4Z-ms_syKyCyfW4WDT7M01azBU3sMc1UVSrzx9qKjloXg6bfo33uijWxw_sdThEDuA7n5_ljpX_JTH152tu6vZsz1UjYD_EYg2QN1j4d4hoM7pFfanGq8moou7IOt7xEoloZyTw7pK5qVbyDkYRXTn-ZvGGI8GeG0Y63YI_MEOA_n8hwZJzqpgWVGNu8pTXJTpE1DKUXJZi7JJjTzh7KaiBxLFIcDPcyFLKJ24MyL7BONxypPZWP1OmjVzl9HqrXPmWLObx8PNbli8OkVX4T2hGW9vADlBowiaYDxYnLEactaib5dXE92v8ArjpJMUiHKPothmQWgTVTdgNeG-YKcXx1uOOUKwMBAbQixuuIqvQDzv9K_rKj-X8g4NdXaCfbfxNbeEtG195MGDjYqNyT_6O09g1UtXiAYsLZ0oa5tedIJHJxqf_sZ2Zrmv2OJZAvMg9bVBSlJ-ysZ9TWq3JDoG2RHvd8QX0v4HRU9PUjxOD_gmnNdSt8MhvSilEffLmFsvJ510Lk6t8QIzOzllv3tTMep6Q7jKbkasVL1uMzGRL50mor9WB_Df0P5KYixTg1",
            //"scope":"addresses conditions contacts documents get_civicid_profile get_inspection_checklist_items get_record_customtables get_settings_record_statuses inspections owners parcels payments professionals records reports run_generic_search settings"}
            string error = "Invalid Token string, maybe error is raised while getting token.";
            if(String.IsNullOrWhiteSpace(tokenObj) || tokenObj.Length < 20)
            {
                throw new Exception(error);
            }

            int indexEndPos = tokenObj.IndexOf("\",\"");
            int indexStartPos = tokenObj.IndexOf("\":\"");

            if(indexEndPos == -1 || indexStartPos == -1 || indexEndPos <= indexStartPos)
            {
                throw new Exception(error);
            }

            if (tokenObj.StartsWith("{\"error\""))
            {
                return tokenObj;
            }
            string token = tokenObj.Substring(indexStartPos + 3, indexEndPos - indexStartPos - 3);

            return token;
        }

        private void txtRequestBodyForGettingToken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                txtRequestBodyForGettingToken.SelectAll();
        }

        private void txtResponseToken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                txtResponseToken.SelectAll();
        }

        private void txtEnvironment_TextChanged(object sender, EventArgs e)
        {
            ChangeRequestBodyByKey("environment", txtEnvironment.Text.Trim());
        }

        private void txtAgency_TextChanged(object sender, EventArgs e)
        {
            ChangeRequestBodyByKey("agency_name", txtAgency.Text.Trim());
        }

        private void txtAppSecret_TextChanged(object sender, EventArgs e)
        {
            ChangeRequestBodyByKey("client_secret", txtAppSecret.Text.Trim());
        }

        private void txtAppID_TextChanged(object sender, EventArgs e)
        {
            ChangeRequestBodyByKey("client_id", txtAppID.Text.Trim());
        }

        private void ChangeRequestBodyByKey(string key,string value)
        {
            string requestBody = this.txtRequestBodyForGettingToken.Text.Trim();
            var kvs = requestBody.Split('&');

            foreach(var s in kvs)
            {
                if(s.IndexOf(key) > -1)
                {
                    this.txtRequestBodyForGettingToken.Text = requestBody.Replace(s, String.Format("{0}={1}", key, value));
                    break;
                }
            }
        }

        private void RegenerateTokenWhenMoreThan24Hours()
        {
            if ((DateTime.Now - this.LastExecuteTime).Hours > 23)
            {
                this.LastExecuteTime = DateTime.Now;
                btnGenerateToken_Click(null, null);
            }
        }

        private void btnHostSave_Click(object sender, EventArgs e)
        {
            try
            {
                var hosts = new List<HostEntity>();

                string content = this.txtAllHosts.Text.Trim();

                if (!String.IsNullOrWhiteSpace(content))
                {
                    var lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    lines.ToList().Where(l => !String.IsNullOrWhiteSpace(l)).ToList().
                        ForEach(l =>
                        {
                            var keyValue = l.Split(new char[] { ' ' });
                            if (keyValue.Length == 2)
                            {
                                hosts.Add(new HostEntity { Name = keyValue[0], HostUrl = keyValue[1] });
                            }
                        }
                );
                }


                if (hosts == null || hosts.Count == 0)
                {
                    MessageBox.Show("Please check the format, At least one host is required.");
                    return;
                }
                else
                {
                    FileUtility.WriteHostsToFile(hosts);
                    HOSTS = hosts;
                    //BindHostsToDataGrid(HOSTS);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void BindHostsToDataGrid(List<HostEntity> hosts)
        //{
        //    DataGridViewTextBoxColumn column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    column1.DataPropertyName = "Name";
        //    column1.HeaderText = "Name";
        //    column1.Name = "Name";
        //    column1.Width = 200;

        //    DataGridViewTextBoxColumn column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    column2.DataPropertyName = "HostUrl";
        //    column2.HeaderText = "HostUrl";
        //    column2.Name = "HostUrl";
        //    column2.Width = 500;

        //    dataGridView1.AllowUserToAddRows = true;
        //    this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {column1, column2 });

        //    this.dataGridView1.DataSource = hosts;
        //}

        private void ShowHostsToHostsText(List<HostEntity> hosts)
        {
            StringBuilder sbContent = new StringBuilder();
            if(hosts != null)
            {
                int i = 0;
                foreach(var h in hosts)
                {
                    if(i>0)
                    {
                        sbContent.Append("\r\n");
                    }
                    
                    sbContent.Append(String.Format("{0} {1}", h.Name, h.HostUrl));
                    i++;
                }
            }

            this.txtAllHosts.Text = sbContent.ToString();
        }

        private void txtAllHosts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                txtAllHosts.SelectAll();
        }

        private void cmbHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // get host
                string host = "";
                string requestUrl = "";
                var selectHost = this.cmbHosts.SelectedItem as HostEntity;
                if (selectHost == null)
                {
                    return;
                }

                host = selectHost.HostUrl;
                requestUrl = this.txtRequestUrl.Text.Trim();

                if (!String.IsNullOrWhiteSpace(host) && requestUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    int pos = requestUrl.IndexOf("/", 8);
                    if (!host.EndsWith("/"))
                    {
                        host += "/";
                    }
                    this.txtRequestUrl.Text = (host + requestUrl.Substring(pos + 1)).Replace("\r", "");
                }

                LoadSharedHttpHeaderSetting(selectHost);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbHostsTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectHost = this.cmbHostsTab2.SelectedItem as HostEntity;
            //if (selectHost == null)
            //{
            //    return;
            //}

            LoadSharedHttpHeaderSetting(selectHost);
        }
    }
}
