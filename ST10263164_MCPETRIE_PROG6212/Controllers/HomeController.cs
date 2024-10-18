using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10263164_MCPETRIE_PROG6212.Data;
using ST10263164_MCPETRIE_PROG6212.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ST10263164_MCPETRIE_PROG6212.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var claims = await _dbContext.Claims.ToListAsync();
            return View(claims);
        }

        //aprovals

        [HttpPost]
        public IActionResult ApproveClaimPC(int claimId)
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.ProgrammeCoordinatorApproval = true;

            if (record.AcademicManagerApproval == true)
            {
                record.OverallAproval = "Approved";

                var pendingClaims = _dbContext.Claims
                    .Where(c => c.ProgrammeCoordinatorApproval == false)
                    .ToList();

                var model = new PendingClaimsViewModel
                {
                    Claims = pendingClaims
                };

                _dbContext.SaveChanges();
                return View("PendingClaims", model);
            }

            var allPendingClaims = _dbContext.Claims
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges();
            return View("PendingClaims", allPendingClaimsModel);
        }

        [HttpPost]
        public IActionResult ApproveClaimAM(int claimId)
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.AcademicManagerApproval = true; 

            if (record.ProgrammeCoordinatorApproval == true)
            {
                record.OverallAproval = "Approved";

                var pendingClaims = _dbContext.Claims
                    .Where(c => c.AcademicManagerApproval == false)
                    .ToList();

                var model = new PendingClaimsViewModel
                {
                    Claims = pendingClaims
                };

                _dbContext.SaveChanges();
                return View("PendingClaims", pendingClaims);
            }

            var allPendingClaims = _dbContext.Claims
                .Where(c => c.AcademicManagerApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges();
            return View("PendingClaims", allPendingClaimsModel);
        }

        //denials

        [HttpPost]
        public IActionResult DenyClaimPC(int claimId)
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.ProgrammeCoordinatorApproval = false;
            record.OverallAproval = "Denied";

            var allPendingClaims = _dbContext.Claims
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges();
            return View("PendingClaims", allPendingClaimsModel);
        }

        [HttpPost]
        public IActionResult DenyClaimAM(int claimId)
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.AcademicManagerApproval = false;
            record.OverallAproval = "Denied";

            var allPendingClaims = _dbContext.Claims
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges();
            return View("PendingClaims", allPendingClaimsModel);
        }

        ///////////////////


        public async Task<IActionResult> PendingClaims()
        {
            var PendingClaims = await _dbContext.Claims
                .Where(c => c.OverallAproval == "pending")
                .ToListAsync();

            var model = new PendingClaimsViewModel
            {
                Claims = PendingClaims
            };

            return View(model);
        }

        public async Task<IActionResult> PendingClaimsAM()
        {
            var PendingClaims = await _dbContext.Claims
                .Where(c => c.OverallAproval == "pending")
                .ToListAsync();

            var model = new PendingClaimsViewModel
            {
                Claims = PendingClaims
            };

            return View(model);
        }

        public IActionResult MyClaims()
        {
            var claims = _dbContext.Claims.ToList();
            var viewModel = new MyClaimsViewModel
            {
                Claims = claims
            };
            return View(viewModel);
        }

        public IActionResult SelectLogin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateClaim()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaim(Claim claim, IFormFile supportingDocuments)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log the error or inspect it
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(claim);
            }

            if (supportingDocuments != null && supportingDocuments.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await supportingDocuments.CopyToAsync(memoryStream);
                    claim.SupportingDocument = memoryStream.ToArray();
                }
            }
            else
            {
                ModelState.AddModelError("SupportingDocument", "The supportingDocuments field is required.");
                return View(claim);
            }

            _dbContext.Claims.Add(claim);
            await _dbContext.SaveChangesAsync();

            Console.WriteLine($"Claim created successfully with Claim ID: {claim.ClaimId}");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Create(AcademicManager model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log the error or inspect it
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(model);
            }

            // Proceed with saving the model
            return RedirectToAction("Index");
        }
    }
}
