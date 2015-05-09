using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using System.Data.Entity.Validation;

namespace Personal.Tests
{
    public class JobsTests
    {
        public void CanAddJob()
        {
            var context = new HrDbContext();

            var existing = context.Jobs.SingleOrDefault(j => j.JobId == "CEO");
            if (existing != null)
            {
                context.Jobs.Remove(existing);
                context.SaveChanges();
            }


            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Officer",
                MinSalary = 1,
                MaxSalary = 12
            };

            context.Jobs.Add(job);
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }  

            //get
            var retrievedJob = context.Jobs.Single(j => j.JobId == "CEO");
            //verificare
            retrievedJob.ShouldBe(job);
        }
        
        public void MaxLengthOnJobTitleThrowsError()
        {
            var context = new HrDbContext();
            var existing = context.Jobs.SingleOrDefault(j => j.JobId == "CFO");
            if (existing != null)
            {
                context.Jobs.Remove(existing);
                context.SaveChanges();
            }


            var job = new Job
            {
                JobId = "CFO",
                JobTitle = "Chief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive OfficerChief Executive Officer",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };

            context.Jobs.Add(job);
            Should.Throw<DbEntityValidationException>(() => context.SaveChanges());
        }
    }

}
