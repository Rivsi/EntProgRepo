using Microsoft.AspNetCore.Mvc;
using Rivadenera___ENTPROG___OTIS2;

namespace Rivadenera___ENTPROG___OTIS2___WebApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly eisensy_csbentprogContext context;
        public CompanyController(eisensy_csbentprogContext dbContext)
        {
            this.context = dbContext;
        }
        public IActionResult Add()
        {
            return View(new SuppliersInv());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SuppliersInv suppliers)
        {

            if (ModelState.IsValid)
            {
                context.Add(suppliers);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(suppliers);
            }
       
        }

        public IActionResult Index()
        {
            return View(context.SuppliersInvs.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int supplierID)
        {
            var supplier = context.SuppliersInvs.Find(supplierID);
            context.Set<SuppliersInv>().Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {

           
                if (id == null) return RedirectToAction("Index");
            var suppliers = context.SuppliersInvs.Find(id);
            return View(suppliers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SuppliersInv supplier)
        {
           

            if (ModelState.IsValid)
            {
                context.Set<SuppliersInv>().Update(supplier);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }
    }
}
