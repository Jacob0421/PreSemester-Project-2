using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemester_Project.Models
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private List<Opportunity> _opportunityList;

        public OpportunityRepository()
        {
           DateTime datePosted1 = new DateTime(2020, 3, 21);
           DateTime datePosted2 = new DateTime(2019, 11, 19);

            DateTime timeOfEvent1 = new DateTime(2020, 8, 30, 13, 30, 0);
            DateTime timeOfEvent2 = new DateTime(2020, 12, 30, 17, 45, 0);

            _opportunityList = new List<Opportunity>()
            {
                new Opportunity {id = 1, title="Bubba's Hullabaloo", datePosted = datePosted1, center = "Wolfson's Children Hospital", TimeOfEvent = timeOfEvent1, description="Bubba's Throwin' a good ole fashioned Hullabaloo. Come one over to get the best darn ribs on this side of the Mississippi."},
                new Opportunity {id = 2, title="Frankenstein's Phantom Freakout", datePosted = datePosted2, center = "MOCA Jacksonville", TimeOfEvent = timeOfEvent2, description="Brains?"}

            };
        }

        public Opportunity Add(Opportunity newOpportunity)
        {
            newOpportunity.datePosted = DateTime.Now;

            newOpportunity.id = _opportunityList.Max(o => o.id) + 1;

            _opportunityList.Add(newOpportunity);

            return newOpportunity;
        }

        public Opportunity Delete(int id)
        {
            Opportunity opportunity = _opportunityList.FirstOrDefault(o => o.id == id);

            _opportunityList.Remove(opportunity);
            return opportunity;
        }

        public Opportunity Edit(Opportunity opportunityChanges)
        {
            Opportunity toBeChanged = _opportunityList.FirstOrDefault(o => o.id == opportunityChanges.id);

            toBeChanged.title = opportunityChanges.title;
            toBeChanged.datePosted = opportunityChanges.datePosted;
            toBeChanged.TimeOfEvent = opportunityChanges.TimeOfEvent;
            toBeChanged.description = opportunityChanges.description;

            return toBeChanged;
        }

        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return _opportunityList;
        }

        public Opportunity GetOpportunity(int id)
        {
            return _opportunityList.FirstOrDefault(o => o.id == id); ;
        }

        public IEnumerable<Opportunity> Search(string key)
        {
            throw new NotImplementedException();
        }
    }
}
