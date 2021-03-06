﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//test Madi comment
namespace DataStructuresAssignment.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        public static Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        public static string sFound;
        public static string sTime;
        public static bool bFirst;

        public ActionResult Index()
        {
            foreach (var item in myDictionary)
            {
                ViewBag.Dictionary += "<p>" + item + "</p>";
            }

            if (bFirst == true)
            {
                ViewBag.StopWatch = "<p>" + sFound + " in " + sTime + " miliseconds" + "</p>";
            }


            return View();
        }

        public ActionResult addOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count+1));
            return RedirectToAction("Index");
        }

        public ActionResult addHuge()
        {
            if (myDictionary.Count != 0)
            {
                myDictionary.Clear();
                for (int i = 0; i < 2000; i++)
                {
                    myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
                }
                return RedirectToAction("Index");
            }
            else
            {
                for (int i = 0; i < 2000; i++)
                {
                    myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult displayQueue()
        {
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromDictionary()
        {
            bFirst = false;
            if (myDictionary.Count != 0)
            {
                myDictionary.Remove(myDictionary.Keys.Last());
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult clearDictionary()
        {
            bFirst = false;
            if (myDictionary.Count != 0)
            {
                myDictionary.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }




        public ActionResult searchDictionary()
        {
            bFirst = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myDictionary.ContainsKey("New Entry 2"))
            {
                sFound = "found";
            }
            else
            {
                sFound = "not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            sTime = ts.ToString();


            return RedirectToAction("Index");

        }
    }
}