//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//using TestEditor.Data;
//using TestEditor.Models;

//namespace TestEditor.Controllers
//{
//    public class DocumentController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public DocumentController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var applicationDbContext = _context.Documents.Include(d => d.User);
//            return View(await applicationDbContext.ToListAsync());
//        }
//        public async Task<IActionResult> Create()
//        {
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
//            return View();
//        }
//        //POST: Docs/Create
//        //To protect from overposting attacks, enable the specific properties you want to bind to.
//        [HttpPost]
//        [ValidateAntiForgeryToken]

//        public async Task<IActionResult> Create([Bind("Id,Title,Content,UserId")] Document document)
//        {
//            if(ModelState.IsValid)
//            {
//                _context.Add(document);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", document.UserId);
//            return View(document);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if(id == null || _context.Documents == null)
//            {
//                return NotFound();
//            }
//            var document = await _context.Documents.FindAsync(id);
//            if(document == null)
//            {
//                return NotFound();
//            }
//            if (document.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
//            {
//                return NotFound();
//            }

//            return View(document);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,UserId")] Document document)
//        {
//            if(id != document.Id)
//            {
//                return NotFound();
//            }
//            if(ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(document);
//                    await _context.SaveChangesAsync();
//                }
//                catch(DbUpdateConcurrencyException)
//                {
//                    if (!DocumentExists(document.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", document.UserId);
//            return View(document);
//        }
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Documents == null)
//            {
//                return NotFound();
//            }
//            var document = await _context.Documents
//                .Include(d =>d.User)
//                .FirstOrDefaultAsync(c => c.Id == id);
//            if (document == null)
//            {
//                return NotFound();
//            }
//            if (document.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
//            {
//                return NotFound();
//            }
//            return View(document);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if(_context.Documents == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Documents' is null.");
//            }
//            var document = await _context.Documents.FindAsync(id);
//            if (document != null)
//            {
//                _context.Documents.Remove(document);
//            }
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        private bool DocumentExists(int id)
//        {
//            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
//        }

//    }
//}
