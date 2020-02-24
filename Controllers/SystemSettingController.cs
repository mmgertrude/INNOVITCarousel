using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DNADigital.AppService.Data;
using DNADigital.DataAccess.Models;

namespace DNADigital.Controllers
{
    public class SystemSettingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemSettingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemSetting
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemSettings.ToListAsync());
        }

        
        // GET: SystemSetting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemSetting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Settings_type,Description,Text,Id,Version,Created,Updated")] SystemSetting systemSetting)
        {
            /*test code for unique constraint */
            bool Does_Code_Exist = _context.SystemSettings.Any
            (x => x.Code == systemSetting.Code);
            if (Does_Code_Exist == true)
            {
                ModelState.AddModelError("Code", "Code already exists");
            }

    
            if (ModelState.IsValid)
            {
                systemSetting.Id = Guid.NewGuid();
                _context.Add(systemSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemSetting);
        }


        /*trying to implement partital views*/
        
        public IActionResult TestingPage()
        {
            return View();
        }


        /*end of test code */


        /*trying to implement partital views
        [HttpGet]
        public IActionResult TestingPage()
        {
            return PartialView("_ChooseType");
        }


        end of test code */


        // GET: SystemSetting/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetting = await _context.SystemSettings.FindAsync(id);
            if (systemSetting == null)
            {
                return NotFound();
            }
            return View(systemSetting);
        }

        // POST: SystemSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Code,Settings_type,Description,Text,Id,Version,Created,Updated")] SystemSetting systemSetting)
        {
            if (id != systemSetting.Id)
            {
                return NotFound();
            }

            /* test code **/
            //find the dept row in the db that has this id
            //put here because the department from the DB was not being "seen". kept getting Update Concurrency error*/
            var systemSetting_db = _context.Find<DataAccess.Models.SystemSetting>(systemSetting.Id);
            /* end of test code **/


            if (ModelState.IsValid)
            {
                try
                {
                    /* test code **/
                    //here you can assign the other properties of Department entity if you will be changing then in the view
                    systemSetting_db.Description = systemSetting.Description;
                    systemSetting_db.Settings_type = systemSetting.Settings_type;
                    systemSetting_db.Text = systemSetting.Text;
                    systemSetting_db.Code = systemSetting.Code;


                    /*end of test code **/

                    //_context.Update(systemSetting);
                    _context.Update(systemSetting_db);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemSettingExists(systemSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(systemSetting);
        }

        //considering to remove these Action MEthods since they are not being used
        /*
        
        // GET: SystemSetting/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetting = await _context.SystemSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemSetting == null)
            {
                return NotFound();
            }

            return View(systemSetting);
        }

       
        // GET: SystemSetting/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetting = await _context.SystemSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemSetting == null)
            {
                return NotFound();
            }

            return View(systemSetting);
        }

        // POST: SystemSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var systemSetting = await _context.SystemSettings.FindAsync(id);
            _context.SystemSettings.Remove(systemSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool SystemSettingExists(Guid id)
        {
            return _context.SystemSettings.Any(e => e.Id == id);
        }
    }
}
