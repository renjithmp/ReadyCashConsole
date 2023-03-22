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
    //private LoanActions _loanActions;

    public LoanController(ILogger<LoanController> logger,LoanAccountService loanAccountService)
    {
        _logger = logger;
        _loanAccountService = loanAccountService;
      //  _loanActions = loanActions;
    }

    [HttpPost(Name = "CreateLoan")]
    public void Create()
    {
        _loanAccountService.Execute(1, 1000, 10, 24);
    
        
    }
}

