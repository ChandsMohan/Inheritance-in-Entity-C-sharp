using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EntityInheritance_MT
{
    public partial class Vendor
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
                    Vendor vendor = context.People.OfType<Vendor>().First(vend => vend.Id == Id);
                    context.People.DeleteObject(vendor);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Vendor Load(long Id)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Vendor vendor = context.People.OfType<Vendor>().FirstOrDefault(vend => vend.Id == Id);

                    if (vendor != null)
                    {
                        context.Detach(vendor);
                    }

                    return vendor;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Vendor LoadByVendorName(string vendorName)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Vendor vendor = context.People.OfType<Vendor>().FirstOrDefault(vend => vend.Name == vendorName);

                    if (vendor != null)
                    {
                        context.Detach(vendor);
                    }

                    return vendor;
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
