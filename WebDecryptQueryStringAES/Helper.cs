using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebDecryptQueryStringAES
{
    public class Helper
    {
       
        public T GetQueryString<T>(string q, string key, string iv)
        {
            var queryString = decryptString(key, iv, q);  // ได้ plain text  query string 
            var dict = HttpUtility.ParseQueryString(queryString); // นำ query string   convert  เป็น  name / value collection
            var json = JsonConvert.SerializeObject(dict.Cast<string>().ToDictionary(k => k, v => dict[v])); // convert เป็น  name / value collection  เป็น Dictionary  (key / value)   และ นำ Dictionary ไป   SerializeObject เป็น  json strnig    
            return JsonConvert.DeserializeObject<T>(json); //  DeserializeObject   json string  เป็น Object Complex Type  (T is class QueryStringUrl)
        }

        private string decryptString(string key, string iv, string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create()) //AES stands for “Advanced Encryption Standard” and it is an official international standard(ISO / IEC 18033-3)
            {
                aes.Mode = CipherMode.CBC;
                aes.KeySize = 256; // AES encryption key needs to be either 128, 192, or, 256
                aes.BlockSize = 128; //AES algorithm supports 128, 198, and 256-bit encryption.
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Convert.FromHexString(key); // กำหนดให้
                aes.IV = Convert.FromHexString(iv); // กำหนดให้  called initialization vector generate more entropy in the resulting encrypted data. This will make it more difficult to identify patterns in it.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
