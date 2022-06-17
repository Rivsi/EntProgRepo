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
        public async Task <IActionResult> Add(SuppliersInv suppliers)
        {

            if (ModelState.IsValid)
            {
                await context.AddAsync(suppliers);
                await context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int supplierID)
        {
            var supplier = await context.SuppliersInvs.FindAsync(supplierID);
            context.Set<SuppliersInv>().Remove(supplier);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {

           
            if (id == null) return RedirectToAction("Index");
            var suppliers = await context.SuppliersInvs.FindAsync(id);
            return View(suppliers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Edit(SuppliersInv supplier)
        {
           

            if (ModelState.IsValid)
            {
                context.Set<SuppliersInv>().Update(supplier);
                context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }
    }
}
