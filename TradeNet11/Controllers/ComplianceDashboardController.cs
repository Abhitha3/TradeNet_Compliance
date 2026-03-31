using Microsoft.AspNetCore.Mvc;
using TradeNet11.Interfaces;

namespace TradeNet11.Controllers
{
    public class ComplianceDashboardController : Controller
    {
        private readonly IComplianceCaseService _caseService;

        public ComplianceDashboardController(IComplianceCaseService caseService)
        {
            _caseService = caseService;
        }

        public async Task<IActionResult> Index()
        {
            var cases = await _caseService.GetAllCasesAsync();
            return View(cases);
        }

        public async Task<IActionResult> CaseDetail(int id)
        {
            var complianceCase = await _caseService.GetCaseDetailAsync(id);
            if (complianceCase is null)
                return NotFound();

            var records = await _caseService.GetCaseRecordsAsync(id);

            var vm = new Models.ViewModels.CaseDetailViewModel
            {
                Case = complianceCase,
                Records = records
            };

            return PartialView("_CaseDetailModal", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int caseId, string newStatus, string? remarks)
        {
            // Default officer ID = 1 (seeded officer)
            await _caseService.UpdateCaseStatusAsync(caseId, newStatus, 1, remarks);
            return RedirectToAction(nameof(Index));
        }
    }
}
