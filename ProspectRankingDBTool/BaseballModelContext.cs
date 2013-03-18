using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProspectRankingDBTool
{
    class BaseballModelContext
    {
        private static BaseballModelContext s_instance = null;

        private prospectdbEntities m_prospectDB;
        private List<string> m_positionEnum;
        private List<string> m_throwEnum;
        private List<string> m_batEnum;
        private List<string> m_publicEnum;
        private List<string> m_organizationEnum;
        private List<string> m_gradesEnum;

        private BaseballModelContext()
        {
            m_prospectDB = new prospectdbEntities();

            InitializeEnums();
        }

        public static BaseballModelContext Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new BaseballModelContext();
                }

                return s_instance;
            }
        }

        public prospectdbEntities DBContext
        {
            get
            {
                return m_prospectDB;
            }
        }

        private void InitializeEnums()
        {
            m_positionEnum = new List<string>();
            m_positionEnum.Add("SP");
            m_positionEnum.Add("RP");
            m_positionEnum.Add("C");
            m_positionEnum.Add("1B");
            m_positionEnum.Add("2B");
            m_positionEnum.Add("3B");
            m_positionEnum.Add("SS");
            m_positionEnum.Add("IF");
            m_positionEnum.Add("CF");
            m_positionEnum.Add("OF");
            m_positionEnum.Add("DH");

            m_batEnum = new List<string>();
            m_batEnum.Add("R");
            m_batEnum.Add("L");
            m_batEnum.Add("S");

            m_throwEnum = new List<string>();
            m_throwEnum.Add("R");
            m_throwEnum.Add("L");

            m_publicEnum = new List<string>();
            m_publicEnum.Add("Y");
            m_publicEnum.Add("N");

            m_gradesEnum = new List<string>();
            m_gradesEnum.Add("A");
            m_gradesEnum.Add("A-");
            m_gradesEnum.Add("B+");
            m_gradesEnum.Add("B");
            m_gradesEnum.Add("B-");
            m_gradesEnum.Add("C+");
            m_gradesEnum.Add("C");

            m_organizationEnum = new List<string>();
            var query = from it in m_prospectDB.Organizations
                            orderby it.Abbr
                            select it;
            
            foreach (Organization org in query)
                m_organizationEnum.Add(org.Abbr);
        }

        public List<string> Grades
        {
            get
            {
                return m_gradesEnum;
            }
        }

        public List<string> Organizations
        {
            get
            {
                return m_organizationEnum;
            }
        }

        public List<string> Positions
        {
            get
            {
                return m_positionEnum;
            }
        }

        public List<string> Batting
        {
            get
            {
                return m_batEnum;
            }
        }

        public List<string> Throwing
        {
            get
            {
                return m_throwEnum;
            }
        }

        public List<string> Public
        {
            get
            {
                return m_publicEnum;
            }
        }

        public static string ParseForOrganization(string text)
        {
            Regex re = new Regex("yankees", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "NYY";
            }
            
            re = new Regex("blue jays", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "TOR";
            }
            re = new Regex("rays", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "TB";
            }
            re = new Regex("orioles", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "BAL";
            }
            re = new Regex("red sox", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "BOX";
            }
            re = new Regex("tigers", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "DET";
            }
            re = new Regex("indians", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "CLE";
            }
            re = new Regex("royals", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "KC";
            }
            re = new Regex("twins", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "MIN";
            }
            re = new Regex("white sox", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "CWS";
            }
            re = new Regex("angels", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "LAA";
            }
            re = new Regex("rangers", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "TEX";
            }
            re = new Regex("astros", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "HOU";
            }
            re = new Regex("mariners", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "SEA";
            }
            re = new Regex("athletics", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "OAK";
            }
            re = new Regex("mets", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "NYM";
            }
            re = new Regex("phillies", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "PHI";
            }
            re = new Regex("nationals", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "WAS";
            }
            re = new Regex("braves", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "ATL";
            }
            re = new Regex("marlins", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "MIA";
            }
            re = new Regex("cardinals", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "STL";
            }
            re = new Regex("reds", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "CIN";
            }
            re = new Regex("brewers", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "MIL";
            }
            re = new Regex("pirates", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "PIT";
            }
            re = new Regex("cubs", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "CHC";
            }
            re = new Regex("dodgers", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "LAD";
            }
            re = new Regex("padres", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "SD";
            }
            re = new Regex("giants", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "SF";
            }
            re = new Regex("rockies", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "COL";
            }
            re = new Regex("diamondbacks", RegexOptions.IgnoreCase);
            if (re.IsMatch(text))
            {
                return "ARZ";
            }


            return null;
        }
    }
}
