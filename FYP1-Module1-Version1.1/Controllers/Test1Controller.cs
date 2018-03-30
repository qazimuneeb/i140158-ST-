using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;
using FYP1_Module1_Version1._1.Models;

namespace FYP1_Module1_Version1._1.Controllers
{
    public class Test1Controller : Controller
    {
        private fypEntities db = new fypEntities();
        // GET: Test1
        public ActionResult Index()
        {
            return View();
        }
        public Boolean RegisterStudent(student s1)
        {
            if (s1.RollNumber != null)
            {
                Console.WriteLine("Successfully added");
                return true;
            }
            return false;

        }
        public int LoginStudent(student s2)
        {

            var details = (from student in db.students
                           where student.RollNumber == s2.RollNumber && student.Password == s2.Password
                           select new
                           {
                               student.Id,
                               student.Name
                           }).ToList();
            if (details.FirstOrDefault() != null)
            {

                return 1;
            }



            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
                //   Warning("Invalid Credentials", true);

                return 0;

            }
        }
        public bool addIdeasTest(idea i1, string session1)
        {
            if (session1 == "1")
            {
                if (i1.Title != null)
                {
                    db.ideas.Add(i1);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;


        }
        public bool chatTest()
        {

            return true;
        }
        public int milestonesTest(milestone m1)
        {
            if (m1.name != null && m1.description != null)
            {
                m1.idregistration = 3;
                db.milestones.Add(m1);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public bool listmilestonestest(List<milestone> m3)
        {



            if (m3 != null)
            {
                return true;

            }

            return false;
        }
        public bool supervisorlogintest(teacher s2)
        {
            var details = (from teacher in db.teachers
                           where teacher.Email == s2.Email && teacher.password == s2.password
                           select new
                           {
                               teacher.Id,
                               teacher.Name
                           }).ToList();
            if (details.FirstOrDefault() != null)
            {

                return true;
            }



            else
            {

                return false;

            }

        }
        public bool RegisterSupervisor(teacher s1)
        {
            if (s1.Email != null)
            {

                Console.WriteLine("Successfully added");
                return true;
            }
            return false;

        }
        public bool makegrouptest(fyp_group fypgroup)
        {
            var query = (from fypgrp in db.fyp_group
                         where fypgrp.group_member1 != fypgroup.group_member1 && fypgrp.group_member2 != fypgroup.group_member2 && fypgrp.group_member2 != fypgroup.group_member2
                         select new
                         {
                             fypgrp.group_id,
                             fypgrp.group_member1,
                             fypgrp.group_member2,
                             fypgrp.group_member3
                         }).ToList();

            var q1 = query;
            if (fypgroup.group_member1 != null && fypgroup.group_member2 != null && fypgroup.group_member3 != null && query.FirstOrDefault() != null)
            {

                return true;
            }

            return false;
        }
        public bool registrationTest()
        {
            return true;
        }

    }
}