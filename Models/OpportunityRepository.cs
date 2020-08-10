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
            DateTime datePosted1 = new DateTime(2020, 7, 21);
            DateTime datePosted2 = new DateTime(2019, 11, 19);
            DateTime datePosted3 = new DateTime(2020, 2, 6);
            DateTime datePosted4 = new DateTime(2019, 8, 27);
            DateTime datePosted5 = new DateTime(2020, 1, 29);
            DateTime datePosted6 = new DateTime(2020, 3, 17);
            DateTime datePosted7 = new DateTime(2020, 6, 8);
            DateTime datePosted8 = new DateTime(2019, 12, 24);
            DateTime datePosted9 = new DateTime(2020, 7, 15);

            DateTime timeOfEvent1 = new DateTime(2020, 8, 30, 13, 30, 0);
            DateTime timeOfEvent2 = new DateTime(2020, 11, 1, 17, 45, 0);
            DateTime timeOfEvent3 = new DateTime(2020, 9, 28, 8, 0, 0);
            DateTime timeOfEvent4 = new DateTime(2020, 10, 15, 14, 0, 0);
            DateTime timeOfEvent5 = new DateTime(2021, 1, 30, 9, 30, 0);
            DateTime timeOfEvent6 = new DateTime(2020, 11, 6, 9, 0, 0);
            DateTime timeOfEvent7 = new DateTime(2021, 2, 14, 19, 0, 0);
            DateTime timeOfEvent8 = new DateTime(2020, 12, 20, 15, 0, 0);
            DateTime timeOfEvent9 = new DateTime(2021, 3, 9, 8, 0, 0);

            _opportunityList = new List<Opportunity>()
            {
                new Opportunity {id = 1, title="Food Drive", datePosted = datePosted1, center = "Jacksonville Location", address = "8523 Normandy Blvd, Jacksonville, FL, 32221", TimeOfEvent = timeOfEvent1, description="Collect non-perishable goods and sort them for further distribution."},
                new Opportunity {id = 2, title="Christmas Fundraiser", datePosted = datePosted2, center = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent2, description="Distribute flyers around local neighborhoods."},
                new Opportunity {id = 3, title="Clothing Drive", datePosted = datePosted3, center = "St. Petersburg Location", address = "3190 Tyrone Blvd. N., St. Petersburg, FL, 33710", TimeOfEvent = timeOfEvent3, description="Collect and sort clothes that will be distrbuted to children in need."},
                new Opportunity {id = 4, title="Halloween Party", datePosted = datePosted4, center = "Jacksonville Location", address = "11830 Old Kings Rd, Jacksonville, Florida 32219, USA", TimeOfEvent = timeOfEvent4, description="Carve, paint and pick pumpikns from a pumpkin patch. This event is open to the public. We are partnered with the farm and will recieve half of all sales made during this event. As a volunteer you will man the painting and carving stations and other assigned duties. "},
                new Opportunity {id = 5, title="Clothing Drive", datePosted = datePosted5, center = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent5, description="Collect and sort clothes that will be distrbuted to children in need."},
                new Opportunity {id = 6, title="Valentines Day Party", datePosted = datePosted6, center = "St. Petersburg Location", address = "3190 Tyrone Blvd. N., St. Petersburg, FL, 33710", TimeOfEvent = timeOfEvent6, description="Exchange gifts, dance, and complete arts and crafts with kids in a group home."},
                new Opportunity {id = 7, title="Valentines Day Gala", datePosted = datePosted7, center = "Jacksonville Location", address = "1000 Water St, Jacksonville, FL 32204", TimeOfEvent = timeOfEvent7, description="This Gala will raise money to buy presents and host events for children in group homes. As a volunteer you will be waiting tables or checking people in as they arrive."},
                new Opportunity {id = 8, title="Christmas Party", datePosted = datePosted8, center = "Miami Location", address = "550 NW 42nd Avenue, Miami, FL 33126", TimeOfEvent = timeOfEvent8, description="Decorate cookies, make ornaments and give presents to kids in a group home."},
                new Opportunity {id = 9, title="Food Drive", datePosted = datePosted9, center = "St. Petersburg Location", address = "401 5th St N, St Petersburg, FL", TimeOfEvent = timeOfEvent9, description="Collect non-perishable goods and sort them for further distribution."}

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

        public IEnumerable<Opportunity> SearchKeywords(string key)
        {
            IEnumerable<Opportunity> searchResults = _opportunityList.Where(o => o.center.ToLower().Contains(key.ToLower()) || o.description.ToLower().Contains(key.ToLower()) || o.title.ToLower().Contains(key.ToLower()));

            return searchResults;
           
        }

        public List<Opportunity> FilterCenter(string center)
        {

            List<Opportunity> results = _opportunityList.Where(o => o.center == center).ToList();

            return results;
        }

        public List<Opportunity> FilterPosted()
        {
            List<Opportunity> results = new List<Opportunity>();
            DateTime today = DateTime.Now.Date;
            //today.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            List<Opportunity> oppList = _opportunityList;
            foreach (Opportunity opp in oppList)
            {
                DateTime posted = opp.datePosted.Date;
                TimeSpan difference = today.Subtract(posted);
                int daysDiff = difference.Days;

                if (daysDiff <= 60)
                {
                    results.Add(opp);
                    

                }
                else
                {
                    //List<TimeSpan> days = new List<TimeSpan>();
                    // days.Add(difference);
                    //TempData["MethodResult"] = difference;
                }
            }

            return results;
        }
    }
}
