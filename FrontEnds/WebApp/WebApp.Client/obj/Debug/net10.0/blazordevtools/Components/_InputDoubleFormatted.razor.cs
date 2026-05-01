using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WebApp.Client.Components
{
    public class _InputDoubleFormattedBase : InputBase<double?>
    {
       protected bool IsValidInput { get; set; } = true;

        protected bool IsValidDoubleString(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return true;
            var sanitized = value.Replace(".", string.Empty).Replace(',', '.');
            return double.TryParse(sanitized, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out _);
        }

        protected override bool TryParseValueFromString(string value, out double? result, out string validationErrorMessage)
        {
            validationErrorMessage = string.Empty;
            result = null;

            if (string.IsNullOrWhiteSpace(value))
                return true;

            string sanitized = value.Replace(".", string.Empty).Replace(',', '.');
            if (double.TryParse(sanitized, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var parsed))
            {
                result = parsed;
                IsValidInput = true;
                return true;
            }
            else
            {
                IsValidInput = false;
                return false;
            }
        }

        protected override string FormatValueAsString(double? value)
        {
            if (value == null) return string.Empty;
            return value.Value.ToString("#,0.##", new CultureInfo("es-ES"));
        }

        protected void OnInput(ChangeEventArgs e)
        {
            var input = e.Value?.ToString() ?? string.Empty;
            var filtered = FilterInput(input);

            if (double.TryParse(input.ToString(), out _) == false)
            {
                if (IsValidDoubleString(input.ToString()))
                    IsValidInput = true;        //1.123,12
                else
                    IsValidInput = false;       //123A
             
                //////////////////CurrentValueAsString = input;   //even if IsValidInput = false; we bind to force set the control as no valid for FluentValidation
            }
            else
                CurrentValueAsString = filtered;

        }

        private string FilterInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            // Solo números, puntos, comas, - al principio
            input = Regex.Replace(input, @"[^0-9\.,\-]", "");

            // Solo un - al principio
            if (input.Count(c => c == '-') > 1 || (input.Contains('-') && input[0] != '-'))
                input = input.Replace("-", "");

            // Solo una coma
            var parts = input.Split(',');
            if (parts.Length > 2)
                input = string.Join(",", parts.Take(2));

            // Formatear miles
            var commaIdx = input.IndexOf(',');
            string left = commaIdx >= 0 ? input.Substring(0, commaIdx) : input;
            string right = commaIdx >= 0 ? input.Substring(commaIdx) : "";
            left = left.Replace(".", "").Replace(",", "");
            left = AddThousandsSeparator(left);
            return left + right;
        }

        private string AddThousandsSeparator(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            bool negative = input.StartsWith("-");
            if (negative)
                input = input.Substring(1);
            if (input.Length <= 3)
                return negative ? "-" + input : input;
            int start = input.Length % 3;
            var parts = new List<string>();
            if (start != 0)
                parts.Add(input.Substring(0, start));
            for (int i = start; i < input.Length; i += 3)
                parts.Add(input.Substring(i, 3));
            var result = string.Join(".", parts);
            return negative ? "-" + result : result;
        }
    }
}