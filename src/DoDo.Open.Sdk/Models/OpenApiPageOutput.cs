using System.Collections.Generic;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiPageOutput<T>
    {
        public OpenApiPageOutput()
        {
            List = new List<T>();
        }

        /// <summary>
        /// 最大ID值
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> List { get; set; }
    }
}
