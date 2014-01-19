using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace edisense
{
    public partial class Form1 : Form
    {
        private List<string> autoCompleteList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            richTextBox1.Font = new Font("Microsoft San Serif", 10);


            // keyword type 1
            string keywords = @"\b(format|mount|unmount|is_mounted|
                                    |write_raw_image|write_firmware_image|
                                    |package_extract_file|package_extract_dir|
                                    |delete|delete_recursive|symlink|set_perm|set_perm_recursive|
                                    |getprop|file_getprop|apply_patch|
                                    |apply_patch_check|apply_patch_space|
                                    |run_program|assert|abort|ifelse|
                                    |is_substring|less_than_int|
                                    |greater_than_int|sleep|show_progress|set_progress|ui_print)\b";
            MatchCollection keywordMatches = Regex.Matches(richTextBox1.Text, keywords);

            // keyword type 2 
            string types = @"\b(if|else|then|endif)\b";
            MatchCollection typeMatches = Regex.Matches(richTextBox1.Text, types);

            // getting comments (inline)
            string comments = @"(#.+?$)";
            MatchCollection commentMatches = Regex.Matches(richTextBox1.Text, comments, RegexOptions.Multiline);


            // getting strings ("")
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(richTextBox1.Text, strings);



            // saving the original caret position + forecolor
            int originalIndex = richTextBox1.SelectionStart;
            int originalLength = richTextBox1.SelectionLength;
            Color originalColor = Color.Black;

            // focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = originalColor;


            // scanning...
            foreach (Match m in keywordMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }


            foreach (Match m in typeMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Brown;
            }



            // restoring the original colors, for further writing
            richTextBox1.SelectionStart = originalIndex;
            richTextBox1.SelectionLength = originalLength;
            richTextBox1.SelectionColor = originalColor;

            // giving back the focus
            richTextBox1.Focus();

           
			
			}
		}
            

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    
    }
}


