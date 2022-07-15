using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiCallback
    {
        /// <summary>
        /// 接口
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// 入参
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// 出参
        /// </summary>
        public string Response { get; set; }
    }
}
