using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInheritance_MT
{
    //----------------------------------------------------------------------------------------------------------------------------------------------------------//

    public partial class Employee
    {
        #region CRUD......

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public long Save()
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Boolean EditedRecord = (this.Id > 0);

                    if (!EditedRecord)  //New Record
                    {
                        context.People.AddObject(this);
                    }
                    else    //Edited Record
                    {
                        ObjectSet<Person> objectSet = context.People;
                        objectSet.Attach(this);
                        objectSet.Context.ObjectStateManager.ChangeObjectState(this, System.Data.EntityState.Modified);
                    }

                    context.SaveChanges();
                    return this.Id;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public void Delete(long Id)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Employee employee = context.People.OfType<Employee>().First(emp => emp.Id == Id);
                    context.People.DeleteObject(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Employee Load(long Id)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Employee employee = context.People.OfType<Employee>().FirstOrDefault(emp => emp.Id == Id);

                    if (employee != null)
                    {
                        context.Detach(employee);
                    }

                    return employee;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Employee LoadByEmpName(string EmpName)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Employee employee = context.People.OfType<Employee>().FirstOrDefault(emp => emp.Name == EmpName);

                    if (employee != null)
                    {
                        context.Detach(employee);
                    }

                    return employee;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #endregion CRUD....
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------//
}
