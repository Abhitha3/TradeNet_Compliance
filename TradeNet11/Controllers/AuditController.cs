using Microsoft.AspNetCore.Mvc;
using TradeNet11.Interfaces;
using TradeNet11.Models;

namespace TradeNet11.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        public async Task<IActionResult> Index()
        {
            var audits = await _auditService.GetAllAuditsAsync();
            return View(audits);
        }

        public async Task<IActionResult> Details(int id)
        {
            var audit = await _auditService.GetAuditDetailAsync(id);
            if (audit is null)
                return NotFound();

            return View(audit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Start(int id)
        {
            await _auditService.StartAuditAsync(id);
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id, string findings)
        {
            await _auditService.CompleteAuditAsync(id, findings);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Audit audit)
        {
            // Default officer ID = 1 (seeded officer)
            audit.AssignedOfficerId = 1;
            await _auditService.CreateAuditAsync(audit);
            return RedirectToAction(nameof(Index));
        }
    }
}
