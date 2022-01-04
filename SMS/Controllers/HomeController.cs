using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        SMSEntities6 db = new SMSEntities6();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(Admin1 u)
        {
            Admin1 U2 = db.Admin1.Where(x => x.A_Name == u.A_Name && x.A_Password == u.A_Password).SingleOrDefault();

            Admin1 U1 = db.Admin1.Where(x => x.A_id == u.A_id).SingleOrDefault();
            if (U1 != null)
            {
                Session["A_id"] = U1.A_id;
                return RedirectToAction("Index2");
            }

            if (U2 == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["A_id"] = U2.A_id;
                return RedirectToAction("Index2");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

        public ActionResult S_login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult S_login(user1 u)
        {
            user1 U2 = db.user1.Where(x => x.username == u.username && x.password == u.password).SingleOrDefault();

            user1 U1 = db.user1.Where(x => x.U_id == u.U_id).SingleOrDefault();
            if (U1 != null)
            {
                Session["U_id"] = U1.U_id;
                Session["R_id"] = U1.U_id;

                return RedirectToAction("Index1");
            }

            if (U2 == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["U_id"] = U2.U_id;
                return RedirectToAction("Index1");
            }
            return View();

        }



        public ActionResult t_login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult t_login(teacher u)
        {
            teacher U2 = db.teachers.Where(x => x.teacher_name == u.teacher_name && x.teacher_password == u.teacher_password).SingleOrDefault();

            teacher U1 = db.teachers.Where(x => x.teacher_id == u.teacher_id).SingleOrDefault();
            if (U1 != null)
            {
                Session["teacher_id"] = U1.teacher_id;
                return RedirectToAction("Index3");
            }

            if (U2 == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["teacher_id"] = U2.teacher_id;
                return RedirectToAction("Index3");
            }
            return View();

        }

        public ActionResult User_Profile()
        {
            if (Session["U_id"] == null)
            {
                return RedirectToAction("Index");
            }

            //  Session["ad_id"] = 2;
            int adid = Convert.ToInt32(Session["U_id"].ToString());
            List<user1> li = db.user1.Where(x => x.U_id == adid).OrderByDescending(x => x.U_id).ToList();
            ViewData["list"] = li;
            return View();
        }

        public ActionResult User_Course()
        {
            if (Session["U_id"] == null)
            {
                return RedirectToAction("Index");
            }

            //  Session["ad_id"] = 2;
            int adid = Convert.ToInt32(Session["U_id"].ToString());
            List<registeration> li = db.registerations.Where(x => x.R_id == adid).OrderByDescending(x => x.R_id).ToList();
            ViewData["list"] = li;
            return View();
        }

        public ActionResult teacher_Profile()
        {
            if (Session["teacher_id"] == null)
            {
                return RedirectToAction("Index");
            }

            //  Session["ad_id"] = 2;
            int adid = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> li = db.teachers.Where(x => x.teacher_id == adid).OrderByDescending(x => x.teacher_id).ToList();
            ViewData["list"] = li;
            return View();
        }
        public ActionResult GetCourses()
        {
            return View(db.courses.ToList());
        }


        // GET: courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id,couse,duaraion")] course course)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("GetCourses");
            }

            return View(course);
        }

        // GET: courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id,couse,duaraion")] course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetCourses");
            }
            return View(course);
        }

        // GET: courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course course = db.courses.Find(id);
            db.courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("GetCourses");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: batches
        public ActionResult GetBtches()
        {
            return View(db.batches.ToList());
        }

        // GET: batches/Details/5
        public ActionResult Batch_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: batches/Create
        public ActionResult Batch_Create()
        {
            return View();
        }

        // POST: batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Batch_Create([Bind(Include = "B_id,batch1,year")] batch batch)
        {
            if (ModelState.IsValid)
            {
                db.batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("GetBtches");
            }

            return View(batch);
        }

        // GET: batches/Edit/5
        public ActionResult Batch_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Batch_Edit([Bind(Include = "B_id,batch1,year")] batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetBtches");
            }
            return View(batch);
        }

        // GET: batches/Delete/5
        public ActionResult Batch_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: batches/Delete/5
        [HttpPost, ActionName("Batch_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Batch_DeleteConfirmed(int id)
        {
            batch batch = db.batches.Find(id);
            db.batches.Remove(batch);
            db.SaveChanges();
            return RedirectToAction("GetBtches");
        }
        // GET: user
        public ActionResult GetStudent()
        {
            return View(db.user1.ToList());
        }

        // GET: user/Details/5
        public ActionResult Student_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // GET: user/Create
        public ActionResult Student_Create()
        {
            return View();
        }

        // POST: user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student_Create([Bind(Include = "U_id,firstname,lastname,username,password")] user1 user1)
        {
            if (ModelState.IsValid)
            {
                db.user1.Add(user1);
                db.SaveChanges();
                return RedirectToAction("GetStudent");
            }

            return View(user1);
        }

        // GET: user/Edit/5
        public ActionResult Student_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "U_id,firstname,lastname,username,password")] user1 user1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetStudent");
            }
            return View(user1);
        }

        // GET: user/Delete/5
        public ActionResult Student_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user1 user1 = db.user1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Student_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Student_DeleteConfirmed(int id)
        {
            user1 user1 = db.user1.Find(id);
            db.user1.Remove(user1);
            db.SaveChanges();
            return RedirectToAction("GetStudent");
        }

        // GET: registerations/Create
        public ActionResult Registeration_Create()
        {
            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1");
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse");
            return View();
        }

        // POST: registerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registeration_Create([Bind(Include = "R_id,firstname,lastname,nic,course_id,batch_id,Mob_no")] registeration registeration)
        {
            if (ModelState.IsValid)
            {
                db.registerations.Add(registeration);
                db.SaveChanges();
                return RedirectToAction("GetRegisteration");
            }

            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1", registeration.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse", registeration.course_id);
            return View(registeration);
        }

        // GET: registerations
        public ActionResult GetRegisteration1()
        {
            var registerations = db.registerations.Include(r => r.batch).Include(r => r.course);
            return View(registerations.ToList());
        }

        // GET: registerations/Details/5
        public ActionResult Registeration_Details1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registeration registeration = db.registerations.Find(id);
            if (registeration == null)
            {
                return HttpNotFound();
            }
            return View(registeration);
        }

        // GET: registerations/Create
        public ActionResult Registeration_Create1()
        {
            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1");
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse");
            return View();
        }

        // POST: registerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registeration_Create1([Bind(Include = "R_id,firstname,lastname,nic,course_id,batch_id,Mob_no")] registeration registeration)
        {
            if (ModelState.IsValid)
            {
                db.registerations.Add(registeration);
                db.SaveChanges();
                return RedirectToAction("GetRegisteration1");
            }

            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1", registeration.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse", registeration.course_id);
            return View(registeration);
        }

        // GET: registerations/Edit/5
        public ActionResult Registeration_Edit1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registeration registeration = db.registerations.Find(id);
            if (registeration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1", registeration.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse", registeration.course_id);
            return View(registeration);
        }

        // POST: registerations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registeration_Edit1([Bind(Include = "R_id,firstname,lastname,nic,course_id,batch_id,Mob_no")] registeration registeration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetRegisteration1");
            }
            ViewBag.batch_id = new SelectList(db.batches, "B_id", "batch1", registeration.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "C_id", "couse", registeration.course_id);
            return View(registeration);
        }

        // GET: registerations/Delete/5
        public ActionResult Registeration_Delete1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registeration registeration = db.registerations.Find(id);
            if (registeration == null)
            {
                return HttpNotFound();
            }
            return View(registeration);
        }

        // POST: registerations/Delete/5
        [HttpPost, ActionName("Registeration_Delete1")]
        [ValidateAntiForgeryToken]
        public ActionResult Registeration_DeleteConfirmed1(int id)
        {
            registeration registeration = db.registerations.Find(id);
            db.registerations.Remove(registeration);
            db.SaveChanges();
            return RedirectToAction("GetRegisteration");
        }
        
        // GET: timetables
        public ActionResult Timetable_Index()
        {
            var timetables = db.timetables.Include(t => t.course).Include(t => t.course);
            return View(timetables.ToList());
        }

        // GET: timetables/Details/5
        public ActionResult Timetable_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: timetables/Create
        public ActionResult Timetable_Create()
        {
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse");
            ViewBag.U_id = new SelectList(db.user1, "U_id", "firstname");
            return View();
        }

        // POST: timetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Timetable_Create([Bind(Include = "tt_id,C_id,U_id,tt_time,room")] timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.timetables.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Timetable_Index");
            }

            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", timetable.C_id);
            return View(timetable);
        }

        // GET: timetables/Edit/5
        public ActionResult Timetable_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", timetable.C_id);
            return View(timetable);
        }

        // POST: timetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Timetable_Edit([Bind(Include = "tt_id,C_id,U_id,tt_time,room")] timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Timetable_Index");
            }
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", timetable.C_id);
            return View(timetable);
        }

        // GET: timetables/Delete/5
        public ActionResult Timetable_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: timetables/Delete/5
        [HttpPost, ActionName("Timetable_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Timetable_DeleteConfirmed(int id)
        {
            timetable timetable = db.timetables.Find(id);
            db.timetables.Remove(timetable);
            db.SaveChanges();
            return RedirectToAction("Timetable_Index");
        }
        public ActionResult teacher_Index()
        {
            var teachers = db.teachers.Include(t => t.course);
            return View(teachers.ToList());
        }

        // GET: teachers/Details/5
        public ActionResult teacher_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: teachers/Create
        public ActionResult teacher_Create()
        {
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse");
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult teacher_Create([Bind(Include = "teacher_id,teacher_name,teacher_Contact,teacher_Email,C_id,teacher_password")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("teacher_Index");
            }

            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", teacher.C_id);
            return View(teacher);
        }

        // GET: teachers/Edit/5
        public ActionResult teacher_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", teacher.C_id);
            return View(teacher);
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult teacher_Edit([Bind(Include = "teacher_id,teacher_name,teacher_Contact,teacher_Email,C_id,teacher_password")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("teacher_Index");
            }
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", teacher.C_id);
            return View(teacher);
        }

        // GET: teachers/Delete/5
        public ActionResult teacher_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("teacher_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult teacher_DeleteConfirmed(int id)
        {
            teacher teacher = db.teachers.Find(id);
            db.teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("teacher_Index");
        }


        // GET: attendances
        public ActionResult attendance_Index()
        {
            var attendances = db.attendances.Include(a => a.teacher).Include(a => a.course).Include(a => a.registeration);
            return View(attendances.ToList());
        }
        public ActionResult attendance_Index1()
        {
            var attendances = db.attendances.Include(a => a.teacher).Include(a => a.course).Include(a => a.registeration);
            return View(attendances.ToList());
        }
        // GET: attendances/Details/5
        public ActionResult attendance_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: attendances/Create
        public ActionResult attendance_Create()
        {
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name");
            course c = new course();
            teacher t = new teacher();
            
            List<teacher> t1 = db.teachers.Where(x => x.C_id == c.C_id).OrderByDescending(x => x.teacher_id).ToList();

            ViewBag.C_id = new SelectList(db.courses.Where(x => x.C_id == t.C_id).OrderByDescending(x => x.C_id), "C_id", "couse");
            ViewBag.U_id = new SelectList(db.user1, "U_id", "firstname");
            return View();
        }

        // POST: attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult attendance_Create([Bind(Include = "A_id,C_id,U_id,teacher_id,date")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("attendance_Index");
            }

            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", attendance.teacher_id);
            course c = new course();
            teacher t = new teacher();
            int tea = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> t1 = db.teachers.Where(x => x.C_id == c.C_id).OrderByDescending(x => x.teacher_id).ToList();

            ViewBag.C_id = new SelectList(db.courses.Where(x => x.C_id == t.C_id).OrderByDescending(x => x.C_id), "C_id", "couse");

            //ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", attendance.C_id);
            
            ViewBag.R_id = new SelectList(db.registerations, "R_id", "firstname", attendance.R_id);
            return View(attendance);
        }

        // GET: attendances/Edit/5
        public ActionResult attendance_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", attendance.teacher_id);
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", attendance.C_id);
            ViewBag.R_id = new SelectList(db.registerations, "U_id", "firstname", attendance.R_id);
            return View(attendance);
        }

        // POST: attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult attendance_Edit([Bind(Include = "A_id,C_id,U_id,teacher_id,date")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("attendance_Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", attendance.teacher_id);
            course c = new course();
            teacher t = new teacher();
            int tea = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> t1 = db.teachers.Where(x => x.C_id == c.C_id ).OrderByDescending(x => x.teacher_id).ToList();
            
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", attendance.C_id);
            ViewBag.R_id = new SelectList(db.registerations, "R_id", "firstname", attendance.R_id);
            return View(attendance);
        }
        // GET: attendances/Edit/5
        public ActionResult attendance_Edit1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", attendance.teacher_id);
            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", attendance.C_id);
            ViewBag.R_id = new SelectList(db.registerations, "U_id", "firstname", attendance.R_id);
            return View(attendance);
        }

        // POST: attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult attendance_Edit1([Bind(Include = "A_id,C_id,U_id,teacher_id,date")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("attendance_Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", attendance.teacher_id);
            course c = new course();
            teacher t = new teacher();
            int tea = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> t1 = db.teachers.Where(x => x.C_id == c.C_id).OrderByDescending(x => x.teacher_id).ToList();

            ViewBag.C_id = new SelectList(db.courses, "C_id", "couse", attendance.C_id);
            ViewBag.R_id = new SelectList(db.registerations, "R_id", "firstname", attendance.R_id);
            return View(attendance);
        }

        // GET: attendances/Delete/5
        public ActionResult attendance_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: attendances/Delete/5
        [HttpPost, ActionName("attendance_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult attendance_DeleteConfirmed(int id)
        {
            attendance attendance = db.attendances.Find(id);
            db.attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("attendance_Index");
        }
        [HttpGet]
        public ActionResult t_course()
        {

            teacher_course t = new teacher_course();
            int tea = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> t1 = db.teachers.Where(x => x.teacher_id == tea).OrderByDescending(x => x.teacher_id).ToList();
            ViewData["List"] = t1;
            
            return View();


        }

      [HttpPost]
      public ActionResult t_course(teacher_course t2)
        {
            teacher_course t = new teacher_course();
            int tea = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> t1 = db.teachers.Where(x => x.teacher_id == tea).OrderByDescending(x => x.teacher_id).ToList();
            ViewData["List"] = t1;

            return View();

        }
        [HttpGet]
        public ActionResult t_course_a()
        {

            course list1 = new course();

            int tid = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> ti = db.teachers.Where(x => x.teacher_id == tid).OrderByDescending(x => x.teacher_id).ToList();
            ViewData["list"] = ti;
            return View();


        }

        [HttpPost]
        public ActionResult t_course_a(teacher_course t2)
        {
            int tid = Convert.ToInt32(Session["teacher_id"].ToString());
            List<teacher> ti = db.teachers.Where(x => x.teacher_id == tid).OrderByDescending(x => x.teacher_id).ToList();
                        ViewData["list"] = ti;
           
            teacher_course t3 = new teacher_course();
                    t3.t_c_id = t2.t_c_id;
                    t3.teacher_id = tid;
                    t3.C_id = t2.C_id;
            t3.R_id = t2.R_id;

            db.teacher_course.Add(t3);
                    db.SaveChanges();
            teacher_course k = db.teacher_course.Where(x => x.t_c_id == t3.t_c_id).SingleOrDefault();
            Session["t_c_id"] = k.t_c_id;
            Session["C_id"] = k.C_id;


            return RedirectToAction("t_student_a");
        }


        [HttpGet]
        public ActionResult t_student_a()
        {

            course list1 = new course();
            registeration r = new registeration();
            int tid = Convert.ToInt32(Session["C_id"].ToString());
            List<registeration> ti = db.registerations.Where(x => x.course_id == tid).OrderByDescending(x => x.R_id).ToList();
            ViewData["list"] = ti;
            return View();


        }

        [HttpPost]
        public ActionResult t_student_a(teacher_student t2)
        {
            registeration r = new registeration();
            int tid = Convert.ToInt32(Session["C_id"].ToString());
            int tid1 = Convert.ToInt32(Session["t_c_id"].ToString());
            List<registeration> ti = db.registerations.Where(x => x.course_id == tid).OrderByDescending(x => x.R_id).ToList();
            ViewData["list"] = ti;

            teacher_student t3 = new teacher_student();
            t3.t_s_id = t2.t_s_id;
            t3.t_c_id = tid1;
            t3.C_id = tid;
            t3.R_id = t2.R_id;

            db.teacher_student.Add(t3);
            db.SaveChanges();
            teacher_student k = db.teacher_student.Where(x => x.t_s_id == t3.t_s_id).SingleOrDefault();
            Session["t_s_id"] = k.t_s_id;
            Session["R_id"] = k.R_id;


            return RedirectToAction("t_student_a1");
        }
        [HttpGet]
        public ActionResult t_student_a1()
        {

            course list1 = new course();
            registeration r = new registeration();
            int tid = Convert.ToInt32(Session["R_id"].ToString());
            List<registeration> ti = db.registerations.Where(x => x.R_id == tid).OrderByDescending(x => x.R_id).ToList();
            ViewData["list"] = ti;
            return View();


        }

        [HttpPost]
        public ActionResult t_student_a1(attendance t2)
        {
            registeration r = new registeration();
            int tid2 = Convert.ToInt32(Session["C_id"].ToString());
            int tid1 = Convert.ToInt32(Session["t_c_id"].ToString());
            int tid = Convert.ToInt32(Session["R_id"].ToString());
            int tid3 = Convert.ToInt32(Session["teacher_id"].ToString());
            List<registeration> ti = db.registerations.Where(x => x.R_id == tid).OrderByDescending(x => x.R_id).ToList();
            ViewData["list"] = ti;

            attendance t3 = new attendance();
            t3.A_id = t2.A_id;
            t3.C_id = tid2;
            t3.R_id = tid;
            t3.teacher_id = tid3;
            t3.Attendance1 = t2.Attendance1;
            db.attendances.Add(t3);
            db.SaveChanges();



            return RedirectToAction("t_student_a");
        }
        [HttpGet]
        public ActionResult teacher_timetable()
        {

                List<timetable> ti = db.timetables.OrderByDescending(x => x.tt_id).ToList();
          

                    ViewData["list"] = ti;
                
                
             
            return View();


        }

        [HttpGet]
        public ActionResult teacher_course_student()
        {

            List<timetable> ti = db.timetables.OrderByDescending(x => x.tt_id).ToList();


            ViewData["list"] = ti;



            return View();


        }

    }
}