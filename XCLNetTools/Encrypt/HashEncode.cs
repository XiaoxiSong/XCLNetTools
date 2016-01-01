﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace XCLNetTools.Encrypt
{
    /// <summary>
    /// 得到随机安全码（哈希加密）。
    /// </summary>
    public class HashEncode
    {
        /// <summary>
        /// 得到随机哈希加密字符串
        /// </summary>
        /// <returns></returns>
        public static string GetSecurity()
        {
            return HashEncoding(GetRandomValue());
        }

        /// <summary>
        /// 得到一个随机数值
        /// </summary>
        public static string GetRandomValue()
        {
            return new Random().Next(1, int.MaxValue).ToString();
        }

        /// <summary>
        /// 哈希加密一个字符串
        /// </summary>
        public static string HashEncoding(string security)
        {
            byte[] value;
            UnicodeEncoding code = new UnicodeEncoding();
            byte[] message = code.GetBytes(security);
            SHA512Managed Arithmetic = new SHA512Managed();
            value = Arithmetic.ComputeHash(message);
            security = "";
            foreach (byte o in value)
            {
                security += (int)o + "O";
            }
            return security;
        }
    }
}