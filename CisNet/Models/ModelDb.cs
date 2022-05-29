using System;
using System.Collections.Generic;
using System.Data;
using CisNet.Types;

namespace CisNet.Models
{
    public class ModelDb:OraDriver
    {
        public bool CheckUser(string username, string password)
        {
            if (username == "Alex" && password == "123") return true;
            return false;
        }

        public List<Bypass> GetBypassList()
        {
            return Bypass.getTestData();
        }

        internal List<Archive> GetArchive(ArchiveRequest rr)
        {
            if (string.IsNullOrEmpty(rr.dateFrom)) rr.dateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(rr.dateTo)) rr.dateTo = DateTime.Now.ToString("yyyy-MM-dd");
            string likeid = "";
            if (!string.IsNullOrEmpty(rr.fio)) likeid = $" and objcaption like '{rr.fio}%'";
            List<Archive> rez = new List<Archive>();
            var rd = Dbo.Connect().SetQuery(@$"SELECT a.id, a.docdate, a.eventdate, a.typename,
        nvl(a.staff,' ') staff,
        nvl(a.remark,' ') remark,
       a.objcaption, a.clsstatus, a.clsdate
  FROM bypass_archive a 
where docdate between date '{rr.dateFrom.Substring(0,10)}' and date '{rr.dateTo.Substring(0, 10)}' {likeid}
order by a.docdate").GetReader();
            while(rd.Read())
            {
                rez.Add(new Archive()
                {
                    ID = rd.GetDecimal(0),
                    DocDate = rd.GetDateTime(1).ToString("yyyy-MM-dd"),
                    EventDate = rd.GetDateTime(2).ToString("yyyy-MM-dd"),
                    Event = rd.GetString(3),
                    Staff = rd.GetString(4),
                    Remark = rd.GetString(5),
                    Fio = rd.GetString(6),
                }) ;
            }
            rd.Close();
            Dbo.Close();
            return rez;
        }
    }


}
