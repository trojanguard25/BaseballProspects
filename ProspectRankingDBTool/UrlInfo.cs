using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProspectRankingDBTool
{
    public partial class UrlInfo : UserControl
    {
        private class AuthorInfo
        {
            private Author m_author;

            public AuthorInfo(Author author)
            {
                m_author = author;
            }

            override public string ToString()
            {
                string name = m_author.Lastname + ", " + m_author.Firstname;

                return name;
            }

            public Author GetAuthor()
            {
                return m_author;
            }
        };



        private URL m_url;
        private BaseballModelContext m_context;
        private List<AuthorInfo> m_authors;

        public UrlInfo()
        {
            InitializeComponent();
        }

        public URL URLObject
        {
            get
            {
                return m_url;
            }

            set
            {
                m_url = value;
                InitUrlInfo();
            }
        }

        private void InitUrlInfo()
        {
            if (m_context == null)
            {
                m_context = BaseballModelContext.Instance;
            }

            if (m_authors == null)
            {
                m_authors = new List<AuthorInfo>();

                var query = from it in m_context.DBContext.Authors
                            orderby it.Lastname, it.Firstname
                            select it;

                foreach (Author author in query)
                {
                    AuthorInfo authorInfo = new AuthorInfo(author);
                    m_authors.Add(authorInfo);
                }

                cbAuthor.DataSource = m_authors;
            }

            if (m_url != null)
            {
                txtUrl.Text = m_url.URL1;
                txtID.Text = m_url.UrlID.ToString();

                if (m_url.Author == 0)
                {
                    m_url.Author1 = m_authors.ElementAt(cbAuthor.SelectedIndex).GetAuthor();
                }
                else
                {
                    foreach (AuthorInfo author in m_authors)
                    {
                        if (author.GetAuthor().AuthorID == m_url.Author)
                        {
                            cbAuthor.SelectedItem = author;
                            break;
                        }
                    }
                }

                checkPublic.Checked = (m_url.Public == "Y");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_context.DBContext.SaveChanges();

            txtID.Text = m_url.UrlID.ToString();

            btnSave.Enabled = false;
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (m_url != null)
            {
                m_url.URL1 = txtUrl.Text;
            }
        }

        private void cbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_url != null)
            {
                m_url.Author1 = m_authors.ElementAt(cbAuthor.SelectedIndex).GetAuthor();
            }
        }

        private void checkPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (m_url != null)
            {
                if (checkPublic.Checked)
                {
                    m_url.Public = "Y";
                }
                else
                {
                    m_url.Public = "N";
                }
            }
        }

        private void urlDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (m_url != null)
            {
                m_url.Date = urlDateTime.Value;
            }
        }
    }
}
