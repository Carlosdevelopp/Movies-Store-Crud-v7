﻿namespace Infrastructure.Utils
{
    public static class Extensions
    {
        public static string TitleFormat(this string text)
        {
            if (text.Contains(""))
            {
                text = text.Replace(text, $"*{text}*");
            }

            return text;
        }

        public static string TextUpperCase(this string text)
        {
            if (text.Contains(""))
            {
                text = text.Replace(text, $"{text.ToUpper()}");
            }

            return text;
        }

        public static string ToShortDate(this DateTime dt)
        {
            string date = dt.ToString("dd/MM/yyyy");

            return date;
        }

        public static string FormatTime(this int date)
        {
            return string.Format($"#{date}");
        }

        public static string AwardText(this string text)
        {
            if (text.Contains(""))
            {
                text = text.Replace(text, $"Award: {text.ToUpper()}");
            }

            return text;
        }
    }
}
