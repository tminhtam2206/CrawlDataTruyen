using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using xNet;

namespace CrawlDataTruyen
{
    public partial class Form1 : Form
    {
        private int numchap = 1;
        private int time_run = 0;
        private int current_seconds = 0;
        private int current_minute = 0;
        private int current_hour = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            changeComboBoxWeb();

            if (txbLinkTruyen.Text.Trim().Length > 0 && (int)numStart.Value > 0)
            {
                if (cmbTrangTruyen.SelectedIndex >= 0)
                {
                    //numchap = (int)numStart.Value;
                    timer1.Start();
                    btnStop.Enabled = true;
                    btnReset.Enabled = false;
                    btnStop.BackColor = Color.Red;
                    numStart.Enabled = numEND.Enabled = numIDTruyen.Enabled = btnCrawl.Enabled = false;
                }
                else MessageBox.Show("Trang web không được hỗ trợ...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time_run > 0) time_run--;
            else
            {
                time_run = (int)numTimeCrawl.Value;
                
                if (numchap <= numEND.Value)
                {
                    GetDataFromWeb();
                    numchap++;
                }
                else timer1.Stop();
            }
            this.Text = "Crawl Truyện ( " + time_run + " giây )";

            current_seconds++;
            if(current_seconds > 59)
            {
                current_seconds = 0;
                current_minute++;
                
                if(current_minute > 50)
                {
                    current_minute = 0;
                    current_hour++;
                }
            }

            ChangeTime();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStop.BackColor = Color.WhiteSmoke;
            btnReset.Enabled = true;
            btnStop.Enabled = false;
            numStart.Enabled = numEND.Enabled = numIDTruyen.Enabled = btnCrawl.Enabled = true;
        }

        private void rtxbPreview_TextChanged(object sender, EventArgs e)
        {
            numWK.Value = CountWords(rtxbPreview.Text);
        }

        private void txbLinkTruyen_TextChanged(object sender, EventArgs e)
        {
            changeComboBoxWeb();
        }

        private void numStart_ValueChanged(object sender, EventArgs e)
        {
            numchap = (int)numStart.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            numchap = 1;
            txbLinkTruyen.Text = "";
            lbCurrentTime.Text = "00:00:00";
            current_seconds = current_minute = current_hour = 0;
            txbLinkTruyen.Focus();
        }

        #region CSDL
        private void AddChapter(int numchap, string title, string title_u, int wk, string content, int idTruyen)
        {
            string query = "INSERT INTO chuong(title, title_u, content, num_chap, date_post, id_truyen, lock_chap, length_word) VALUES ( @title , @title_u , @content , @num_chap , NOW() , @id_truyen , 0 , @leng )";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { title, title_u, content, numchap, idTruyen, wk });
        }

        private int GetTotalWordCount()
        {
            string query = "SELECT SUM(length_word) AS 'tong' FROM chuong WHERE id_truyen = " + numIDTruyen.Value;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int result = 0;
            foreach (DataRow row in data.Rows)
            {
                result = Int32.Parse(row.ItemArray[0].ToString());
            }

            return result;
        }

        private void UpdateWordCount(int _numchap, int idTruyen)
        {
            int lenghtword = GetTotalWordCount();
            string query = "UPDATE truyen SET length_word = @length_word WHERE id = " + idTruyen;
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { lenghtword });

            string query2 = "UPDATE truyen SET num_chaps = @num_chaps WHERE id = " + idTruyen;
            DataProvider.Instance.ExecuteNonQuery(query2, new object[] { _numchap });
        }
        #endregion

        #region My Function
        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        private static string GenerateSlug(string str)
        {
            str = str.ToLower();

            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str.Replace(" ", "-");
        }

