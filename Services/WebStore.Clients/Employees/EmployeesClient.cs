﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebStore.Clients.Base;
using WebStore.Domain.ViewModels;
using WebStore.infrastucture.interfaces;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration config) : base(config, "api/employees") { }

        public void Add(EmployeeView Employee) => Post(_ServiceAddress, Employee);

        public bool Delete(int id) => Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;

        public EmployeeView Edit(int id, EmployeeView Employee)
        {
            var response = Put($"{_ServiceAddress}/{id}", Employee);
            return response.Content.ReadAsAsync<EmployeeView>().Result;
        }

        public IEnumerable<EmployeeView> GetAll() => Get<List<EmployeeView>>(_ServiceAddress);

        public EmployeeView GetById(int id) => Get<EmployeeView>($"{_ServiceAddress}/{id}");

        public void SaveChanges() { }
    }
}
