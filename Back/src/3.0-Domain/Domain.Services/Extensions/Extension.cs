using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.Extensions
{
    public static class Extension
    {
        public static string RemoveDotsDashBars(this string value)
        {
            var newValue = string.Empty;

            if (!string.IsNullOrEmpty(value))
                newValue = value.Replace(".", "").Replace("/", "").Replace("-", "");

            return newValue;
        }

        public static bool NotIsNullOrEmpty(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return true;

            return false;
        }

        public static bool IsValidCpf(this string cpf)
        {
            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = cpf.Trim();
            cpf = cpf.RemoveDotsDashBars();

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];
            }

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            tempCpf = tempCpf + digit;

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];
            }

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        public static bool IsValidCnpj(this string cnpj)
        {
            int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;

            cnpj.Trim();
            cnpj = cnpj.RemoveDotsDashBars();

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * mult1[i];
            }

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            tempCnpj = tempCnpj + digit;

            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * mult2[i];
            }

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cnpj.EndsWith(digit);
        }
    }
}