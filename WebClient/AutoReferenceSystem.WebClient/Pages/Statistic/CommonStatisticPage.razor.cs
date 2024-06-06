using AntDesign;
using AutoReferenceSystem.WebClient.Models.Statistic;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Pages.Statistic
{
    public partial class CommonStatisticPage
    {
        private ICollection<ServerData> _servers = new List<ServerData>();

        private ITable _table;
    }
}
