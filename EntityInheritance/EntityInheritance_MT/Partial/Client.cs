using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInheritance_MT
{
    public partial class Client
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #region CRUD Methods

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
                    Client customer = context.People.OfType<Client>().First(Customer => Customer.Id == Id);
                    context.People.DeleteObject(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        public Client Load(long Id)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Client customer = context.People.OfType<Client>().FirstOrDefault(Customer => Customer.Id == Id);

                    if (customer != null)
                    {
                        context.Detach(customer);
                    }

                    return customer;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        public Client LoadByCustomerName(string customerName)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Client customer = context.People.OfType<Client>().FirstOrDefault(Customer => Customer.Name == customerName);

                    if (customer != null)
                    {
                        context.Detach(customer);
                    }

                    return customer;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #endregion CRUD               

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
