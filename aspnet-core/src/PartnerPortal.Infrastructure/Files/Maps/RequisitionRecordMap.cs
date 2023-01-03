using CsvHelper.Configuration;
using PartnerPortal.Application.Requisitions.Commands;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Infrastructure.Files.Maps
{
    public class RequisitionRecordMap : ClassMap<RequisitionRecord>
    {
        public RequisitionRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

        }
    }
}
