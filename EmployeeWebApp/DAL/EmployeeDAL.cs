using EmployeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeWebApp.DAL
{
    public class EmployeeDAL
    {
        EmployeeDBEntities _db = new EmployeeDBEntities();

        public (bool done, string message) Add(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    return (true, "Added Successfully.");
                }
                else
                {
                    return (false, "Object is null.");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
            
        }

        public (bool done, string message) Edit(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var obj = _db.Employees.Where(emp => emp.Id == employee.Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.FirstName = employee.FirstName;
                        obj.LastName = employee.LastName;
                        obj.age = employee.age;
                        obj.PhoneNumber = employee.PhoneNumber;

                        _db.SaveChanges();
                        return (true, "Edited Successfulluy");
                    }
                    else
                    {
                        return (false, "Object not found.");
                    }
                }
                else
                {
                    return (false, "Object is null.");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        public (bool done, string message) Delete(int id)
        {
            try
            {
                var obj = _db.Employees.Where(emp => emp.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    _db.Employees.Remove(obj);
                    _db.SaveChanges();
                    return (true, "Deleted Successfully.");
                }
                else
                {
                    return (false, "Can not find object in database with this Id.");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public List<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }
        public Employee GetOne(int id)
        {
            return _db.Employees.Where(emp => emp.Id == id).FirstOrDefault();
        }
    }
}