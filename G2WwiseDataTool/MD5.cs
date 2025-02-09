﻿using System.Text;
using System.Security.Cryptography;

namespace G2WwiseDataTool
{
    public class MD5
    {
        public static string ConvertStringtoMD5(string inputString)
        {
            // from RPKG-Tool https://github.com/glacier-modding/RPKG-Tool/blob/dd86901f4a3a64b2a358a4ea607fa144e7fc2cfa/rpkg-gui/HashCalculator.xaml.cs#L94

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            inputString = inputString.Trim().ToLower().Replace("\\", "/");

            byte[] stringBytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hashBytes = md5.ComputeHash(stringBytes);

            StringBuilder ioiHashsb = new StringBuilder("00", 16);
            for (int i = 1; i < 8; i++)
            {
                ioiHashsb.Append(hashBytes[i].ToString("X2"));
            }
            return ioiHashsb.ToString();
        }
    }
}
