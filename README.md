# Nustache.i18n
This library aims to be an helper to discover localizable tags on a template. Although it doesn't make use of Nustache directly, it searches for tags that are conform to this standard:

```mustache
{{ localize "key" }}
```

## Usage
Nustache.i18n provides two simple, but effective, methods to translate templates.

### Localizable tags extraction
This helper allows you to search for all the localizable tags on the template.
```csharp
string template = File.ReadAllText("file");
List<string> keys = Localizer.ExtractLocalizableKeys(template);
```

### Effective Translation
This helper does the actual translation. You can also provide a placeholder that will come up when a translation cannot be found.
```csharp
string placeholder = "<translation.missing>";
var translations = new Dictionary<string, string>
{
    { "hello", "ciao" },
    { "world", "mondo" }
};
string template = "{{ localize \"hello\" }}, {{ localize \"world\" }}";

string translated = Localizer.Translate(template, translations, placeholder);
```

This method will ignore and keep every other tag that is present on the template, substituting only the localizable ones.
