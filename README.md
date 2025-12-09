# HtmlToAvalonia

A library that converts HTML strings with CSS formatting into Avalonia UI controls.

This library does not intend to to be a pixel-perfect replica of a web browser. 
The main goal is to make it easier for non-technical users of typical WYSIWYG editors 
to contribute rich content to Avalonia applications.

## Features

- **HTML Parsing**: Uses AngleSharp for standards-compliant HTML parsing
- **CSS Support**: CSS styling support using AngleSharp.Css with `GetComputedStyle`
- **Text Formatting**: Supports bold, italic, underline, headings, and custom styles
- **Layout**: Handles block and inline elements, tables with colspan/rowspan, and text alignment
- **Color Support**: Parses named colors, hex colors, and rgb/rgba values
- **Font Styling**: Font size, weight, style, and decorations

## Installation

Add the NuGet package to your project:

```bash
dotnet add package HtmlToAvalonia
```

## Usage

### Basic Usage

```csharp
using HtmlToAvalonia;
using Avalonia.Controls;

// Simple text with formatting
var html = "<p>Hello <b>World</b>!</p>";
Control control = HtmlConverter.ToAvalonia(html);

// With CSS styling
var styledHtml = @"
    <div style='color: red; font-size: 16px;'>
        <p>This is <b>bold</b> and <i>italic</i> text.</p>
    </div>";
Control styledControl = HtmlConverter.ToAvalonia(styledHtml);

// With tables
var tableHtml = @"
    <table>
        <tr>
            <th>Header 1</th>
            <th>Header 2</th>
        </tr>
        <tr>
            <td>Cell 1</td>
            <td>Cell 2</td>
        </tr>
    </table>";
Control tableControl = HtmlConverter.ToAvalonia(tableHtml);

// With alignment
var centeredHtml = "<center><h1>Centered Title</h1></center>";
Control centeredControl = HtmlConverter.ToAvalonia(centeredHtml);
```

### Advanced Usage with Optional Parameters

The `ToAvalonia` method accepts optional parameters to customize the rendering context:

```csharp
var control3 = HtmlConverter.ToAvalonia(
    html,
    // Specify custom viewport dimensions (useful for responsive layouts)
    viewportWidth: 1024,
    viewportHeight: 768,
    // Specify custom base font size for em/rem calculations
    fontSize: 14.0
);
```

**Parameters:**
- `viewportWidth` (optional): Viewport width in pixels. Defaults to primary screen width or 1920.
- `viewportHeight` (optional): Viewport height in pixels. Defaults to primary screen height or 1080.
- `fontSize` (optional): Base font size in pixels for em/rem unit calculations. Default is 16.0.

**Note:** The library automatically detects your screen's actual dimensions and DPI from Avalonia when parameters are not specified.

### Applying HTML to an Existing TextBlock

If you want to apply HTML formatting directly to an existing `TextBlock` without creating wrapper controls, use the `ApplyToTextBlock` method. This is useful when you only need inline formatting (bold, italic, underline, spans, etc.) and don't need complex layouts like tables or divs:

```csharp
using HtmlToAvalonia;
using Avalonia.Controls;

// Create a TextBlock
var textBlock = new TextBlock();

// Apply HTML with inline formatting
var html = "This is <b>bold</b>, <i>italic</i>, and <u>underlined</u> text with <span style='color: red;'>colored spans</span>.";
HtmlConverter.ApplyToTextBlock(textBlock, html);

// The TextBlock now contains formatted inline content
// Block-level elements (div, p, table, etc.) are ignored - only their inline content is extracted
```

**Key Differences:**
- `ToAvalonia()`: Returns a `Control` that can include complex layouts (tables, divs, panels, etc.)
- `ApplyToTextBlock()`: Applies only inline formatting to an existing `TextBlock`, ignoring block-level elements

**Supported inline elements:**
- `<b>`, `<strong>` - Bold text
- `<i>`, `<em>` - Italic text
- `<u>` - Underlined text
- `<span>` - Styled spans with CSS
- `<br>` - Line breaks
- `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>` - Headings (rendered inline with appropriate font sizes)
- `<p>` - Paragraphs (rendered inline without creating separate blocks)

**Example with CSS and headings:**
```csharp
var textBlock = new TextBlock();
var html = @"
    <div>
        <h2>Welcome to HtmlToAvalonia!</h2>
        <p>This library supports <b style='color: blue;'>bold</b>, <i>italic</i>, and <u>underlined</u> text.</p>
        <br/>
        <h3>Features:</h3>
        You can use <span style='font-size: 18px; color: red;'>custom styles</span> and
        <b><i>combined formatting</i></b>.
    </div>";
HtmlConverter.ApplyToTextBlock(textBlock, html);
```

In this example, the `<div>` tag is ignored, but all the inline content and formatting is preserved. Headings (`<h2>`, `<h3>`) and paragraphs (`<p>`) are rendered inline with appropriate styling.

## Supported HTML Tags

- **Text Formatting**: `<b>`, `<strong>`, `<i>`, `<em>`, `<u>`
- **Headings**: `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>`
- **Containers**: `<div>`, `<span>`, `<p>`, `<body>`
- **Layout**: `<center>`, `<table>`, `<tr>`, `<td>`, `<th>`
- **Line Breaks**: `<br>`

## Supported CSS Properties

- **Color**: `color`, `background-color`
- **Font**: `font-size`, `font-weight`, `font-style`
- **Text**: `text-align`, `text-decoration`
- **Spacing**: `padding`, `margin`
- **Dimensions**: `width`, `height`

## Examples

### Basic Formatting

```csharp
var html = @"
    <div>
        <h1>Title</h1>
        <p>This is a paragraph with <b>bold</b>, <i>italic</i>, and <u>underlined</u> text.</p>
    </div>";
var control = HtmlConverter.ToAvalonia(html);
```

### CSS Styling

```csharp
var html = @"
    <div style='background-color: #f0f0f0; padding: 10px;'>
        <p style='color: blue; font-size: 18px; font-weight: bold;'>
            Styled paragraph
        </p>
    </div>";
var control = HtmlConverter.ToAvalonia(html);
```

### Tables

```csharp
var html = @"
    <table>
        <tr>
            <th colspan='2'>Header spanning 2 columns</th>
        </tr>
        <tr>
            <td>Row 1, Cell 1</td>
            <td>Row 1, Cell 2</td>
        </tr>
        <tr>
            <td rowspan='2'>Spanning 2 rows</td>
            <td>Row 2, Cell 2</td>
        </tr>
        <tr>
            <td>Row 3, Cell 2</td>
        </tr>
    </table>";
var control = HtmlConverter.ToAvalonia(html);
```

### Text Alignment

```csharp
var html = @"
    <div>
        <p style='text-align: left;'>Left aligned</p>
        <p style='text-align: center;'>Center aligned</p>
        <p style='text-align: right;'>Right aligned</p>
    </div>";
var control = HtmlConverter.ToAvalonia(html);
```

## License

MIT License - see LICENSE file for details

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## Limitations

- External stylesheets are not loaded (only inline styles and `<style>` tags)
- Complex CSS selectors and pseudo-elements are not fully supported
- JavaScript and dynamic content are not supported
- Some advanced CSS properties may not have Avalonia equivalents

