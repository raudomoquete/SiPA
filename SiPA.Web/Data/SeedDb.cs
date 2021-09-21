using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("Raudo","Moquete","sanchezz1ero@gmail.com","829 305 6303","Manzana 6 #19,El Brisal","Administrator");
            var customer = await CheckUserAsync("Adoni", "Montero", "adonimontero20@gmail.com", "829 381 6410", "Calle Luna calle sol","Customer");
            await CheckRequestTypesAsync();
            await CheckParishionersAsync(customer);
            await CheckManagersAsync(manager);
            await CheckSacramentsAsync();
            //await CheckRequestsAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Administrator");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task<User> CheckUserAsync(
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }            

            return user;
        }

        private async Task CheckRequestTypesAsync()
        {
            if (!_dataContext.RequestTypes.Any())
            {
                _dataContext.RequestTypes.Add(new RequestType { Name = "Acta Bautismal" });
                _dataContext.RequestTypes.Add(new RequestType { Name = "Certificado de Primera Comunión" });
                _dataContext.RequestTypes.Add(new RequestType { Name = "Certificado de Confirmación" });
                _dataContext.RequestTypes.Add(new RequestType { Name = "Acta de Matrimonio" });
                await _dataContext.SaveChangesAsync();
            }
        }

        //private async Task CheckParishionersAsync()
        //{
        //    if (!_dataContext.Parishioners.Any())
        //    {
        //        AddParishioner("Borgia", "Sanchez", "809 594 1990", "829 906 2954", "Manzana 6 #19, El Brisal");
        //        AddParishioner("Adriana", "Ramos", "809 594 1990", "829 906 2954", "Manzana 6 #19, El Brisal");
        //        AddParishioner("Ariadna", "Ramos", "809 594 1990", "829 906 2954", "Manzana 6 #19, El Brisal");
        //        await _dataContext.SaveChangesAsync();
        //    }
        //}

        //private void AddParishioner(string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        //{
        //    _dataContext.Parishioners.Add(new Parishioner
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        FixedPhone = fixedPhone,
        //        CellPhone = cellPhone,
        //        Address = address
        //    });
        //}

        private async Task CheckManagersAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckParishionersAsync(User user)
        {
            if (!_dataContext.Parishioners.Any())
            {
                _dataContext.Parishioners.Add(new Parishioner { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckSacramentsAsync()
        {
            if (!_dataContext.SacramentTypes.Any())
            {
                _dataContext.SacramentTypes.Add(new SacramentType { SacramentName = "Bautizo" });
                _dataContext.SacramentTypes.Add(new SacramentType { SacramentName = "Primera Comunión" });
                _dataContext.SacramentTypes.Add(new SacramentType { SacramentName = "Confirmación" });
                _dataContext.SacramentTypes.Add(new SacramentType { SacramentName = "Matrimonio" });
                await _dataContext.SaveChangesAsync();
            }
        }

        //private async Task CheckRequestsAsync()
        //{
        //    if (!_dataContext.Requests.Any())
        //    {
        //        var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
        //        var finalDate = initialDate.AddYears(1);
        //        while (initialDate < finalDate)
        //        {
        //            if (initialDate.DayOfWeek != DayOfWeek.Sunday)
        //            {
        //                var finalDate2 = initialDate.AddHours(10);
        //                while (initialDate < finalDate2)
        //                {
        //                    _dataContext.Requests.Add(new Request
        //                    {
        //                        RequestDate = initialDate.ToUniversalTime(),
        //                    });

        //                    initialDate = initialDate.AddMinutes(30);
        //                }

        //                initialDate = initialDate.AddHours(14);

        //            }
        //            else
        //            {
        //                initialDate = initialDate.AddDays(1);
        //            }
        //        }

        //        await _dataContext.SaveChangesAsync();
        //    }
        //}
    }
}
