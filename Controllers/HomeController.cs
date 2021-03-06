﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using PreSemester_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;
using System.Globalization;

namespace PreSemester_Project.Controllers
{
    public class HomeController : Controller
    {



        private readonly IVolunteerRepository _volunteerRepository;

        private readonly IOpportunityRepository _opportunityRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVolunteerRepository volunteerRepository, IOpportunityRepository opportunityRepository)
        {
            _logger = logger;
            _volunteerRepository = volunteerRepository;
            _opportunityRepository = opportunityRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection Form)
        {
            //LOGIN FORM VALIDATION IS WORKING...
            // WILL UNCOMMENT TOWARDS END OF PROJECT
            //return RedirectToAction("Options");

            /// taking in login form from index.cshtml and gathering variables
            string username = (Form["UserName"].ToString());
            string password = (Form["Password"].ToString());

            //validation of "admin" credentials
            if (username == "Admin" && password == "Admin")
            {
                //initializing session variables
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Password", password);
                return View("Options");
            }
            else
            {

                foreach (var volunteer in _volunteerRepository.GetAllVolunteers())
                {
                    if (volunteer.Username == username && volunteer.Password == password)
                    {
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Password", password);
                        return RedirectToAction("VolunteerOptions");
                    }
                }

                ViewBag.error = "Username: Admin<br />Password: Admin";
                return View("Index");
            }
        }

        public ActionResult Options()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Volunteers()
        {
            return RedirectToAction("ManageVolunteers");
        }

        [HttpPost]
        public RedirectToActionResult Opportunities()
        {
            return RedirectToAction("ManageOpportunities");

        }


        /// *************************************************************************************************************************///
        /// ********************************************Beginning of Volunteer Methods***********************************************///
        /// *************************************************************************************************************************///

        public ActionResult ManageVolunteers()
        {
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();

            ViewData.Model = volList;
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Volunteer newVol)
        {
            _volunteerRepository.Add(newVol);


            return RedirectToAction("ManageVolunteers");
        }


