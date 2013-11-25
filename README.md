# Nustache.i18n
This library aims to be an helper to discover localizable tags on a template. Although it doesn't make use of Nustache directly, it searches for tags that are conform to this standard:

```mustache
{{ localize "key" }}
```

## Installation
Just search for `Nustache.i18n` on NuGet and install it in your solution.

## Usage
Nustache.i18n provides two simple, but effective, methods to translate templates.

### Localizable tags extraction
This method allows you to search for all the localizable tags on the template.
```csharp
string template = File.ReadAllText("file");
List<string> keys = Localizer.ExtractLocalizableKeys(template);
```

### Effective Translation
This method does the actual translation. You can also provide a placeholder that will come up when a translation cannot be found.
```csharp
string placeholder = "<translation.missing>";
var translations = new Dictionary<string, string>
{
    { "hello", "ciao" },
    { "world", "mondo" }
};
string template = "{{tag1}} {{ localize \"hello\" }}, {{ localize \"world\" }} {{tag2}}";

string translated = Localizer.Translate(template, translations, placeholder);
// Output: {{tag1}} ciao, mondo {{tag2}}
```

Note in the example above that any other tag that is not localizable will be kept as-is.
