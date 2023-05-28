﻿using System;
using System.Data;
using System.Xml.Linq;
using Dapper;

namespace Exercise1Dapper
{
    
        public class DapperDepartmentRepository : IDepartmentRepository
        {
            private readonly IDbConnection _connection;
            //Constructor
            public DapperDepartmentRepository(IDbConnection connection)
            {
                _connection = connection;
            }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
new { departmentName = newDepartmentName });
        }



    }

}
