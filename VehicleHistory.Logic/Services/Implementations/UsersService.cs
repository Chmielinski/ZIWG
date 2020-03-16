using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Services.Interfaces;
using VehicleHistory.WebApi.Helpers;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private VehicleHistoryContext _context;

        public UsersService(VehicleHistoryContext context)
        {
            _context = context;
        }
    }
}
