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
        public IActionResult ApproveClaimPC(int claimId) // This is the action method that will be called when the user navigates to the PendingClaims(programme coordinator) page
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.ProgrammeCoordinatorApproval = true;

            if (record.AcademicManagerApproval == true)
            {
                record.OverallAproval = "Approved"; //approves the claim if both the programme coordinator and academic manager have approved it

                var pendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                    .Where(c => c.ProgrammeCoordinatorApproval == false)
                    .ToList();

                var model = new PendingClaimsViewModel
                {
                    Claims = pendingClaims
                };

                _dbContext.SaveChanges(); //saves the changes to the database
                return View("PendingClaims", model);
            }

            var allPendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges(); //saves the changes to the database
            return View("PendingClaims", allPendingClaimsModel);
        }

        [HttpPost]
        public IActionResult ApproveClaimAM(int claimId) // This is the action method that will be called when the user navigates to the PendingClaims(academic manager) page
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.AcademicManagerApproval = true;

            if (record.ProgrammeCoordinatorApproval == true)
            {
                record.OverallAproval = "Approved"; //approves the claim if both the programme coordinator and academic manager have approved it

                var pendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                    .Where(c => c.AcademicManagerApproval == false)
                    .ToList();

                var model = new PendingClaimsViewModel
                {
                    Claims = pendingClaims
                };

                _dbContext.SaveChanges(); //saves the changes to the database
                return View("PendingClaims", pendingClaims);
            }

            var allPendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                .Where(c => c.AcademicManagerApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges(); //saves the changes to the database
            return View("PendingClaims", allPendingClaimsModel);
        }

        //denials

        [HttpPost]
        public IActionResult DenyClaimPC(int claimId) // This is the action method that will be called when the user navigates to the PendingClaims(programme coordinator) page
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.ProgrammeCoordinatorApproval = false;
            record.OverallAproval = "Denied";

            var allPendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges(); //saves the changes to the database
            return View("PendingClaims", allPendingClaimsModel);
        }

        [HttpPost]
        public IActionResult DenyClaimAM(int claimId) // This is the action method that will be called when the user navigates to the PendingClaims(academic manager) page
        {
            var record = _dbContext.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (record == null)
            {
                return NotFound();
            }

            record.AcademicManagerApproval = false;
            record.OverallAproval = "Denied";

            var allPendingClaims = _dbContext.Claims //this is the list of all claims that are pending
                .Where(c => c.ProgrammeCoordinatorApproval == false)
                .ToList();

            var allPendingClaimsModel = new PendingClaimsViewModel
            {
                Claims = allPendingClaims
            };

            _dbContext.SaveChanges(); //saves the changes to the database
            return View("PendingClaims", allPendingClaimsModel);
        }

        ///////////////////


        public async Task<IActionResult> PendingClaims() // This is the action method that will be called when the user navigates to the PendingClaims page
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

        public async Task<IActionResult> PendingClaimsAM() // This is the action method that will be called when the user navigates to the PendingClaims page
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

        public IActionResult MyClaims() // This is the action method that will be called when the user navigates to the MyClaims page
        {
            var claims = _dbContext.Claims.ToList();
            var viewModel = new MyClaimsViewModel
            {
                Claims = claims
            };
            return View(viewModel);
        }

        public IActionResult ViewLecturers() // This is the action method that will be called when the user navigates to the ViewLecturers page
        {
            var lecturers = _dbContext.Lecturers.ToList();
            var viewModel = new ViewLecturerViewModel
            {
                Lecturer = lecturers
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
        public async Task<IActionResult> CreateClaim(Claim claim, IFormFile supportingDocuments) // This is the action method that will be called when the user submits the form on the CreateClaim page
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

        [HttpGet]
        public IActionResult AddLecturer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLecturer(Lecturer lecturer) // This is the action method that will be called when HR member adds a lecturer
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log the error or inspect it
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(lecturer);
            }

            _dbContext.Lecturers.Add(lecturer);
            await _dbContext.SaveChangesAsync();

            Console.WriteLine($"Lecturer added with lecturer id: {lecturer.LecturerId}");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult EditLecturer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLecturerData(Lecturer lecturer)
        {
            var existingLecturer = await _dbContext.Lecturers.FindAsync(lecturer.LecturerId);

            if (existingLecturer == null)
            {
                ModelState.AddModelError("", "Lecturer not found.");
                return View("EditLecturer");
            }

            ModelState.Clear(); // clears model state, removes unnecsesary errors from input boxes on the view
            return View("EditLecturer", existingLecturer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLecturerData(Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return View("EditLecturer", lecturer); // Return the EditLecturer view with the model to show validation errors
            }

            try
            {
                var existingLecturer = await _dbContext.Lecturers.FindAsync(lecturer.LecturerId);

                if (existingLecturer == null)
                {
                    ModelState.AddModelError("", "Lecturer not found.");
                    return View("EditLecturer", lecturer); // Return the EditLecturer view with the model to show the error
                }

                // Update the existing lecturer's details
                existingLecturer.LecturerName = lecturer.LecturerName;
                existingLecturer.LecturerSurname = lecturer.LecturerSurname;
                existingLecturer.LecturerEmail = lecturer.LecturerEmail;
                existingLecturer.LecturerContactNumber = lecturer.LecturerContactNumber;

                // Save changes to the database
                var result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Lecturer details updated successfully!";
                }
                else
                {
                    ModelState.AddModelError("", "No changes were made to the lecturer details.");
                    return View("EditLecturer", lecturer); // Return the EditLecturer view with the model to show the error
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating lecturer details.");
                return View("EditLecturer", lecturer); // Return the EditLecturer view with the model to show the error
            }
        }

        [HttpPost]
        public IActionResult Create(AcademicManager model) // This is the action method that will be called when the user submits the form on the Create page
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
