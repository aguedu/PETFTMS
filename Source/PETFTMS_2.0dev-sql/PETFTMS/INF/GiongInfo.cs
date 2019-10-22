using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class GiongInfo
    {
        /*
            MAGIONG VARCHAR(5) NOT NULL,
	        TENGIONG VARCHAR(20) NOT NULL,
	        CAOTB DOUBLE,
	        NANGTB DOUBLE,
	        CONSTRAINT PK_GIONG PRIMARY KEY(MAGIONG)
        */

        private string maGiong;
        public string MaGiong
        {
            get { return maGiong; }
            set { maGiong = value; }
        }

        private string tenGiong;
        public string TenGiong
        {
            get { return tenGiong; }
            set { tenGiong = value; }
        }

        private double caoTB;
        public double CaoTB
        {
            get { return caoTB; }
            set { caoTB = value; }
        }

        private double nangTB;
        public double NangTB
        {
            get { return nangTB; }
            set { nangTB = value; }
        }
    }
}