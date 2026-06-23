using System;
using System.Linq;
using System.Windows.Forms;

namespace OpenTranslateTool
{
    public partial class MainForm : Form
    {
        private DictionaryManager dictManager;
        private Translator translator;

        public MainForm()
        {
            InitializeComponent();

            dictManager = new DictionaryManager();
            translator = new Translator();

            cmbDict.Items.AddRange(dictManager.Dictionaries.Keys.ToArray());
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (cmbDict.SelectedItem == null)
            {
                MessageBox.Show("Select a dictionary first.");
                return;
            }

            var dict = dictManager.GetDictionary(cmbDict.SelectedItem.ToString());
            HashSet<string> dictSet = new HashSet<string>(dict);

            string input = txtInput.Text.Trim();

            // --- DETECTION HELPERS ---
            bool IsHex(string s) =>
                s.All(c => "0123456789ABCDEFabcdef".Contains(c));

            bool IsBase64(string s)
            {
                if (!s.EndsWith("=") && !s.EndsWith("=="))
                    return false;

                try
                {
                    Convert.FromBase64String(s);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            bool IsWordStream(string s) =>
                s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .All(w => dictSet.Contains(w));

            try
            {
                // --- ROUTING LOGIC ---
                if (IsHex(input))
                {
                    // HEX -> WORDS
                    txtOutput.Text = translator.HexToWords(input, dict);
                }
                else if (IsBase64(input))
                {
                    // BASE64 -> HEX -> WORDS
                    string hex = Translator.Base64ToHex(input);
                    txtOutput.Text = translator.HexToWords(hex, dict);
                }
                else if (IsWordStream(input))
                {
                    // WORDS -> HEX
                    string hex = translator.WordsToHex(input, dict);

                    if (chkOutputBase64.Checked)
                        txtOutput.Text = Translator.HexToBase64(hex);
                    else
                        txtOutput.Text = hex;
                }
                else
                {
                    txtOutput.Text = "Unrecognized format";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
