using Restraunt.Core.Interfaces;
using System;
namespace Restraunt.Data.Interfaces
{
	public interface IUnitOfWorks
	{
		IDishRepository Dishes { get; }
		ITableRepository Tables { get; }
		void Save();
	}
}

