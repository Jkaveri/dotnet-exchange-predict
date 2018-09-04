namespace ExchangePredict.BuildBlocks.Helpers
{
    using System.Collections.Generic;

    public static class CommandLIneParser
    {
        public static Dictionary<string, string> Parse(string[] args)
        {
            var result = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i++)
            {
                var splits = args[i].Split("=");
                string key = string.Empty;
                string value = string.Empty;
                if (splits.Length < 2)
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(splits[0]))
                {
                    key = splits[0];
                    value = splits[1];
                    if (result.ContainsKey(key))
                    {
                        result[key] = value;
                    }
                    else
                    {
                        result.Add(key, value);
                    }
                }
            }
            return result;
        }
    }
}
