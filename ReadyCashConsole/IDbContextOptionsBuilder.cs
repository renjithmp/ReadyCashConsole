using System;
using Microsoft.EntityFrameworkCore;

namespace ReadyCashConsole
{
	public interface IDbContext
	{
		DbContext GetDbContext();
	}
}

