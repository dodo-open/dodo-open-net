using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiBaseOutput<T> : OpenApiBaseOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }

    public class OpenApiBaseOutput
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
        
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
