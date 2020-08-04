using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public interface IOpportunityRepository
    {
        Opportunity Add(Opportunity opportunity);
        Opportunity Delete(int id);
        Opportunity Edit(Opportunity opportunityChanges);
        IEnumerable<Opportunity> GetAllOpportunities();
        IEnumerable<Opportunity> Search(string key);
        Opportunity GetOpportunity(int id);
    }
}
