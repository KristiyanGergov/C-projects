namespace CarDealer.Services
{
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels.Logs;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsService : Service
    {
        public AllLogsPageVm GetAllLogsPageVm(string username, int? page)
        {
            var currentPage = 1;
            if (page != null)
            {
                currentPage = page.Value;
            }
            IEnumerable<Log> logs;
            if (username != null)
            {
                logs = this.Context.Logs.Where(name => name.User.Username == username);
            }
            else
            {
                logs = this.Context.Logs;
            }

            int allLogPagesCount = logs.Count() / 20 + logs.Count() % 20 == 0 ? 0 : 1;
            int logsToTake = 20;
            if (allLogPagesCount == currentPage)
            {
                logsToTake = logs.Count() % 20 == 0 ? 20 : logs.Count() % 20;
            }
            logs = logs.Skip((currentPage - 1) * 20).Take(logsToTake);

            List<AllLogsVm> logVms = new List<AllLogsVm>();
            foreach (Log log in logs)
            {
                logVms.Add(new AllLogsVm()
                {
                    Operation = log.Operation,
                    User = log.User.Username,
                    DateOfModifying = log.ModifiedAt,
                    ModifiedTable = log.ModifiedTableName
                });
            }
            AllLogsPageVm pageVm = new AllLogsPageVm
            {
                CurrentPage = currentPage,
                WantedUserName = username,
                Logs = logVms,
                TotalNumberOfPages = allLogPagesCount
            };

            return pageVm;

        }
        public void ClearLogs()
        {
            this.Context.Logs.RemoveRange(this.Context.Logs);
            this.Context.SaveChanges();
        }
    }
}