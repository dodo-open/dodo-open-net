namespace DoDo.Open.Sdk.Models
{
    public class OpenApiBaseOutput<T> : OpenApiBaseOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }

    public class OpenApiBaseOutput
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
    }
}
