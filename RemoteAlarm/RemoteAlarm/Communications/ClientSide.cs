using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace RemoteAlarm.Communications
{
    public class ClientSide
    {

        private readonly string _serverPath;
        private static ClientSide _clientInstance;


        //private HttpClient _httpClient;


        public static ClientSide Instance
        {
            get
            {
                if (_clientInstance == null)
                    _clientInstance = new ClientSide();        
                
                return _clientInstance;
            }
        }

        private ClientSide()
        {
            //_serverPath
            var obj = new object();
            //var sss = Application.Current.Properties.TryGetValue("serverLocation", out obj);
            _serverPath = "http://192.168.1.158:8000";
        }

        public async Task RequestAlarm()
        {
            string alarmPath = String.Concat(_serverPath,"/alarm");
            await RefreshDataAsync(alarmPath);

        }

        public void SetAlarm(string message)
        {
            string alarmPath = String.Concat(_serverPath, "/alarm");
            //await RefreshDataAsync(alarmPath);
        }

        public async Task RequestLight()
        {
            string alarmPath = String.Concat(_serverPath, "/light");
            await RefreshDataAsync(alarmPath);
        }

        public void SetLight()
        {
            
        }


        private async Task<string> RefreshDataAsync(string serverPath)
        {
            string alarmData = String.Empty;
            try
            {
                var _httpClient = new HttpClient();
                _httpClient.MaxResponseContentBufferSize = 256000;
                _httpClient.Timeout = TimeSpan.FromMilliseconds(500);
            
                var response = await _httpClient.GetAsync(serverPath);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    alarmData = JsonConvert.DeserializeObject<string>(content);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                
            }
          
            return alarmData;
        }

    }
}