        [HttpGet]
        public ActionResult OpportunityMatches(int id)
        {
            Volunteer findVolOpp = _volunteerRepository.GetVolunteer(id);
            List<Opportunity> results = new List<Opportunity>();
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();

            foreach (Opportunity opp in oppList)
            {
                if (opp.center == findVolOpp.CenterPreferences)
                {
                    results.Add(opp);

                }
            }

            if (results.Count == 0 && HttpContext.Session.GetString("Username") == "Admin")
            {
                ViewData["error"] = "Opportunity match not found.";
                return RedirectToAction("ManageVolunteers");
            }
            else if (results.Count == 0)
            {
                ViewData["error"] = "No matches found.";
                ViewData.Model = new OpportunityMatchesView { _volunteer = findVolOpp, _opportunityList = results };
                return View("VolunteerOptions");
            }
            else
            {

                var finalResults = new OpportunityMatchesView { _volunteer = findVolOpp, _opportunityList = results };

                if (HttpContext.Session.GetString("Username") != "Admin")
                    return View("MyOpportunityMatches", finalResults);


                return View(finalResults);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }

        public RedirectToActionResult Delete(int id)
        {

            Volunteer vol = _volunteerRepository.Delete(id);
            TempData["deleted"] = vol.FirstName + " " + vol.LastName + " has been deleted.";
            return RedirectToAction("ManageVolunteers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Volunteer toBeChanged = _volunteerRepository.GetVolunteer(id);
            ViewData.Model = toBeChanged;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Edit(Volunteer changedVol, string cancel, string submit)
        {
            if (!string.IsNullOrWhiteSpace(submit))
            {
                _volunteerRepository.Edit(changedVol);

            }
            if (!string.IsNullOrEmpty(cancel))
            {
                return RedirectToAction("ManageVolunteers");
            }

            return RedirectToAction("ManageVolunteers");
        }

        [HttpGet]
        public ActionResult Search(string key)
        {

            IEnumerable<Volunteer> results = _volunteerRepository.Search(key);

            if (results.Any())
            {
                ViewData.Model = results;

                return View("SearchResults");
            }
            else
            {
                TempData["error"] = "Volunteer not Found: Please recheck your spelling.";
                ViewData.Model = _volunteerRepository.GetAllVolunteers();
                return View("ManageVolunteers");
            }

        }

        public ActionResult SearchResults()
        {
            ViewData.Model = TempData["Results"] as IEnumerable<Volunteer>;

            return View();
        }

        [HttpGet]
        public ActionResult Filter(string approvalStatus)
        {
            List<Volunteer> results = new List<Volunteer>();
            if (approvalStatus != "All" && approvalStatus != "Approved/Pending Approval")
            {
                results = _volunteerRepository.FilterApprovalStatus(approvalStatus);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + approvalStatus + ".";
            }
            else if (approvalStatus == "Approved/Pending Approval")
            {
                results = _volunteerRepository.FilterApprovalStatus("Approved");
                results.AddRange(_volunteerRepository.FilterApprovalStatus("Pending Approval"));

                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + approvalStatus + ".";
            }
            else
            {
                ViewData.Model = _volunteerRepository.GetAllVolunteers();
                TempData["filteredBy"] = "There are no volunteers that match your filtering criteria.";
            }



            return View("ManageVolunteers");
        }

        [HttpPost]
        public IActionResult CancelVolunteer()
        {
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();
            ViewData.Model = volList;
            return View("ManageVolunteers");
        }

        /// *************************************************************************************************************************///
        /// ********************************************End of Admin Volunteer Methods***********************************************///
        /// *************************************************************************************************************************///

        /// *************************************************************************************************************************///
        /// ********************************************Beginning of non-admin Methods***********************************************///
        /// *************************************************************************************************************************///
        public IActionResult VolunteerOptions()
        {
            Volunteer volIn = _volunteerRepository.GetVolunteerbyUsername(HttpContext.Session.GetString("Username"));
            ViewData.Model = volIn;
            return View();
        }
        public IActionResult Edited()
        {
            ViewData.Model = _volunteerRepository.GetVolunteer((int)TempData["id"]);
            return View("MyDetails");
        }

        [HttpGet]
        public IActionResult MyDetails(int id)
        {
            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }
        [HttpGet]
        public IActionResult EditMyDetails(int id)
        {
            ViewData.Model = _volunteerRepository.GetVolunteer(id);
            return View();
        }
        [HttpPost]
        public RedirectToActionResult EditMyDetails(Volunteer MyChanges)
        {
            _volunteerRepository.Edit(MyChanges);

            TempData["id"] = MyChanges.id;
            return RedirectToAction("Edited");
        }
        /// *************************************************************************************************************************///
        /// ********************************************End of non-admin Methods*****************************************************///
        /// *************************************************************************************************************************///

        /// *************************************************************************************************************************///
        /// ********************************************Beginning of Opportunity Methods*********************************************///
        /// *************************************************************************************************************************///


        public IActionResult CancelOpportunity()
        {
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();

            ViewData.Model = oppList;

            return View("ManageOpportunities");
        }
        public ActionResult ManageOpportunities()
        {
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();

            ViewData.Model = oppList;

            return View();
        }
        //working
        public ActionResult CreateOpportunities()
        {
            return View();
        }
        //working
        [HttpPost]
        public RedirectToActionResult CreateOpportunities(Opportunity opportunity)
        {
            _opportunityRepository.Add(opportunity);
            return RedirectToAction("ManageOpportunities");
        }
        //working

        public RedirectToActionResult DeleteOpportunity(int id)
        {
            Opportunity deleted = _opportunityRepository.Delete(id);
            TempData["MethodResult"] = deleted.title + " was removed.";
            return RedirectToAction("ManageOpportunities");
        }
        //working
        [HttpGet]
        public ActionResult EditOpportunity(int id)
        {
            Opportunity toBeChanged = _opportunityRepository.GetOpportunity(id);
            ViewData.Model = toBeChanged;

            return View();
        }
        //working

        [HttpPost]
        public RedirectToActionResult EditOpportunity(Opportunity opportunityChanges)
        {
            _opportunityRepository.Edit(opportunityChanges);
            return RedirectToAction("ManageOpportunities");
        }//working

        [HttpGet]
        public ActionResult VolunteerMatches(int id)
        {
            Opportunity findopp = _opportunityRepository.GetOpportunity(id);
            List<Volunteer> results = new List<Volunteer>();
            IEnumerable<Volunteer> volList = _volunteerRepository.GetAllVolunteers();

            foreach (Volunteer vol in volList)
            {
                if (vol.CenterPreferences == findopp.center)
                {
                    results.Add(vol);

                }
                else
                {

                }
            }

            if (results.Count == 0)
            {
                TempData["error"] = "Volunteer match not found.";
                return RedirectToAction("ManageOpportunities");
            }
            else
            {

                var finalResults = new VolunteerMatchesView { opportunity = findopp, _volunteerList = results };
                return View(finalResults);
            }
        }//working

        [HttpGet]
        public ActionResult FilterCenter(string center)
        {
            List<Opportunity> results = new List<Opportunity>();
            if (center == "Jacksonville Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "Miami Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "St. Petersburg Location")
            {
                results = _opportunityRepository.FilterCenter(center);
                ViewData.Model = results.AsEnumerable();
                TempData["filteredBy"] = "Filtered by " + center + ".";
            }
            else if (center == "All")
            {
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                TempData["filteredBy"] = "You are viewing all of the opportunities posted.";
            }
            else
            {
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                TempData["filteredBy"] = "There are no opportunities that match your filtering criteria.";
            }



            return View("ManageOpportunities");
        }//working

        [HttpGet]
        public ActionResult SearchKeywords(string key)
        {
            IEnumerable<Opportunity> results = _opportunityRepository.SearchKeywords(key);

            if (results.Any())
            {
                ViewData.Model = results;

                return View("OpportunitySearchResults");
            }
            else
            {
                TempData["error"] = "Opportunity not found.";
                ViewData.Model = _opportunityRepository.GetAllOpportunities();
                return View("ManageOpportunities");
            }

        }//working

        [HttpGet]
        public ActionResult OpportunityDetails(int id)
        {
            ViewData.Model = _opportunityRepository.GetOpportunity(id);
            return View();
        }//working

        public ActionResult FilterPosted()
        {
            List<Opportunity> results = new List<Opportunity>();
            DateTime today = DateTime.Now.Date;
            IEnumerable<Opportunity> oppList = _opportunityRepository.GetAllOpportunities();
            foreach (Opportunity opp in oppList)
            {
                DateTime posted = opp.datePosted.Date;
                TimeSpan difference = today.Subtract(posted);
                int daysDiff = difference.Days;

                if (daysDiff <= 60)
                {
                    results.Add(opp);
                    ViewData.Model = results.AsEnumerable();

                }
                else
                {

                }
            }
            if (results.Count == 0)
            {
                TempData["MethodResult"] = "There were no opportunitites posted within the past 60 days.";
                return View("ManageOpportunities");
            }
            TempData["MethodResult"] = "You are viewing of the opportunitites posted within the past 60 days.";
            ViewData.Model = results.AsEnumerable();
            return View("ManageOpportunities");
        }
        //working

        /// *************************************************************************************************************************///
        /// ********************************************End of Opportunity Methods*****************************************************///
        /// *************************************************************************************************************************///

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
