using System;
using System.IO;
using System.Security.Cryptography;

namespace DoDo.Open.Sdk.Utils
{
    public class EncryptUtil
    {
        /// <summary>
        /// WebHook解密
        /// </summary>
        /// <param name="payload">加密消息</param>
        /// <param name="secretKey">解密密钥</param>
        /// <returns></returns>
        public static string WebHookDecrypt(string payload, string secretKey)
        {
            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.Key = HexStringToBytes(secretKey);
            aes.IV = new byte[aes.BlockSize / 8];
            aes.Mode = CipherMode.CBC;

            var decipher = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream(HexStringToBytes(payload)))
            {
                string decrypted;

                using (var cs = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        decrypted = sr.ReadToEnd();
                    }
                }

                return decrypted;
            }
        }

        /// <summary>
        /// 16进制字符串转Byte数组
        /// </summary>
        /// <param name="hexStr">16进制字符</param>
        /// <returns></returns>
        private static byte[] HexStringToBytes(string hexStr)
        {
            var bytes = new byte[hexStr.Length / 2];
            for (var x = 0; x < bytes.Length; x++)
            {
                var i = Convert.ToInt32(hexStr.Substring(x * 2, 2), 16);
                bytes[x] = (byte)i;
            }
            return bytes;
        }

    }
}
