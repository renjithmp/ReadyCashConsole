using LoanCore.Actions;
using LoanCore.Model;
using LoanService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Controllers;

[ApiController]
[Route("[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILogger<LoanController> _logger;
    private LoanAccountService _loanAccountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoanController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="loanAccountService">The loan account service.</param>
    public LoanController(ILogger<LoanController> logger, LoanAccountService loanAccountService)
    {
        _logger = logger;
        _loanAccountService = loanAccountService;
    }

    /// <summary>
    /// Creates a new loan.
    /// </summary>
    [HttpPost(Name = "CreateLoan")]
    public void Create()
    {
        _loanAccountService.Execute(1, 1000, 10, 24);
    }
}

