using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthApp.RestClient
{
    public class RestClient : IRestClient
    {
        private readonly int timeOut = 60;
        public Task<bool> DeleteAsync(string url)
        {
            throw new NotImplementedException();
        }
        public RestClient()
        {

        }
        public RestClient(int timeOut)
        {
            this.timeOut = timeOut;
        }
        public async Task<HttpResponseMessage> GetAsync(string url, CancellationToken? token = null)
        {
            if (token != null)
            {
                token.Value.ThrowIfCancellationRequested();
                return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetAsync(url, token.Value);
            }

            else
                return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetAsync(url);
        }

        public async Task<T> GetAsync<T>(string url, CancellationToken? token = null)
        {
            HttpResponseMessage responseMessage;
            if (token != null)
            {
                token.Value.ThrowIfCancellationRequested();
                responseMessage = await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetAsync(url, token.Value);
                token.Value.ThrowIfCancellationRequested();
            }
            else
                responseMessage = await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetAsync(url);
            // Đọc content từ server trả về
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<byte[]> GetByteArrayAsync(string url)
        {
            return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetByteArrayAsync(url);
        }

        public async Task<Stream> GetStreamAsync(string url)
        {
            return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.GetStreamAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T t, CancellationToken? token = null)
        {
            var content = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            if (token != null)
                return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.PostAsync(url, httpContent, token.Value);
            else
                return await new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) }.PostAsync(url, httpContent);
        }

        public async Task<T> PostAsync<T, TP>(string url, TP t, CancellationToken? token = null)
        {
            var content = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage responseMessage;
            string responseContent = "";
            try
            {
                var http = new HttpClient() { Timeout = TimeSpan.FromSeconds(timeOut) };
                if (token != null)
                {
                    token.Value.ThrowIfCancellationRequested();
                    responseMessage = await http.PostAsync(url, httpContent, token.Value);
                    token.Value.ThrowIfCancellationRequested();
                }
                else
                    responseMessage = await http.PostAsync(url, httpContent);
                responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception )
            {
                return default;
            }
        }

        public Task<HttpResponseMessage> PostFunctionAsync<T>(string url, T t, CancellationToken? token = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostFunctionAsync<T, TP>(string url, TP t, CancellationToken? token = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutAsync<T>(string url, T t)
        {
            throw new NotImplementedException();
        }
    }
}