        private static int CountWords(string str)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int count = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            return count;
        }

        private string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }

        private void GetDataFromWeb()
        {
            string link_crawl = txbLinkTruyen.Text + "/chuong-" + numchap;

            //truyenfull
            if (cmbTrangTruyen.SelectedIndex == 0)
            {
                var html = new HtmlWeb();
                var document = html.Load(link_crawl);
                var title_chap = document.DocumentNode.SelectSingleNode(@"//*[@id='chapter-big-container']/div/div/h2/a");
                if (title_chap == null)
                {
                    txbTitleChap.Text = "Hết chương...";
                    rtxbPreview.Text = "Hết chương...";
                    btnStop.PerformClick();
                    return;
                }
                var node = document.DocumentNode.SelectSingleNode(@"//*[@id='chapter-c']");

                txbTitleChap.Text = title_chap.InnerText;
                string conent_chap = node.InnerHtml;
                conent_chap = WebUtility.HtmlDecode(conent_chap);
                conent_chap = conent_chap.Replace("<br><br>", "\n\n");
                conent_chap = GetPlainTextFromHtml(conent_chap);

                rtxbPreview.Text = conent_chap;

                if (ckbSaveDatabase.Checked)
                {
                    string[] array_title = txbTitleChap.Text.Split(':');
                    string title_CHAP = "";
                    if (array_title.Length == 1) title_CHAP = "Vô Đề";
                    else title_CHAP = array_title[1].Trim();

                    AddChapter(numchap, title_CHAP, GenerateSlug(title_CHAP), (int)numWK.Value, rtxbPreview.Text.Replace("\n", "<br />"), (int)numIDTruyen.Value);
                    UpdateWordCount(numchap, (int)numIDTruyen.Value);
                }
            }
            //metruyenchu
            else if (cmbTrangTruyen.SelectedIndex == 1)
            {
                new Thread(() =>
                {
                    var html = new HtmlWeb();
                    var document = html.Load(link_crawl);

                    var title_chap = document.DocumentNode.SelectSingleNode("//*[@id='js-read__body']/div[2]");
                    if(title_chap == null)
                    {
                        txbTitleChap.Text = "Hết chương...";
                        rtxbPreview.Text = "Hết chương...";
                        btnStop.PerformClick();
                        return;
                    }
                    
                    txbTitleChap.Text = title_chap.InnerText;
                    var node = document.DocumentNode.SelectSingleNode(@"//*[@id='js-read__content']");

                    string conent_chap = node.InnerHtml;
                    conent_chap = WebUtility.HtmlDecode(conent_chap);
                    conent_chap = conent_chap.Replace("<br><br>", "\n\n");
                    conent_chap = GetPlainTextFromHtml(conent_chap);

                    rtxbPreview.Text = conent_chap;

                    if (ckbSaveDatabase.Checked)
                    {
                        string[] array_title = txbTitleChap.Text.Split(':');
                        string title_CHAP = array_title[1].Trim();

                        AddChapter(numchap, title_CHAP, GenerateSlug(title_CHAP), (int)numWK.Value, rtxbPreview.Text.Replace("\n", "<br />"), (int)numIDTruyen.Value);
                        UpdateWordCount(numchap, (int)numIDTruyen.Value);
                    }
                })
                { IsBackground = true }.Start();
            }
            //truyenYY
            else if (cmbTrangTruyen.SelectedIndex == 2)
            {
                new Thread(() =>
                {
                    var html = new HtmlWeb();
                    var document = html.Load(link_crawl + ".html");

                    var title_chap = document.DocumentNode.SelectSingleNode("/html/body/main/div[2]/div[2]/div[1]/a");
                    if (title_chap == null)
                    {
                        txbTitleChap.Text = "Hết chương...";
                        rtxbPreview.Text = "Hết chương...";
                        btnStop.PerformClick();
                        return;
                    }
                    int vitri_start = title_chap.InnerText.IndexOf("Chương") + 9;
                    string title_1 = title_chap.InnerText.Substring(0, vitri_start);
                    string title_2 = title_chap.InnerText.Substring(vitri_start);
                    txbTitleChap.Text = title_1 + ": " + title_2;

                    var node = document.DocumentNode.SelectSingleNode(@"//*[@id='inner_chap_content_1']");
                    string conent_chap = "";

                    if (node == null) conent_chap = "Vui lòng đăng nhập để đọc truyện...";
                    else conent_chap = node.InnerHtml;

                    conent_chap = WebUtility.HtmlDecode(conent_chap);
                    conent_chap = conent_chap.Replace("<p>", "\n\n");
                    conent_chap = GetPlainTextFromHtml(conent_chap);

                    rtxbPreview.Text = conent_chap;

                    if (ckbSaveDatabase.Checked)
                    {
                        string[] array_title = txbTitleChap.Text.Replace("\n", "").Split(':');
                        int num_CHAP = Int32.Parse(array_title[0].Split(' ')[1]);
                        string title_CHAP = array_title[1].Trim();

                        AddChapter(num_CHAP, title_CHAP, GenerateSlug(title_CHAP), (int)numWK.Value, rtxbPreview.Text.Replace("\n", "<br />"), (int)numIDTruyen.Value);
                        UpdateWordCount(num_CHAP, (int)numIDTruyen.Value);
                    }

                })
                { IsBackground = true }.Start();
            }
            //vTruyen
            else if(cmbTrangTruyen.SelectedIndex == 3)
            {
                
            }
            //tangkinhcac
            else if (cmbTrangTruyen.SelectedIndex == 4)
            {
                var html = new HtmlWeb();
                var document = html.Load(link_crawl);

                var title_chap = document.DocumentNode.SelectSingleNode("//*[@id='body-truyen']/div[2]/h4");
                if (title_chap == null)
                {
                    txbTitleChap.Text = "Hết chương...";
                    rtxbPreview.Text = "Hết chương...";
                    btnStop.PerformClick();
                    return;
                }
                int vitri_start = title_chap.InnerText.IndexOf("Chương") + 8;
                string title_1 = title_chap.InnerText.Substring(0, vitri_start).Replace("\n", "");
                string title_2 = title_chap.InnerText.Substring(vitri_start).Replace("\n", "");
                txbTitleChap.Text = title_1 + ": " + title_2;

                var node = document.DocumentNode.SelectSingleNode(@"//*[@id='content-noi-dung']");
                string conent_chap = node.InnerHtml.Replace("\n", "").Replace("\r", "");
                conent_chap = WebUtility.HtmlDecode(conent_chap.Replace("<br><br>", "\n\n"));
                conent_chap = GetPlainTextFromHtml(conent_chap);

                rtxbPreview.Text = conent_chap.Trim();

                if (ckbSaveDatabase.Checked)
                {
                    string[] array_title = txbTitleChap.Text.Replace("\n", "").Split(':');
                    int num_CHAP = Int32.Parse(array_title[0].Split(' ')[1]);
                    string title_CHAP = array_title[1].Trim();

                    AddChapter(num_CHAP, title_CHAP, GenerateSlug(title_CHAP), (int)numWK.Value, rtxbPreview.Text.Replace("\n", "<br />"), (int)numIDTruyen.Value);
                    UpdateWordCount(num_CHAP, (int)numIDTruyen.Value);
                }
            }
        }

        private void changeComboBoxWeb()
        {
            if (txbLinkTruyen.Text.Trim().Length > 0)
            {
                if (txbLinkTruyen.Text.Contains("truyenfull.vn")) cmbTrangTruyen.SelectedIndex = 0;
                else if (txbLinkTruyen.Text.Contains("metruyenchu.com")) cmbTrangTruyen.SelectedIndex = 1;
                else if (txbLinkTruyen.Text.Contains("truyenyy.vip")) cmbTrangTruyen.SelectedIndex = 2;
                else if (txbLinkTruyen.Text.Contains("vtruyen.com")) cmbTrangTruyen.SelectedIndex = 3;
                else if (txbLinkTruyen.Text.Contains("tangkinhcac.atwebpages.com")) cmbTrangTruyen.SelectedIndex = 4;
            }
            else cmbTrangTruyen.SelectedIndex = -1;
        }

        private void ChangeTime()
        {
            string temp_hour = (current_hour.ToString().Length == 1) ? "0" + current_hour : current_hour.ToString();
            string temp_minute = (current_minute.ToString().Length == 1) ? "0" + current_minute : current_minute.ToString();
            string temp_seconds = (current_seconds.ToString().Length == 1) ? "0" + current_seconds : current_seconds.ToString();

            lbCurrentTime.Text = temp_hour + ":" + temp_minute + ":" + temp_seconds;
        }
        #endregion
    }
}
