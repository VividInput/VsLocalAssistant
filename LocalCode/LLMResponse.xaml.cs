using Markdig;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace LocalCode
{
    /// <summary>
    /// Interaction logic for LLMResponse.xaml.
    /// </summary>
    [ProvideToolboxControl("LocalCode.LLMResponse", true)]
    public partial class LLMResponse : UserControl
    {
        StringBuilder _markdownBuilder = new StringBuilder();

        public LLMResponse(string author)
        {
            InitializeComponent();
            title.Text = author;
        }

#if DEBUG
        public void ReportResponseText()
        {
            System.Diagnostics.Debugger.Log(0, "LLMResponse", _markdownBuilder.ToString());
        }
#endif

        public void SetResponseText(string responseText)
        {
            try
            {
                _markdownBuilder.Append(responseText);
                markdownFrame.NavigateToString(Markdown.ToHtml(_markdownBuilder.ToString()));
                //Markdownview.Markdown = _markdownBuilder.ToString();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
