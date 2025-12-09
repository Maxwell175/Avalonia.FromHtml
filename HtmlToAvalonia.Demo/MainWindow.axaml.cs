using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace HtmlToAvalonia.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadExamples();
    }

    private void LoadExamples()
    {
        // Example 1: Basic Formatting
        var basicHtml = @"<div>
    <h1>Welcome to HtmlToAvalonia</h1>
    <p>This library converts HTML with CSS into Avalonia controls.</p>

    <h2>Text Formatting</h2>
    <p>You can use <b>bold</b>, <i>italic</i>, and <u>underlined</u> text.</p>
    <p>You can also <b><i>combine</i></b> multiple formats.</p>

    <h3>Headings</h3>
    <h1>Heading 1</h1>
    <h2>Heading 2</h2>
    <h3>Heading 3</h3>
    <h4>Heading 4</h4>
    <h5>Heading 5</h5>
    <h6>Heading 6</h6>

    <p>Line breaks work too:<br/>First line<br/>Second line<br/>Third line</p>
</div>";
        BasicFormattingHtml.Text = basicHtml;
        BasicFormattingOutput.Child = HtmlConverter.ToAvalonia(basicHtml);

        // Example 2: Colors and Styles
        var colorsHtml = @"<div>
    <h2 style='color: #2C3E50;'>Colors and Styling</h2>

    <h3>Named Colors</h3>
    <p style='color: red;'>Red text</p>
    <p style='color: blue;'>Blue text</p>
    <p style='color: green;'>Green text</p>
    <p style='color: purple;'>Purple text</p>

    <h3>Hex Colors</h3>
    <p style='color: #FF5733;'>Orange (#FF5733)</p>
    <p style='color: #3498DB;'>Sky Blue (#3498DB)</p>
    <p style='color: #2ECC71;'>Emerald (#2ECC71)</p>

    <h3>RGB Colors</h3>
    <p style='color: rgb(231, 76, 60);'>RGB Red</p>
    <p style='color: rgb(52, 152, 219);'>RGB Blue</p>

    <h3>Background Colors</h3>
    <div style='background-color: #F39C12; padding: 10px; margin: 5px;'>
        <p style='color: white; font-weight: bold;'>Orange background with white text</p>
    </div>
    <div style='background-color: #8E44AD; padding: 10px; margin: 5px;'>
        <p style='color: white;'>Purple background</p>
    </div>

    <h3>Font Sizes</h3>
    <p style='font-size: 10px;'>Small text (10px)</p>
    <p style='font-size: 14px;'>Normal text (14px)</p>
    <p style='font-size: 18px;'>Large text (18px)</p>
    <p style='font-size: 24px;'>Extra large text (24px)</p>

    <h3>Combined Styles</h3>
    <p style='color: #E74C3C; font-size: 20px; font-weight: bold;'>
        Bold red text at 20px
    </p>
    <p style='color: #3498DB; font-style: italic; text-decoration: underline;'>
        Italic underlined blue text
    </p>
</div>";
        ColorsHtml.Text = colorsHtml;
        ColorsOutput.Child = HtmlConverter.ToAvalonia(colorsHtml);

        // Example 3: Tables
        var tablesHtml = @"<div>
    <h2>Table Examples</h2>

    <h3>Simple Table</h3>
    <table>
        <tr>
            <th>Name</th>
            <th>Age</th>
            <th>City</th>
        </tr>
        <tr>
            <td>John Doe</td>
            <td>30</td>
            <td>New York</td>
        </tr>
        <tr>
            <td>Jane Smith</td>
            <td>25</td>
            <td>Los Angeles</td>
        </tr>
        <tr>
            <td>Bob Johnson</td>
            <td>35</td>
            <td>Chicago</td>
        </tr>
    </table>

    <h3>Table with Colspan</h3>
    <table>
        <tr>
            <th colspan='3'>Employee Information</th>
        </tr>
        <tr>
            <th>Name</th>
            <th>Department</th>
            <th>Salary</th>
        </tr>
        <tr>
            <td>Alice Brown</td>
            <td>Engineering</td>
            <td>$95,000</td>
        </tr>
        <tr>
            <td>Charlie Davis</td>
            <td>Marketing</td>
            <td>$75,000</td>
        </tr>
    </table>

    <h3>Table with Rowspan</h3>
    <table>
        <tr>
            <th>Category</th>
            <th>Item</th>
            <th>Price</th>
        </tr>
        <tr>
            <td rowspan='2'>Fruits</td>
            <td>Apple</td>
            <td>$1.50</td>
        </tr>
        <tr>
            <td>Banana</td>
            <td>$0.75</td>
        </tr>
        <tr>
            <td rowspan='2'>Vegetables</td>
            <td>Carrot</td>
            <td>$1.00</td>
        </tr>
        <tr>
            <td>Lettuce</td>
            <td>$2.00</td>
        </tr>
    </table>

    <h3>Complex Table</h3>
    <table>
        <tr>
            <th colspan='2' rowspan='2'>Product</th>
            <th colspan='2'>Sales</th>
        </tr>
        <tr>
            <th>Q1</th>
            <th>Q2</th>
        </tr>
        <tr>
            <td rowspan='2'>Electronics</td>
            <td>Laptop</td>
            <td>150</td>
            <td>200</td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>300</td>
            <td>350</td>
        </tr>
    </table>
</div>";
        TablesHtml.Text = tablesHtml;
        TablesOutput.Child = HtmlConverter.ToAvalonia(tablesHtml);

        // Example 4: Alignment
        var alignmentHtml = @"<div>
    <h2>Text Alignment Examples</h2>

    <h3>Using CSS text-align</h3>
    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p style='text-align: left;'>This text is aligned to the LEFT</p>
    </div>

    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p style='text-align: center;'>This text is aligned to the CENTER</p>
    </div>

    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p style='text-align: right;'>This text is aligned to the RIGHT</p>
    </div>

    <h3>Using HTML align attribute</h3>
    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p align='left'>Left aligned using align attribute</p>
    </div>

    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p align='center'>Center aligned using align attribute</p>
    </div>

    <div style='border: 1px solid gray; padding: 10px; margin: 10px;'>
        <p align='right'>Right aligned using align attribute</p>
    </div>

    <h3>Using center tag</h3>
    <center>
        <h1>Centered Heading</h1>
        <p>This entire section is centered</p>
        <p><b>Bold centered text</b></p>
    </center>

    <h3>Mixed Alignment in Table</h3>
    <table>
        <tr>
            <th>Left</th>
            <th>Center</th>
            <th>Right</th>
        </tr>
        <tr>
            <td style='text-align: left;'>Left aligned cell</td>
            <td style='text-align: center;'>Center aligned cell</td>
            <td style='text-align: right;'>Right aligned cell</td>
        </tr>
    </table>
</div>";
        AlignmentHtml.Text = alignmentHtml;
        AlignmentOutput.Child = HtmlConverter.ToAvalonia(alignmentHtml);

        // Example 5: Complex Document
        var complexHtml = @"<div style='padding: 20px;'>
    <center>
        <h1 style='color: #2C3E50; font-size: 32px;'>Annual Report 2024</h1>
        <p style='color: #7F8C8D; font-size: 14px;'>Company Performance Overview</p>
    </center>

    <div style='background-color: #ECF0F1; padding: 15px; margin: 20px 0;'>
        <h2 style='color: #34495E;'>Executive Summary</h2>
        <p style='font-size: 14px;'>
            This year has been marked by <b>significant growth</b> across all departments.
            Our revenue increased by <span style='color: #27AE60; font-weight: bold;'>25%</span>,
            while maintaining a strong focus on <i>customer satisfaction</i> and
            <u>operational excellence</u>.
        </p>
    </div>

    <h2 style='color: #2C3E50; border-bottom: 2px solid #3498DB; padding-bottom: 5px;'>
        Financial Highlights
    </h2>

    <table style='width: 100%;'>
        <tr style='background-color: #3498DB;'>
            <th style='color: white; padding: 10px;'>Metric</th>
            <th style='color: white; padding: 10px;'>2023</th>
            <th style='color: white; padding: 10px;'>2024</th>
            <th style='color: white; padding: 10px;'>Change</th>
        </tr>
        <tr>
            <td style='padding: 8px;'><b>Revenue</b></td>
            <td style='text-align: right; padding: 8px;'>$10.5M</td>
            <td style='text-align: right; padding: 8px;'>$13.1M</td>
            <td style='text-align: right; color: #27AE60; padding: 8px;'>+25%</td>
        </tr>
        <tr style='background-color: #F8F9FA;'>
            <td style='padding: 8px;'><b>Profit</b></td>
            <td style='text-align: right; padding: 8px;'>$2.1M</td>
            <td style='text-align: right; padding: 8px;'>$2.8M</td>
            <td style='text-align: right; color: #27AE60; padding: 8px;'>+33%</td>
        </tr>
        <tr>
            <td style='padding: 8px;'><b>Employees</b></td>
            <td style='text-align: right; padding: 8px;'>150</td>
            <td style='text-align: right; padding: 8px;'>185</td>
            <td style='text-align: right; color: #27AE60; padding: 8px;'>+23%</td>
        </tr>
    </table>

    <h2 style='color: #2C3E50; margin-top: 30px;'>Department Performance</h2>

    <div style='margin: 20px 0;'>
        <h3 style='color: #E74C3C;'>Sales Department</h3>
        <div style='background-color: #FADBD8; padding: 10px; margin: 10px 0;'>
            <p><b>Achievement:</b> Exceeded quarterly targets by <span style='font-size: 18px; color: #C0392B;'>40%</span></p>
            <p><i>Key Success Factors:</i> New client acquisition and improved retention rates</p>
        </div>
    </div>

    <div style='margin: 20px 0;'>
        <h3 style='color: #3498DB;'>Engineering Department</h3>
        <div style='background-color: #D6EAF8; padding: 10px; margin: 10px 0;'>
            <p><b>Achievement:</b> Launched <u>3 major products</u> ahead of schedule</p>
            <p><i>Key Success Factors:</i> Agile methodology and cross-team collaboration</p>
        </div>
    </div>

    <div style='margin: 20px 0;'>
        <h3 style='color: #27AE60;'>Marketing Department</h3>
        <div style='background-color: #D5F4E6; padding: 10px; margin: 10px 0;'>
            <p><b>Achievement:</b> Increased brand awareness by <span style='font-size: 18px; color: #1E8449;'>60%</span></p>
            <p><i>Key Success Factors:</i> Digital transformation and social media campaigns</p>
        </div>
    </div>

    <h2 style='color: #2C3E50; margin-top: 30px;'>Regional Breakdown</h2>

    <table>
        <tr>
            <th colspan='4' style='background-color: #34495E; color: white; padding: 10px;'>
                Sales by Region
            </th>
        </tr>
        <tr style='background-color: #BDC3C7;'>
            <th style='padding: 8px;'>Region</th>
            <th style='padding: 8px;'>Q1</th>
            <th style='padding: 8px;'>Q2</th>
            <th style='padding: 8px;'>Total</th>
        </tr>
        <tr>
            <td style='padding: 8px;'><b>North America</b></td>
            <td style='text-align: right; padding: 8px;'>$3.2M</td>
            <td style='text-align: right; padding: 8px;'>$3.8M</td>
            <td style='text-align: right; padding: 8px;'><b>$7.0M</b></td>
        </tr>
        <tr style='background-color: #F8F9FA;'>
            <td style='padding: 8px;'><b>Europe</b></td>
            <td style='text-align: right; padding: 8px;'>$2.1M</td>
            <td style='text-align: right; padding: 8px;'>$2.5M</td>
            <td style='text-align: right; padding: 8px;'><b>$4.6M</b></td>
        </tr>
        <tr>
            <td style='padding: 8px;'><b>Asia Pacific</b></td>
            <td style='text-align: right; padding: 8px;'>$0.8M</td>
            <td style='text-align: right; padding: 8px;'>$0.7M</td>
            <td style='text-align: right; padding: 8px;'><b>$1.5M</b></td>
        </tr>
    </table>

    <div style='background-color: #2C3E50; color: white; padding: 20px; margin-top: 30px;'>
        <center>
            <h3>Looking Forward to 2025</h3>
            <p style='font-size: 14px;'>
                With strong fundamentals and a dedicated team, we are positioned for
                <b>continued growth</b> and <b>innovation</b> in the coming year.
            </p>
        </center>
    </div>
</div>";
        ComplexHtml.Text = complexHtml;
        ComplexOutput.Child = HtmlConverter.ToAvalonia(complexHtml);

        // Example 6: Inline TextBlock - ApplyToTextBlock method
        var inlineHtml = @"<div style='color: #2C3E50;'>
    <h2 style='color: #3498DB;'>Welcome to Inline TextBlock Rendering!</h2>

    <p>This example demonstrates the <b>HtmlConverter.ApplyToTextBlock</b> method, which applies HTML
    formatting directly to a TextBlock without creating wrapper controls.</p>

    <h3 style='color: #E74C3C;'>Key Features:</h3>

    <p>✓ Supports <b>bold</b>, <i>italic</i>, and <u>underlined</u> text<br/>
    ✓ Handles <span style='color: red;'>colored text</span> and <span style='font-size: 18px;'>different font sizes</span><br/>
    ✓ Renders <b><i>combined formatting</i></b> correctly<br/>
    ✓ Processes headings inline: <h1>H1</h1> <h2>H2</h2> <h3>H3</h3><br/>
    ✓ Extracts inline content from block elements</p>

    <h4 style='color: #27AE60;'>Use Cases:</h4>

    <p>This method is perfect for scenarios where you need rich text formatting within a single TextBlock,
    such as <b style='color: #8E44AD;'>tooltips</b>, <i style='color: #F39C12;'>notifications</i>,
    or <u style='color: #16A085;'>status messages</u>.</p>

    <h5>Technical Details:</h5>

    <p>Unlike <span style='font-family: Consolas;'>ToAvalonia()</span> which returns a Control that may
    include wrapper elements like StackPanel or Border, <span style='font-family: Consolas;'>ApplyToTextBlock()</span>
    processes only inline elements and applies them directly to the TextBlock's Inlines collection.</p>

    <h6>Example Code:</h6>

    <p><span style='background-color: #ECF0F1; font-family: Consolas; padding: 5px;'>
    var textBlock = new TextBlock();<br/>
    HtmlConverter.ApplyToTextBlock(textBlock, htmlString);
    </span></p>

    <p>Block-level elements like <b>&lt;div&gt;</b> and <b>&lt;table&gt;</b> are ignored, but their
    inline content is still extracted and rendered. This allows you to use the same HTML source for
    both full layout rendering and inline-only rendering!</p>
</div>";
        InlineHtml.Text = inlineHtml;
        HtmlConverter.ApplyToTextBlock(InlineOutput, inlineHtml);

        // Example 7: Interactive - Start with a simple example
        var interactiveHtml = @"<div>
    <h2>Try it yourself!</h2>
    <p>Edit the HTML on the left to see it rendered here.</p>
    <p>You can use <b>bold</b>, <i>italic</i>, <u>underline</u>, and more!</p>
</div>";
        InteractiveHtml.Text = interactiveHtml;
        InteractiveOutput.Child = HtmlConverter.ToAvalonia(interactiveHtml);
    }

    private void OnInteractiveHtmlChanged(object? sender, TextChangedEventArgs e)
    {
        if (InteractiveHtml == null || InteractiveOutput == null)
            return;

        try
        {
            var html = InteractiveHtml.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(html))
            {
                InteractiveOutput.Child = null;
                return;
            }

            var rendered = HtmlConverter.ToAvalonia(html);
            InteractiveOutput.Child = rendered;
        }
        catch (System.Exception ex)
        {
            // If there's an error parsing the HTML, show an error message
            var errorText = new TextBlock
            {
                Text = $"Error rendering HTML:\n{ex.Message}",
                Foreground = Brushes.Red,
                TextWrapping = TextWrapping.Wrap
            };
            InteractiveOutput.Child = errorText;
        }
    }
}