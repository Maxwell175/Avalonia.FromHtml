using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Platform;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Css;
using AngleSharp.Css.Dom;
using AngleSharp.Io;

namespace HtmlToAvalonia;

/// <summary>
/// Provides functionality to convert HTML with CSS formatting into Avalonia controls.
/// </summary>
public static class HtmlConverter
{
    /// <summary>
    /// Converts an HTML string with CSS formatting into an Avalonia Control.
    /// </summary>
    /// <param name="html">The HTML string to convert.</param>
    /// <param name="viewportWidth">Optional viewport width in pixels. If not specified, uses primary screen width or 1920.</param>
    /// <param name="viewportHeight">Optional viewport height in pixels. If not specified, uses primary screen height or 1080.</param>
    /// <param name="fontSize">Optional base font size in pixels for em/rem calculations. Default is 16.</param>
    /// <returns>An Avalonia Control representing the HTML content.</returns>
    public static Control ToAvalonia(
        string html,
        double? viewportWidth = null,
        double? viewportHeight = null,
        double fontSize = 16.0)
    {
        if (string.IsNullOrWhiteSpace(html))
        {
            return new TextBlock { Text = string.Empty };
        }

        // Create a render device to support em/rem units
        var renderDevice = new AvaloniaRenderDevice(viewportWidth, viewportHeight, fontSize);

        var config = Configuration.Default
            .WithDefaultLoader()
            .WithCss()
            .WithRenderDevice(renderDevice);

        var context = BrowsingContext.New(config);
        var document = context.OpenAsync(req => req.Content(html)).Result;

        var body = document.Body ?? document.DocumentElement;
        if (body == null)
        {
            return new TextBlock { Text = html };
        }

        var converter = new HtmlToAvaloniaConverter(document);
        return converter.ConvertElement(body);
    }

    /// <summary>
    /// Applies HTML with inline formatting to an existing TextBlock.
    /// This method processes inline elements (b, i, u, span, br, h1-h6, p) and text content.
    /// Block-level layout elements (div, table, etc.) are ignored, but their inline content is extracted.
    /// Headings (h1-h6) are rendered inline with appropriate font sizes and bold weight.
    /// </summary>
    /// <param name="textBlock">The TextBlock to apply the HTML formatting to.</param>
    /// <param name="html">The HTML string to convert.</param>
    /// <param name="viewportWidth">Optional viewport width in pixels. If not specified, uses primary screen width or 1920.</param>
    /// <param name="viewportHeight">Optional viewport height in pixels. If not specified, uses primary screen height or 1080.</param>
    /// <param name="fontSize">Optional base font size in pixels for em/rem calculations. Default is 16.</param>
    public static void ApplyToTextBlock(
        TextBlock textBlock,
        string html,
        double? viewportWidth = null,
        double? viewportHeight = null,
        double fontSize = 16.0)
    {
        if (textBlock == null)
        {
            throw new ArgumentNullException(nameof(textBlock));
        }

        if (string.IsNullOrWhiteSpace(html))
        {
            textBlock.Text = string.Empty;
            return;
        }

        // Create a render device to support em/rem units
        var renderDevice = new AvaloniaRenderDevice(viewportWidth, viewportHeight, fontSize);

        var config = Configuration.Default
            .WithDefaultLoader()
            .WithCss()
            .WithRenderDevice(renderDevice);

        var context = BrowsingContext.New(config);
        var document = context.OpenAsync(req => req.Content(html)).Result;

        var body = document.Body ?? document.DocumentElement;
        if (body == null)
        {
            textBlock.Text = html;
            return;
        }

        var converter = new HtmlToAvaloniaConverter(document);
        converter.ApplyInlineContentToTextBlock(textBlock, body);
    }

    /// <summary>
    /// Render device implementation that uses Avalonia's actual screen properties.
    /// Supports both desktop and mobile applications.
    /// </summary>
    private class AvaloniaRenderDevice : IRenderDevice
    {
        private readonly int _viewportWidth;
        private readonly int _viewportHeight;
        private readonly double _fontSize;
        private readonly int _resolution;
        private readonly int _colorBits;

        public AvaloniaRenderDevice(double? viewportWidth, double? viewportHeight, double fontSize)
        {
            _fontSize = fontSize;

            // Try to get actual screen information from Avalonia
            Screen? primaryScreen = null;

            // Check for desktop application
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                primaryScreen = desktop.MainWindow?.Screens?.Primary ?? desktop.MainWindow?.Screens?.All.FirstOrDefault();
            }
            // Check for mobile application (iOS/Android)
            else if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
            {
                // For mobile apps, try to get screen from the main view
                if (singleView.MainView is Visual visual)
                {
                    var topLevel = TopLevel.GetTopLevel(visual);
                    primaryScreen = topLevel?.Screens?.Primary ?? topLevel?.Screens?.All.FirstOrDefault();
                }
            }

            if (primaryScreen != null)
            {
                // Use actual screen dimensions
                var bounds = primaryScreen.Bounds;
                _viewportWidth = viewportWidth.HasValue ? (int)viewportWidth.Value : bounds.Width;
                _viewportHeight = viewportHeight.HasValue ? (int)viewportHeight.Value : bounds.Height;

                // Get actual DPI (Scaling is the ratio, multiply by 96 to get DPI)
                _resolution = (int)(primaryScreen.Scaling * 96.0);

                // Color depth - default to 24-bit (true color)
                _colorBits = 24;
            }
            else
            {
                // Fallback to reasonable defaults if screen info not available
                // Use mobile-friendly defaults if we detect a mobile platform
                bool isMobile = Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime;

                if (isMobile)
                {
                    // Mobile defaults (typical smartphone resolution)
                    _viewportWidth = viewportWidth.HasValue ? (int)viewportWidth.Value : 390;
                    _viewportHeight = viewportHeight.HasValue ? (int)viewportHeight.Value : 844;
                    _resolution = 326; // Typical mobile DPI (e.g., iPhone)
                }
                else
                {
                    // Desktop defaults
                    _viewportWidth = viewportWidth.HasValue ? (int)viewportWidth.Value : 1920;
                    _viewportHeight = viewportHeight.HasValue ? (int)viewportHeight.Value : 1080;
                    _resolution = 96;
                }

                _colorBits = 24;
            }
        }

        public int DeviceWidth => _viewportWidth;
        public int DeviceHeight => _viewportHeight;
        public int ViewPortWidth => _viewportWidth;
        public int ViewPortHeight => _viewportHeight;
        public double RenderWidth => _viewportWidth;
        public double RenderHeight => _viewportHeight;
        public double FontSize => _fontSize;
        public int Resolution => _resolution;
        public int ColorBits => _colorBits;
        public int MonochromeBits => 0;
        public int Frequency => 60;
        public bool IsInterlaced => false;
        public bool IsScripting => false;
        public bool IsGrid => false;
        public DeviceCategory Category => DeviceCategory.Screen;
    }
}

