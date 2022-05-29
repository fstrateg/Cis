using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisNet
{
    public class TempCode
    {
        /*
        public GetByPassDocumentArchExecutionResult GetByPassListArch(DateTime lowDate)
        {
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter);
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("USERDATA");
            xmlTextWriter.WriteElementString("LOWDATE", lowDate.ToString("dd:MM:yyyy"));
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();

            ExecutionResult executionResult;
            executionResult = OpenConnection();
            if (!executionResult.executionResult)
                return new GetByPassDocumentArchExecutionResult(false, executionResult.userMessage, executionResult.systemMessage);

            executionResult = CallDataSetProcedure("www.PKG#BYPASS.prc_GetByPassArchiveList1", stringWriter.ToString(), 1);
            CloseConnection();
            if (!executionResult.executionResult)
                return new GetByPassDocumentArchExecutionResult(false, executionResult.userMessage, executionResult.systemMessage);

            DataTableReader tReader = (executionResult.returnValue as DataSet).Tables[0].CreateDataReader();
            List<ByPassDocumentArch> documentParameterList = new List<ByPassDocumentArch>();
            while (tReader.Read())
                documentParameterList.Add(
                    new ByPassDocumentArch(
                        tReader.GetString(0),
                        tReader.GetDateTime(1),
                        tReader.GetDateTime(2),
                        tReader.GetDateTime(8),
                        tReader.GetString(3),
                        tReader.IsDBNull(4) ? "" : tReader.GetString(4),
                        tReader.IsDBNull(5) ? "" : tReader.GetString(5),
                        tReader.GetString(6),
                        Convert.ToInt32(tReader.GetInt16(7))
                        )
                    );
            return new GetByPassDocumentArchExecutionResult(documentParameterList);
        }*/
    }
}
