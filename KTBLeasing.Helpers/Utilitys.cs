﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;//[20131202] Thawatchai.T
//CR118
//Generate MD5


namespace KTBLeasing.Helpers
{
  

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Utilitys
    {
        public static string GenerateMD5(string input)
        {
            string key = "pomnotwoody";
            input = string.Format("{0,1}", key, input);
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data);
        }

        public static string ConvertOjbToString<T>(T ojb)
        {
            return  JsonConvert.SerializeObject(ojb);
        }

    }
}
