using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public static class CSVParser
{
    // Very small CSV parser that supports quoted fields with commas and double-quote escaping.
    // Returns a list of dictionaries keyed by the header name.
    public static List<Dictionary<string, string>> Parse(string csv)
    {
        var rows = new List<Dictionary<string, string>>();
        if (string.IsNullOrEmpty(csv)) return rows;

        var lines = SplitLines(csv);
        if (lines.Count == 0) return rows;

        var headers = ParseCsvLine(lines[0]);
        for (int i = 1; i < lines.Count; i++)
        {
            var values = ParseCsvLine(lines[i]);
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int h = 0; h < headers.Count; h++)
            {
                var key = headers[h];
                var val = h < values.Count ? values[h] : string.Empty;
                dict[key] = val;
            }
            // Skip empty rows (all values empty)
            bool allEmpty = true;
            foreach (var v in dict.Values) { if (!string.IsNullOrWhiteSpace(v)) { allEmpty = false; break; } }
            if (!allEmpty) rows.Add(dict);
        }
        return rows;
    }

    static List<string> SplitLines(string s)
    {
        var list = new List<string>();
        using (var reader = new System.IO.StringReader(s))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Keep blank lines as empty strings
                list.Add(line);
            }
        }
        return list;
    }

    static List<string> ParseCsvLine(string line)
    {
        var values = new List<string>();
        if (line == null) return values;

        // Regex splits CSV respecting quoted fields. Handles "" escape inside quotes.
        // Explanation: match either "quoted string" or unquoted token separated by commas.
        var pattern = @"\s*(?:(?:""((?:[^""]|"""")*)"")|([^,]*))\s*(?:,|$)";
        foreach (Match m in Regex.Matches(line, pattern))
        {
            string quoted = m.Groups[1].Value;
            string unquoted = m.Groups[2].Value;
            if (!string.IsNullOrEmpty(quoted))
            {
                values.Add(quoted.Replace("\"\"", "\""));
            }
            else
            {
                values.Add(unquoted);
            }
        }
        return values;
    }
}