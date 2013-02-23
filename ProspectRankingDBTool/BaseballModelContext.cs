using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            m_organizationEnum = new List<string>();
            var query = from it in m_prospectDB.Organizations
                            orderby it.Abbr
                            select it;
            
            foreach (Organization org in query)
                m_organizationEnum.Add(org.Abbr);
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
    }
}
