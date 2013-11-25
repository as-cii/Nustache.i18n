using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nustache.i18n
{
    /// <summary>
    /// Localization helper that recognizes mustache tags that adopt the standard `{{ localize "key" }}`.
    /// </summary>
    public static class Localizer
    {
        private static readonly Regex tagMatcher = new Regex("{{\\s*localize\\s+\"([a-zA-Z0-9_-]+)\"\\s*}}");
        
        /// <summary>
        /// Extracts keys that are localizable (e.g. use `localize` helper).
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <example>{{ localize "key1" }} would return key1.</example>
        /// <returns>Returns localizable keys.</returns>
        public static List<string> ExtractLocalizableKeys(string text)
        {
            return tagMatcher.Matches(text)
                             .OfType<Match>()
                             .Select(a => a.Groups[1].Value)
                             .Distinct()
                             .ToList();
        }

        /// <summary>
        /// Translates a text using localizable tags inserting a placeholder if some of them
        /// is missing.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="translations">The translations dictionary.</param>
        /// <param name="placeholder">The placeholder text.</param>
        /// <returns>Returns a localized text.</returns>
        public static string Translate(string text, Dictionary<string, string> translations, string placeholder)
        {
            return tagMatcher.Replace(text, match =>
            {
                string key = match.Groups[1].Value;

                return translations.ContainsKey(key) ?
                    translations[key] :
                    placeholder;
            });
        }
    }
}
