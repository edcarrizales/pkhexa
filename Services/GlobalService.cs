using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PkHexA.Services
{
    public static class GlobalService
    {
        public static SaveFile ACTUAL_FILE;

        public static string ReplaceTokens(string template, Dictionary<string, string> tokens)
        {
            if (string.IsNullOrWhiteSpace(template))
                return template;

            foreach (var t in tokens)
            {
                string key = "{" + t.Key + "}";   // ejemplo → {VERSION}
                template = template.Replace(key, t.Value);
            }

            return template;
        }
        public static string KeyToData(string k) {
            switch (k) {
                case "{VERSION}":
                    return ACTUAL_FILE.Version.ToString();
                default:
                    return "";
            }
        }
        public static Task ShowAlertAsync(string? message, string? cancel = "OK")
        {
            string title = "PkHexA";
            message ??= string.Empty;
            cancel ??= "OK";

            return MainThread.InvokeOnMainThreadAsync(
                async () => await (Shell.Current?.DisplayAlertAsync(title, message, cancel) ?? Task.CompletedTask)
            );
        }
    }
}
